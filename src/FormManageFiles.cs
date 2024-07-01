using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Melodorium
{
	public partial class FormManageFiles : Form
	{
		private MusicFile? _selectedRenameFile;
		private ListViewItem? _selectedRenameFileItem;
		private List<string> _folders = [];
		private string? _selectedFolder;
		private ListViewItem? _selectedFolderItem;
		private List<MismatchFile> _mismatch = [];
		private MismatchFile? _selectedMismatch;
		private ListViewItem? _selectedMismatchItem;

		public FormManageFiles()
		{
			InitializeComponent();
		}

		private void FormManageFiles_Shown(object sender, EventArgs e)
		{
			FindProblems();
			LoadFolders();
			FindMismatch();
		}

		private void FindProblems()
		{
			using var loadingDialog = new FormLoading();
			loadingDialog.Job = () =>
			{
				ListProblems.Items.Clear();
				for (var i = 0; i < Program.MusicData.Files.Count; i++)
				{
					var file = Program.MusicData.Files[i];
					if (!IsGoodName(file.Name))
						ListProblems.Items.Add(new ListViewItem(file.RPath) { Tag = i });
				}
				loadingDialog.Close();
			};
			loadingDialog.ShowDialog(this);
		}

		private static bool IsGoodName(string name)
		{
			return FilenameRegex().Match(name).Success;
		}

		[GeneratedRegex("^([A-Z\\d][A-Za-z\\d]*_)([A-Za-z\\d]*_)*-(_[A-Z\\d][A-Za-z\\d]*)(_[A-Za-z\\d]*)*$")]
		private static partial Regex FilenameRegex();

		private void ListProblems_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ListProblems.SelectedItems.Count == 0) return;
			var item = ListProblems.SelectedItems[0];
			if (item.Tag is not int fileI)
				return;
			_selectedRenameFileItem = item;
			_selectedRenameFile = Program.MusicData.Files[fileI];
			InpRenameOld.Text = _selectedRenameFile.Name;
			InpRenameNew.Text = ImproveName(_selectedRenameFile.Name);
			BtnOpenInExplorer.Enabled = true;
			UpdateRenameStatus();
		}
		private string ImproveName(string name)
		{
			name = Utils.CleanName(name);
			name = new string(Encoding.ASCII.GetChars(Encoding.ASCII.GetBytes(name)));
			if (name.Contains("_-_"))
				name = string.Join("_-_", name.Split("_-_").Select(v => v.Capitalize()));
			return name;
		}

		private void InpRenameNew_TextChanged(object sender, EventArgs e)
		{
			UpdateRenameStatus();
		}

		private void UpdateRenameStatus()
		{
			if (_selectedRenameFile == null) return;
			var name = InpRenameNew.Text;
			PBGoodName.Image = IsGoodName(name) ? Properties.Resources.mark_green : Properties.Resources.cross_red;
			var path = Path.Combine(_selectedRenameFile.Folder, name + _selectedRenameFile.Ext);
			var exist = Path.Exists(path);
			PBAlreadyExist.Image = exist ? Properties.Resources.mark_red : Properties.Resources.cross_green;
			BtnRename.Enabled = !exist && name.IndexOfAny(Path.GetInvalidFileNameChars()) < 0;
		}

		private void BtnRename_Click(object sender, EventArgs e)
		{
			if (_selectedRenameFile == null) return;

			var name = InpRenameNew.Text;
			var path = Path.Combine(_selectedRenameFile.Folder, name + _selectedRenameFile.Ext);
			File.Move(_selectedRenameFile.FPath, path);
			_selectedRenameFile.FPath = path;

			if (_selectedRenameFileItem != null)
				if (IsGoodName(name))
					ListProblems.Items.Remove(_selectedRenameFileItem);
				else
					_selectedRenameFileItem.Text = _selectedRenameFile.RPath;

			_selectedRenameFile = null;
			_selectedRenameFileItem = null;
			InpRenameOld.Text = "";
			InpRenameNew.Text = "";
			PBGoodName.Image = null;
			PBAlreadyExist.Image = null;
			BtnRename.Enabled = false;
			BtnOpenInExplorer.Enabled = false;
			ListProblems.SelectedItems.Clear();
			if (ListProblems.Items.Count > 0)
				ListProblems.Items[0].Selected = true;
		}

		private void BtnOpenInExplorer_Click(object sender, EventArgs e)
		{
			if (_selectedRenameFile == null) return;
			Process.Start(new ProcessStartInfo()
			{
				FileName = "explorer",
				Arguments = $"/e, /select, \"{_selectedRenameFile.FPath}\"",
			});
		}

		private void LoadFolders()
		{
			using var loadingDialog = new FormLoading();
			loadingDialog.Job = () =>
			{
				_folders = Program.MusicData.Files.Select(v => v.RFolder).Distinct().ToList();
				ListFolders.Items.Clear();
				for (var i = 0; i < _folders.Count; i++)
				{
					var folder = _folders[i];
					if (Program.MusicData.FolderAuthor.TryGetValue(folder, out var author))
						if (author == "")
							folder += " [<any>]";
						else
							folder += $" [{author}]";

					ListFolders.Items.Add(new ListViewItem(folder) { Tag = i });
				}
				loadingDialog.Close();
			};
			loadingDialog.ShowDialog(this);
		}

		private void BtnOpenInExplorerFolder_Click(object sender, EventArgs e)
		{
			if (_selectedFolder == null) return;
			Process.Start(new ProcessStartInfo()
			{
				FileName = "explorer",
				Arguments = $"/e, \"{Program.Settings.GetFullPath(_selectedFolder)}\"",
			});
		}

		private void ListFolders_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ListFolders.SelectedItems.Count == 0) return;
			var item = ListFolders.SelectedItems[0];
			if (item.Tag is not int folderI)
				return;
			_selectedFolderItem = item;
			_selectedFolder = null;
			var selectedFolder = _folders[folderI];
			InpFolder.Text = selectedFolder;
			if (Program.MusicData.FolderAuthor.TryGetValue(selectedFolder, out var author))
			{
				InpAuthor.Text = author;
				if (author == "")
				{
					InpAuthorMode_Any.Checked = true;
					InpAuthor.ReadOnly = true;
				}
				else
				{
					InpAuthorMode_Manual.Checked = true;
					InpAuthor.ReadOnly = false;
				}
			}
			else
			{
				InpAuthor.Text = selectedFolder;
				InpAuthorMode_Auto.Checked = true;
				InpAuthor.ReadOnly = true;
			}
			_selectedFolder = selectedFolder;
			BtnOpenInExplorerFolder.Enabled = true;
		}

		private void InpAuthorMode_Auto_CheckedChanged(object sender, EventArgs e)
		{
			if (!InpAuthorMode_Auto.Checked) return;
			if (_selectedFolderItem == null) return;
			if (_selectedFolder == null) return;
			Program.MusicData.FolderAuthor.Remove(_selectedFolder);
			InpAuthor.Text = _selectedFolder;
			InpAuthor.ReadOnly = true;
			BtnSave.Enabled = true;
			_selectedFolderItem.Text = _selectedFolder;
		}

		private void InpAuthorMode_Manual_CheckedChanged(object sender, EventArgs e)
		{
			if (!InpAuthorMode_Manual.Checked) return;
			if (_selectedFolderItem == null) return;
			if (_selectedFolder == null) return;
			Program.MusicData.FolderAuthor[_selectedFolder] = _selectedFolder;
			InpAuthor.Text = _selectedFolder;
			InpAuthor.ReadOnly = false;
			BtnSave.Enabled = true;
			_selectedFolderItem.Text = _selectedFolder + $" [{_selectedFolder}]";
		}

		private void InpAuthorMode_Any_CheckedChanged(object sender, EventArgs e)
		{
			if (!InpAuthorMode_Any.Checked) return;
			if (_selectedFolderItem == null) return;
			if (_selectedFolder == null) return;
			Program.MusicData.FolderAuthor[_selectedFolder] = "";
			InpAuthor.Text = "";
			InpAuthor.ReadOnly = true;
			BtnSave.Enabled = true;
			_selectedFolderItem.Text = _selectedFolder + " [<any>]";
		}

		private void InpAuthor_TextChanged(object sender, EventArgs e)
		{
			if (!InpAuthorMode_Manual.Checked) return;
			if (_selectedFolderItem == null) return;
			if (_selectedFolder == null) return;
			Program.MusicData.FolderAuthor[_selectedFolder] = InpAuthor.Text;
			BtnSave.Enabled = true;
			_selectedFolderItem.Text = _selectedFolder + $" [{InpAuthor.Text}]";
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			Program.MusicData.Save();
			FindMismatch();
		}

		private void FindMismatch()
		{
			using var loadingDialog = new FormLoading();
			loadingDialog.Job = () =>
			{
				var authorToFolder = new Dictionary<string, string>();
				var anyFolder = "";
				foreach (var folder in _folders)
				{
					if (Program.MusicData.FolderAuthor.TryGetValue(folder, out var author))
						if (author != "")
							authorToFolder[author] = folder;
						else
							anyFolder = folder;
					else
						authorToFolder[folder] = folder;
				}
				_mismatch = Program.MusicData.Files
					.Where(f =>
					{
						if (authorToFolder.TryGetValue(f.Author, out var folder))
							return folder != f.RFolder;
						if (Program.MusicData.FolderAuthor.TryGetValue(f.RFolder, out var author))
							return author != "";
						return true;
					})
					.Select(f => new MismatchFile(f, authorToFolder.GetValueOrDefault(f.Author, anyFolder)))
					.ToList();
				ListMismatch.Items.Clear();
				for (var i = 0; i < _mismatch.Count; i++)
				{
					var mismatch = _mismatch[i];
					ListMismatch.Items.Add(new ListViewItem(mismatch.MusicFile.RPath) { Tag = i });
				}
				loadingDialog.Close();
			};
			loadingDialog.ShowDialog(this);
		}

		private void ListMismatch_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ListMismatch.SelectedItems.Count == 0) return;
			var item = ListMismatch.SelectedItems[0];
			if (item.Tag is not int mismatchI)
				return;
			_selectedMismatch = _mismatch[mismatchI];
			_selectedMismatchItem = item;

			InpMismatchName.Text = _selectedMismatch.Value.MusicFile.Name;
			InpMismatchFolder.Text = _selectedMismatch.Value.MusicFile.RFolder;
			InpMismatchFolderExpected.Text = _selectedMismatch.Value.CorrectFolder;

			BtnOpenInExplorerMismatch.Enabled = true;
			var exist = File.Exists(GetMismatchCorrectPath());
			PBAlreadyExistMismatch.Image = exist ? Properties.Resources.mark_red : Properties.Resources.cross_green;
			BtnMoveMismatch.Enabled = !exist;
		}

		private void BtnOpenInExplorerMismatch_Click(object sender, EventArgs e)
		{
			if (_selectedMismatch == null) return;
			Process.Start(new ProcessStartInfo()
			{
				FileName = "explorer",
				Arguments = $"/e, /select, \"{_selectedMismatch.Value.MusicFile.FPath}\"",
			});
		}

		private void BtnMoveMismatch_Click(object sender, EventArgs e)
		{
			if (_selectedMismatch == null) return;
			if (_selectedMismatchItem == null) return;
			File.Move(_selectedMismatch.Value.MusicFile.FPath, GetMismatchCorrectPath());
			ListMismatch.Items.Remove(_selectedMismatchItem);
			_selectedMismatchItem = null;
			_selectedMismatch = null;

			InpMismatchName.Text = "";
			InpMismatchFolder.Text = "";
			InpMismatchFolderExpected.Text = "";

			BtnOpenInExplorerMismatch.Enabled = false;
			BtnMoveMismatch.Enabled = false;
			PBAlreadyExistMismatch.Image = null;
		}

		private string GetMismatchCorrectPath()
		{
			if (_selectedMismatch == null) return "";
			return Path.Combine(
				Program.Settings.GetFullPath(_selectedMismatch.Value.CorrectFolder),
				_selectedMismatch.Value.MusicFile.FName
			);
		}

		private void splitContainer3_Panel2_Paint(object sender, PaintEventArgs e)
		{

		}

		private struct MismatchFile(MusicFile musicFile, string correctFolder)
		{
			public MusicFile MusicFile = musicFile;
			public string CorrectFolder = correctFolder;
		}
	}
}

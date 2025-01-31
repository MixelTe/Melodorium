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
		private List<List<MusicFile>> _similar = [];
		private List<MusicFile>? _selectedSimilar;
		private ListViewItem? _selectedSimilarItem;
		private Dictionary<string, List<MusicFile>> _groups = [];
		private string? _selectedGroup;

		private struct MismatchFile(MusicFile musicFile, string correctFolder)
		{
			public MusicFile MusicFile = musicFile;
			public string CorrectFolder = correctFolder;
		}

		public FormManageFiles()
		{
			InitializeComponent();
			InpRenameOld.Width = splitContainer1.Panel2.Width - 8;
			InpRenameNew.Width = splitContainer1.Panel2.Width - 8;
			BtnRename.Left = splitContainer1.Panel2.Width - 8 - BtnRename.Width;
			BtnOpenInExplorer.Left = splitContainer1.Panel2.Width - 8 - BtnOpenInExplorer.Width;

			InpFolder.Width = splitContainer2.Panel2.Width - 8 - InpFolder.Left;
			InpAuthor.Width = splitContainer2.Panel2.Width - 8 - InpAuthor.Left;
			BtnOpenInExplorerFolder.Left = splitContainer2.Panel2.Width - 8 - BtnOpenInExplorerFolder.Width;
			BtnSave.Left = splitContainer2.Panel2.Width - 8 - BtnSave.Width;

			InpMismatchName.Width = splitContainer3.Panel2.Width - 8 - InpMismatchName.Left;
			splitContainer4.Width = splitContainer3.Panel2.Width - 8;
			InpMismatchFolder.Width = splitContainer4.Panel1.Width - InpMismatchFolder.Left;
			InpMismatchFolderExpected.Width = splitContainer4.Panel2.Width - InpMismatchFolderExpected.Left;
			BtnMoveMismatch.Left = splitContainer3.Panel2.Width - 8 - BtnMoveMismatch.Width;
			BtnOpenInExplorerMismatch.Left = splitContainer3.Panel2.Width - 8 - BtnOpenInExplorerMismatch.Width;

			ListSimilarFiles.Width = splitContainer5.Panel2.Width - 8;
			InpSimiarityLevel.Width = splitContainer5.Panel2.Width - 8 - InpSimiarityLevel.Left;
			BtnApplySimilarity.Left = splitContainer5.Panel2.Width - 8 - BtnApplySimilarity.Width;
		}

		private void FormManageFiles_Shown(object sender, EventArgs e)
		{
			FindProblems();
			LblSimiarityLevel.Text = InpSimiarityLevel.Value + "%";
		}

		private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
		{
			using var loadingDialog = new FormLoading(delayed: true);
			loadingDialog.Job = () =>
			{
				var c = 0;
				MusicData.LoadFull(
					() => { if (++c % 100 == 0) loadingDialog.SetInfo($"{c} files"); },
					loadData: false
					);
				loadingDialog.Close();
			};
			loadingDialog.ShowDialog(this);
			switch (Tabs.SelectedIndex)
			{
				case 0: FindProblems(); break;
				case 1: LoadFolders(); break;
				case 2: FindMismatch(); break;
				case 3: FindSimilar(); break;
				case 4: FindGroup(); break;
				default: break;
			}
		}

		private void FindProblems()
		{
			ListProblems.Items.Clear();
			var items = new List<ListViewItem>();
			for (var i = 0; i < Program.MusicData.Files.Count; i++)
			{
				var file = Program.MusicData.Files[i];
				if (!IsGoodName(file.Name))
					items.Add(new ListViewItem(file.RPath) { Tag = i });
			}
			ListProblems.Items.AddRange(items.ToArray());
			ListProblems.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
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
				name = string.Join("_-_", name.Split("_-_").Select(v => v.Replace('-', '_').Capitalize()));
			return name.Capitalize();
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
			_selectedRenameFile.Move(path);

			var itemI = ListProblems.Items.IndexOf(_selectedRenameFileItem!);

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
			if (itemI < ListProblems.Items.Count)
				ListProblems.Items[itemI].Selected = true;
			else if (ListProblems.Items.Count > 0)
				ListProblems.Items[0].Selected = true;
		}

		private void BtnOpenInExplorer_Click(object sender, EventArgs e)
		{
			if (_selectedRenameFile == null) return;
			Utils.OpenExplorer(_selectedRenameFile.FPath);
		}

		private void LoadFolders()
		{
			_folders = GetFolders();
			ListFolders.Items.Clear();
			var items = new List<ListViewItem>();
			for (var i = 0; i < _folders.Count; i++)
			{
				var folder = _folders[i];
				if (Program.MusicData.FolderAuthor.TryGetValue(folder, out var author))
					if (author == "")
						folder += " [<any>]";
					else
						folder += $" [{author}]";

				items.Add(new ListViewItem(folder) { Tag = i });
			}
			ListFolders.Items.AddRange(items.ToArray());
			ListFolders.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
		}

		private static List<string> GetFolders()
		{
			return Program.MusicData.Files.Select(v => v.RFolder).Distinct().ToList();
		}

		private void BtnOpenInExplorerFolder_Click(object sender, EventArgs e)
		{
			if (_selectedFolder == null) return;
			Utils.OpenExplorer(Program.Settings.GetFullPath(_selectedFolder), true);
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
			var authorToFolder = new Dictionary<string, string>();
			var anyFolder = "";
			_folders = GetFolders();
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
			var items = new List<ListViewItem>();
			for (var i = 0; i < _mismatch.Count; i++)
			{
				var mismatch = _mismatch[i];
				items.Add(new ListViewItem(mismatch.MusicFile.RPath) { Tag = i });
			}
			ListMismatch.Items.AddRange(items.ToArray());
			ListMismatch.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
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
			Utils.OpenExplorer(_selectedMismatch.Value.MusicFile.FPath);
		}

		private void BtnMoveMismatch_Click(object sender, EventArgs e)
		{
			if (_selectedMismatch == null) return;
			if (_selectedMismatchItem == null) return;
			File.Move(_selectedMismatch.Value.MusicFile.FPath, GetMismatchCorrectPath());
			var itemI = ListMismatch.Items.IndexOf(_selectedMismatchItem);
			ListMismatch.Items.Remove(_selectedMismatchItem);
			_selectedMismatchItem = null;
			_selectedMismatch = null;

			InpMismatchName.Text = "";
			InpMismatchFolder.Text = "";
			InpMismatchFolderExpected.Text = "";

			BtnOpenInExplorerMismatch.Enabled = false;
			BtnMoveMismatch.Enabled = false;
			PBAlreadyExistMismatch.Image = null;

			if (itemI < ListMismatch.Items.Count)
				ListMismatch.Items[itemI].Selected = true;
			else if (ListMismatch.Items.Count > 0)
				ListMismatch.Items[0].Selected = true;
		}

		private string GetMismatchCorrectPath()
		{
			if (_selectedMismatch == null) return "";
			return Path.Combine(
				Program.Settings.GetFullPath(_selectedMismatch.Value.CorrectFolder),
				_selectedMismatch.Value.MusicFile.FName
			);
		}

		private void FindSimilar()
		{
			using var loadingDialog = new FormLoading();
			loadingDialog.EnableCancel();
			loadingDialog.Job = () =>
			{
				//var watch = Stopwatch.StartNew();
				List<Tuple<float, List<MusicFile>>> r = [];
				var C = (Program.MusicData.Files.Count - 1) * Program.MusicData.Files.Count / 2;
				var similarityBound = InpSimiarityLevel.Value / 100f;
				var c = 0;
				for (var i = 0; i < Program.MusicData.Files.Count; i++)
				{
					if (i % 10 == 0) loadingDialog.SetProgress((float)c / C);
					if (loadingDialog.Canceled)
						break;

					var file1 = Program.MusicData.Files[i];
					if (r.Where(v => v.Item2.Contains(file1)).Any())
					{
						c += Program.MusicData.Files.Count - i - 1;
						continue;
					}

					List<MusicFile> similarGroup = [file1];
					var maxSimilarity = 0f;
					for (var j = i + 1; j < Program.MusicData.Files.Count; j++)
					{
						c++;
						var file2 = Program.MusicData.Files[j];
						var similarity = FilesSimilarity(file1, file2);
						maxSimilarity = Math.Max(maxSimilarity, similarity);
						if (similarity >= similarityBound)
							similarGroup.Add(file2);
					}
					if (similarGroup.Count > 1)
						r.Add(Tuple.Create(maxSimilarity, similarGroup));
				}
				//watch.Stop();
				//Debug.WriteLine(watch.ElapsedMilliseconds, "FindSimilar_ElapsedMilliseconds");
				ListSimilar.Items.Clear();
				var items = new List<ListViewItem>();
				_similar = r.OrderByDescending(v => v.Item1)
							.ThenBy(v => v.Item2[0].Name)
							.Select(v => v.Item2)
							.ToList();
				var ignoreAuthor = CbxIgnoreAuthor.Checked;
				for (var i = 0; i < _similar.Count; i++)
				{
					var item = _similar[i][0];
					var title = ignoreAuthor ? item.SName : item.Name;
					items.Add(new ListViewItem(title) { Tag = i });
				}
				ListSimilar.Items.AddRange(items.ToArray());
				ListSimilar.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
				loadingDialog.Close();
			};
			loadingDialog.ShowDialog(this);
		}

		private float FilesSimilarity(MusicFile file1, MusicFile file2)
		{
			var ignoreAuthor = CbxIgnoreAuthor.Checked || file1.Author == file2.Author;
			var name1 = ignoreAuthor ? file1.NormilizedName : file1.NormilizedFullName;
			var name2 = ignoreAuthor ? file2.NormilizedName : file2.NormilizedFullName;

			var strictComparison = CbxStrictComparison.Checked;
			if (strictComparison)
				return name1 == name2 ? 1 : 0;

			return Utils.StringSimilarityBySmithWatermanAlgorithm(name1, name2);
		}

		private void ListSimilar_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ListSimilar.SelectedItems.Count == 0) return;
			var item = ListSimilar.SelectedItems[0];
			if (item.Tag is not int similarI)
				return;
			_selectedSimilar = _similar[similarI];
			_selectedSimilarItem = item;


			ListSimilarFiles.Items.Clear();
			for (var i = 0; i < _selectedSimilar.Count; i++)
			{
				var similar = _selectedSimilar[i];
				ListSimilarFiles.Items.Add(new ListViewItem(similar.RPath) { Tag = i });
			}
			ListSimilarFiles.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
		}

		private void ListSimilarFiles_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ListSimilarFiles.SelectedItems.Count == 0) return;
			if (_selectedSimilar == null) return;
			var item = ListSimilarFiles.SelectedItems[0];
			if (item.Tag is not int similarI)
				return;
			if (_selectedSimilar.Count <= similarI) return;
			var file = _selectedSimilar[similarI];

			Utils.OpenExplorer(file.FPath);
		}

		private void CbxIgnoreAuthor_CheckedChanged(object sender, EventArgs e)
		{
			FindSimilar();
		}

		private void CbxStrictComparison_CheckedChanged(object sender, EventArgs e)
		{
			InpSimiarityLevel.Enabled = !CbxStrictComparison.Checked;
			BtnApplySimilarity.Enabled = !CbxStrictComparison.Checked;
			FindSimilar();
		}

		private void InpSimiarityLevel_Scroll(object sender, EventArgs e)
		{
			LblSimiarityLevel.Text = InpSimiarityLevel.Value + "%";
		}

		private void BtnApplySimilarity_Click(object sender, EventArgs e)
		{
			FindSimilar();
		}

		private void FindGroup()
		{
			var files = Program.MusicData.Files
				.Where(v => Program.MusicData.FolderAuthor.TryGetValue(v.RFolder, out var author) && author == "")
				.OrderBy(v => v.Author)
				.ToList();
			_groups = [];
			for (var i = 0; i < files.Count; i++)
			{
				var file = files[i];
				var key = file.RFolder + Path.DirectorySeparatorChar + file.Author;
				if (_groups.TryGetValue(key, out var g))
					g.Add(file);
				else
					_groups[key] = [file];
			}
			TreeGroup.Nodes.Clear();
			var nodes = new List<TreeNode>();
			foreach (var (author, group) in _groups)
			{
				if (group.Count < InpItemsInGroup.Value) continue;
				var node = new TreeNode(author + $" [{group.Count}]") { Tag = author };
				nodes.Add(node);
				foreach (var file in group)
					node.Nodes.Add(new TreeNode(file.SName) { Tag = file });
			}
			TreeGroup.Nodes.AddRange(nodes.ToArray());
		}

		private void InpItemsInGroup_ValueChanged(object sender, EventArgs e)
		{
			FindGroup();
		}

		private void TreeGroup_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			var node = e.Node;
			if (node.Tag is string group)
				_selectedGroup = group;
			else if (node.Tag is MusicFile file)
				_selectedGroup = file.RFolder + Path.DirectorySeparatorChar + file.Author;

			if (_selectedGroup == null) return;

			var author = _selectedGroup.Split(Path.DirectorySeparatorChar)[1];
			InpGroupName.Text = author;

			var fpath = Program.Settings.GetFullPath(author);
			var exist = Path.Exists(fpath);
			BtnMoveGroup.Enabled = !exist;
			LblGroupFolderExist.Visible = exist;
		}

		private void TreeGroup_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			var node = e.Node;
			if (node.Tag is MusicFile file)
				Utils.OpenExplorer(file.FPath);
		}

		private void BtnMoveGroup_Click(object sender, EventArgs e)
		{
			if (_selectedGroup == null) return;
			var author = _selectedGroup.Split(Path.DirectorySeparatorChar)[1];

			var fpath = Program.Settings.GetFullPath(author);
			var exist = Path.Exists(fpath);
			BtnMoveGroup.Enabled = !exist;
			LblGroupFolderExist.Visible = exist;
			if (exist) return;

			Directory.CreateDirectory(fpath);
			var group = _groups[_selectedGroup];
			foreach (var file in group)
				file.Move(Path.Combine(fpath, file.FName));

			InpGroupName.Text = "";
			_selectedGroup = null;
			BtnMoveGroup.Enabled = false;
			LblGroupFolderExist.Visible = false;
			FindGroup();
		}
	}
}

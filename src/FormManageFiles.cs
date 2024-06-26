using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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

		public FormManageFiles()
		{
			InitializeComponent();
		}

		private void FormManageFiles_Shown(object sender, EventArgs e)
		{
			FindProblems();
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
			BtnRename.Enabled = !exist;
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
	}
}

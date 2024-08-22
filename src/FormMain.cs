using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Melodorium
{
	public partial class FormMain : Form
	{
		private MusicFile? _selectedFile;

		public FormMain()
		{
			InitializeComponent();
			FilterMood.Items.Clear();
			FilterMood.Items.Add("Rock", true);
			FilterMood.Items.Add("Energistic", true);
			FilterMood.Items.Add("Calm", true);
			FilterMood.Items.Add("Sleep", true);
			FilterLike.Items.Clear();
			FilterLike.Items.Add("Best", true);
			FilterLike.Items.Add("Like", true);
			FilterLike.Items.Add("Good", true);
			FilterLang.Items.Clear();
			FilterLang.Items.Add("Wordless", true);
			FilterLang.Items.Add("Russian", true);
			FilterLang.Items.Add("Another", true);
			FilterLang.Items.Add("English", true);
			FilterLang.Items.Add("French", true);
			FilterLang.Items.Add("Italian", true);
			FilterHidden.SelectedIndex = 0;
			InpMood.Items.Clear();
			InpMood.Items.Add("Rock");
			InpMood.Items.Add("Energistic");
			InpMood.Items.Add("Calm");
			InpMood.Items.Add("Sleep");
			InpLike.Items.Clear();
			InpLike.Items.Add("Best");
			InpLike.Items.Add("Like");
			InpLike.Items.Add("Good");
			InpLang.Items.Clear();
			InpLang.Items.Add("Wordless");
			InpLang.Items.Add("Russian");
			InpLang.Items.Add("Another");
			InpLang.Items.Add("English");
			InpLang.Items.Add("French");
			InpLang.Items.Add("Italian");
		}

		private void FormMain_Shown(object sender, EventArgs e)
		{
			if (Program.Settings.RootFolder == "")
				OpenFolder();
			ShowMusicList();
		}

		private void BtnChangeFolder_Click(object sender, EventArgs e)
		{
			OpenFolder();
		}

		private void OpenFolder()
		{
			using var dialog = new FormOpenData();
			Hide();
			dialog.ShowDialog(this);
			Show();
			MusicData.LoadFull();
			ShowMusicList();
		}

		private void BtnExport_Click(object sender, EventArgs e)
		{
			var path = Program.MusicData.ExportData();
			if (path != "")
				Utils.OpenExplorer(path);
		}

		private void BtnManage_Click(object sender, EventArgs e)
		{
			using var dialog = new FormManageFiles();
			Hide();
			dialog.ShowDialog(this);
			Show();
			MusicData.LoadFull();
			ShowMusicList();
		}

		private void BtnFilter_Click(object sender, EventArgs e)
		{
			ShowMusicList();
		}

		private void ShowMusicList()
		{
			using var loadingDialog = new FormLoading();
			loadingDialog.Job = () =>
			{
				FilterAuthor.Text = FilterAuthor.Text.Trim();
				ListFiles.Items.Clear();
				var c = 0;
				foreach (var file in Program.MusicData.Files)
				{
					if (FilterUncategorized.Checked && file.Data.IsLoaded)
						continue;
					if (!FilterUncategorized.Checked && !file.Data.IsLoaded)
						continue;
					if (FilterAuthor.Text != "")
						if (!file.Author.Contains(FilterAuthor.Text, StringComparison.CurrentCultureIgnoreCase))
							continue;
					if (FilterHidden.SelectedIndex == 0)
						if (file.Data.Hidden) continue;
					if (FilterHidden.SelectedIndex == 2)
						if (!file.Data.Hidden) continue;
					if (!FilterMood.CheckedIndices.Contains((int)file.Data.Mood))
						continue;
					if (!FilterLike.CheckedIndices.Contains((int)file.Data.Like))
						continue;
					if (!FilterLang.CheckedIndices.Contains((int)file.Data.Lang))
						continue;
					ListFiles.Items.Add(new ListViewItem(file.RPath) { Tag = file });
					c++;
				}
				ListFiles.Columns[0].Text = $"Music [{c}]";
				loadingDialog.Close();
			};
			loadingDialog.ShowDialog(this);
		}

		private void ListFiles_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ListFiles.SelectedItems.Count == 0) return;
			var item = ListFiles.SelectedItems[0];
			if (item.Tag is not MusicFile file)
				return;
			_selectedFile = file;

			LblMusicAuthor.Text = file.Author.Replace("_", " ");
			LblMusicName.Text = file.SName == "" ? file.Name : file.SName.Replace("_", " ");
			InpMood.SelectedIndex = (int)file.Data.Mood;
			InpLike.SelectedIndex = (int)file.Data.Like;
			InpLang.SelectedIndex = (int)file.Data.Lang;
			InpHidden.Checked = file.Data.Hidden;
		}

		private void BtnSaveMusic_Click(object sender, EventArgs e)
		{
			if (_selectedFile == null) return;

			_selectedFile.Data.Mood = (MusicMood)InpMood.SelectedIndex;
			_selectedFile.Data.Like = (MusicLike)InpLike.SelectedIndex;
			_selectedFile.Data.Lang = (MusicLang)InpLang.SelectedIndex;
			_selectedFile.Data.Hidden = InpHidden.Checked;

			_selectedFile.Save();
		}
	}
}

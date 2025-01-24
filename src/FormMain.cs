using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Formats.Tar;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Melodorium
{
	public partial class FormMain : Form
	{
		private readonly AudioPlayer _audioPlayer = new();
		private List<MusicFile> _filteredFiles = [];
		private MusicFile? _selectedFile;
		private int? _selectedFileI;
		private bool _closing = false;
		private bool _updatingTime = false;
		private bool _metaChanged = false;
		private bool _metaDeleteImg = false;
		private string? _metaNewImg;

		public FormMain()
		{
			InitializeComponent();
			InpPlayerAtStartup.Checked = Program.Settings.OpenPlayerAtStartup;
			_audioPlayer.Volume = Program.Settings.Volume;
			InpVolume.Value = Program.Settings.Volume;
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
			FilterLang.Items.Add("German", true);
			FilterLang.Items.Add("Italian", true);
			FilterLang.Items.Add("Japanese", true);
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
			InpLang.Items.Add("German");
			InpLang.Items.Add("Italian");
			InpLang.Items.Add("Japanese");
		}

		public void CloseForm()
		{
			_closing = true;
			Close();
		}

		private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!Program.Player.WasOpened)
				_closing = true;
			
			if (!_closing)
			{
				e.Cancel = true;
				Hide();
				return;
			}
			_audioPlayer.Dispose();

			if (!Program.Player.WasOpened)
			{
				Program.App.CloseIcon();
				Program.Player.CloseForm();
				Application.Exit();
			}
		}

		private void FormMain_Shown(object sender, EventArgs e)
		{
			if (Program.Settings.RootFolder == "")
				OpenFolder();
			else
				UpdateMusicFull();
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
			UpdateMusicFull();
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
			UpdateMusicFull();
		}

		private void UpdateMusicFull()
		{
			using var loadingDialog = new FormLoading();
			loadingDialog.Job = () =>
			{
				var c = 0;
				MusicData.LoadFull(() => { if (++c % 100 == 0) loadingDialog.SetInfo($"{c} files"); });
				UpdateUI();
				ShowMusicList();
				ListFiles.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
				loadingDialog.Close();
			};
			loadingDialog.ShowDialog(this);
		}

		private void BtnSync_Click(object sender, EventArgs e)
		{
			using var dialog = new FormSync();
			Hide();
			dialog.ShowDialog(this);
			Show();
		}

		private void BtnFilter_Click(object sender, EventArgs e)
		{
			ShowMusicList();
		}

		private void BtnResetFilter_Click(object sender, EventArgs e)
		{
			FilterUncategorized.Checked = false;
			FilterAuthor.Text = "";
			FilterName.Text = "";
			FilterHidden.SelectedIndex = 0;
			FilterTags.SelectedIndex = 0;
			for (int i = 0; i < FilterMood.Items.Count; i++)
				FilterMood.SetItemChecked(i, true);
			for (int i = 0; i < FilterLike.Items.Count; i++)
				FilterLike.SetItemChecked(i, true);
			for (int i = 0; i < FilterLang.Items.Count; i++)
				FilterLang.SetItemChecked(i, true);
		}

		private void ShowMusicList()
		{
			using var loadingDialog = new FormLoading();
			loadingDialog.Job = () =>
			{
				FilterAuthor.Text = FilterAuthor.Text.Trim();
				FilterName.Text = FilterName.Text.Trim();
				var author = FilterAuthor.Text.Replace(" ", "_");
				var name = FilterName.Text.Replace(" ", "_");
				ListFiles.Items.Clear();
				_selectedFileI = null;
				_filteredFiles = [];
				var c = 0;
				foreach (var file in Program.MusicData.Files)
				{
					if (FilterUncategorized.Checked && file.Data.IsLoaded)
						continue;
					if (!FilterUncategorized.Checked && !file.Data.IsLoaded)
						continue;
					if (author != "")
						if (!file.Author.Contains(author, StringComparison.CurrentCultureIgnoreCase))
							continue;
					if (name != "")
						if (!(file.Name != "" ? file.Name : file.FName)
								.Contains(name, StringComparison.CurrentCultureIgnoreCase))
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
					if (FilterTags.SelectedIndex == 1)
						if (file.Data.Tag != "") continue;
					if (FilterTags.SelectedIndex > 1)
						if (file.Data.Tag != Program.MusicData.Tags[FilterTags.SelectedIndex - 2]) continue;

					var tags = "";
					if (file.Data.IsLoaded)
					{
						tags += " [";
						tags += file.Data.Mood.ToString()[..2] + ";";
						tags += file.Data.Like.ToString()[..2] + ";";
						tags += file.Data.Lang.ToString()[..2] + "]";
					}
					_filteredFiles.Add(file);
					ListFiles.Items.Add(new ListViewItem(file.RPath + tags) { Tag = file });
					c++;
				}
				ListFiles.Columns[0].Text = $"Music [{c}]";
				loadingDialog.Close();
			};
			loadingDialog.ShowDialog(this);
		}

		private void UpdateUI(bool updateData = false)
		{
			var selectedTagI = FilterTags.SelectedIndex;
			var selectedTag = selectedTagI >= 2 ? Program.MusicData.Tags[FilterTags.SelectedIndex - 2] : "";
			if (updateData)
				Program.MusicData.UpdateTagsList();
			FilterTags.Items.Clear();
			FilterTags.Items.Add("<any>");
			FilterTags.Items.Add("<no tag>");
			var selectI = 0;
			for (int i = 0; i < Program.MusicData.Tags.Count; i++)
			{
				var tag = Program.MusicData.Tags[i];
				if (tag == selectedTag)
					selectI = i;
				FilterTags.Items.Add(tag);
			}
			FilterTags.SelectedIndex = selectedTagI >= 2 ? selectI : selectedTagI;
			if (FilterTags.SelectedIndex < 0) FilterTags.SelectedIndex = 0;

			InpTags.Items.Clear();
			foreach (var tag in Program.MusicData.Tags)
				InpTags.Items.Add(tag);

			var di = new DirectoryInfo(Program.Settings.RootFolder);
			InpCopyFolder.Text = di.Root.FullName;

			if (Program.Settings.ExportFolder == "")
				InpExportFolder.Text = "." + Path.DirectorySeparatorChar;
			else
				if (Utils.IsPathInsideFolder(Program.Settings.ExportFolder, Program.Settings.RootFolder))
			{
				InpExportRel.Checked = true;
				var rel = Path.GetRelativePath(Program.Settings.RootFolder, Program.Settings.ExportFolder);
				InpExportFolder.Text = "." + Path.DirectorySeparatorChar;
				if (rel != ".")
					InpExportFolder.Text += rel;
			}
			else
			{
				InpExportRel.Checked = false;
				InpExportFolder.Text = Program.Settings.ExportFolder;
			}
		}

		private void ListFiles_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ListFiles.SelectedItems.Count == 0) return;
			var item = ListFiles.SelectedItems[0];
			if (item.Tag is not MusicFile file)
				return;
			_selectedFile = file;
			_selectedFileI = ListFiles.SelectedIndices[0];
			file.LoadMeta();
			_metaChanged = false;
			_metaDeleteImg = false;

			LblMusicAuthor.Text = file.Author.Replace("_", " ");
			LblMusicName.Text = file.SName == "" ? file.Name : file.SName.Replace("_", " ");
			InpMood.SelectedIndex = file.Data.IsLoaded ? (int)file.Data.Mood : -1;
			InpLike.SelectedIndex = file.Data.IsLoaded ? (int)file.Data.Like : -1;
			InpLang.SelectedIndex = file.Data.IsLoaded ? (int)file.Data.Lang : -1;
			InpHidden.Checked = file.Data.Hidden;
			InpTags.Text = file.Data.Tag;
			InpTitle.Text = file.Title;
			InpAlbum.Text = file.Album;
			InpArtists.Text = string.Join(";", file.Artists);
			if (file.Picture != null)
			{
				PBMusicImage.Image?.Dispose();
				var ms = new MemoryStream(file.Picture.Data.Data);
				PBMusicImage.Image = Image.FromStream(ms);
				BtnDeleteImage.Enabled = true;
			}
			else
			{
				PBMusicImage.Image?.Dispose();
				PBMusicImage.Image = null;
				BtnDeleteImage.Enabled = false;
			}
			LblState.Text = "";
			LblTime.Text = $"00:00/{file.Duration:mm\\:ss}";

			if (InpAutoplay.Checked)
				PlayMusic();
		}

		private void BtnSaveMusic_Click(object sender, EventArgs e)
		{
			if (_selectedFile == null) return;

			var err = "";
			if (InpMood.SelectedIndex < 0)
				err = "Mood";
			else if (InpLike.SelectedIndex < 0)
				err = "Like";
			else if (InpLang.SelectedIndex < 0)
				err = "Lang";
			if (err != "")
			{
				MessageBox.Show($"{err} not selected", "Saving music data");
				return;
			}

			_selectedFile.Data.Mood = (MusicMood)InpMood.SelectedIndex;
			_selectedFile.Data.Like = (MusicLike)InpLike.SelectedIndex;
			_selectedFile.Data.Lang = (MusicLang)InpLang.SelectedIndex;
			_selectedFile.Data.Hidden = InpHidden.Checked;
			_selectedFile.Data.Tag = InpTags.Text;

			_selectedFile.Save();

			if (_metaChanged)
			{
				_metaChanged = false;
				bool musicPlaying = _audioPlayer.IsPlaying;
				TimeSpan curTime = _audioPlayer.TimeCurrent;
				_audioPlayer.Stop();
				_selectedFile.Title = InpTitle.Text;
				_selectedFile.Album = InpAlbum.Text;
				_selectedFile.Artists = InpArtists.Text.Split(";");
				if (_metaDeleteImg)
				{
					_metaDeleteImg = false;
					_selectedFile.Picture = null;
				}
				if (_metaNewImg != null)
				{
					_selectedFile.Picture = new TagLib.Picture(_metaNewImg);
				}
				_selectedFile.SaveMeta();
				if (musicPlaying)
				{
					PlayMusic();
					_audioPlayer.TimeCurrent = curTime;
				}
			}
			LblState.Text = "Saved";

			var tags = " [";
			tags += _selectedFile.Data.Mood.ToString()[..2] + ";";
			tags += _selectedFile.Data.Like.ToString()[..2] + ";";
			tags += _selectedFile.Data.Lang.ToString()[..2] + "]";
			if (_selectedFileI != null)
				ListFiles.Items[_selectedFileI.Value].Text = _selectedFile.RPath + tags;
			UpdateUI(updateData: true);
		}

		private void BtnPlay_Click(object sender, EventArgs e)
		{
			PlayMusic();
		}

		private void PlayMusic()
		{
			if (_selectedFile == null) return;

			var plaiyng = _audioPlayer.PlayPause(_selectedFile);
			LblTime.Text = _audioPlayer.PlaytimeDisplay;
			BtnPlay.Text = plaiyng ? "Pause" : "Play";
		}

		private void BtnStop_Click(object sender, EventArgs e)
		{
			_audioPlayer.Stop();
			BtnPlay.Text = "Play";
		}

		private void InpVolume_VolumeChanged(object sender, EventArgs e)
		{
			Program.Settings.Volume = (float)InpVolume.Value;
			Program.Settings.Save();
			_audioPlayer.Volume = Program.Settings.Volume;
		}

		private void InpMusicTime_ValueChanged(object sender, EventArgs e)
		{
			if (_updatingTime) return;
			_audioPlayer.TimeNormalized = InpMusicTime.Value / 100f;
			LblTime.Text = _audioPlayer.PlaytimeDisplay;
		}

		private void MusicTimer_Tick(object sender, EventArgs e)
		{
			if (_selectedFile == null) return;
			_updatingTime = true;
			InpMusicTime.Value = (int)(_audioPlayer.TimeNormalized * 100);
			LblTime.Text = $"{_audioPlayer.CurtimeDisplay}/{_selectedFile.Duration:mm\\:ss}";
			_updatingTime = false;
		}

		private void InpMood_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_selectedFile == null) return;
			LblState.Text = "Unsaved";
		}

		private void InpLike_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_selectedFile == null) return;
			LblState.Text = "Unsaved";
		}

		private void InpLang_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_selectedFile == null) return;
			LblState.Text = "Unsaved";
		}

		private void InpHidden_CheckedChanged(object sender, EventArgs e)
		{
			if (_selectedFile == null) return;
			LblState.Text = "Unsaved";
		}

		private void InpTitle_TextChanged(object sender, EventArgs e)
		{
			if (_selectedFile == null) return;
			_metaChanged = true;
			LblState.Text = "Unsaved";
		}

		private void InpArtists_TextChanged(object sender, EventArgs e)
		{
			if (_selectedFile == null) return;
			_metaChanged = true;
			LblState.Text = "Unsaved";
		}

		private void InpAlbum_TextChanged(object sender, EventArgs e)
		{
			if (_selectedFile == null) return;
			_metaChanged = true;
			LblState.Text = "Unsaved";
		}

		private void BtnDeleteImage_Click(object sender, EventArgs e)
		{
			if (_selectedFile == null) return;
			if (_selectedFile.Picture == null && _metaNewImg == null) return;
			BtnDeleteImage.Enabled = false;
			_metaChanged = true;
			_metaDeleteImg = true;
			_metaNewImg = null;
			PBMusicImage.Image?.Dispose();
			PBMusicImage.Image = null;
			LblState.Text = "Unsaved";
		}

		private void PBMusicImage_Click(object sender, EventArgs e)
		{
			if (_selectedFile == null) return;
			using var dialog = new FormImage(_selectedFile, PBMusicImage.Image);
			dialog.ShowDialog(this);
			if (dialog.NewImage != null)
			{
				BtnDeleteImage.Enabled = true;
				PBMusicImage.Image = dialog.Image;
				_metaNewImg = dialog.NewImage;
				LblState.Text = "Unsaved";
			}
		}

		private void InpTags_TextChanged(object sender, EventArgs e)
		{
			if (_selectedFile == null) return;
			LblState.Text = "Unsaved";
		}

		private void BtnExportPlaylist_Click(object sender, EventArgs e)
		{
			ShowMusicList();

			var rel = InpExportRel.Checked;
			var name = GetPlaylistName();
			var exportFolder = GetExportFolder(InpExportFolder.Text);
			if (InpExportRel.Checked && !Utils.IsPathInsideFolder(exportFolder, Program.Settings.RootFolder))
			{
				MessageBox.Show("Selected export folder is not relative to root", "Export playlist", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			Program.Settings.ExportFolder = exportFolder;
			Program.Settings.Save();

			var path = Utils.GetFreeFileName(Path.Join(exportFolder, name), ".m3u8", relative: false);
			try
			{
				if (!Directory.Exists(exportFolder))
					Directory.CreateDirectory(exportFolder);
			}
			catch (UnauthorizedAccessException)
			{
				MessageBox.Show("Access denied to selected export folder", "Export playlist", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			catch
			{
				MessageBox.Show("Cant create file", "Export playlist", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			using var loadingDialog = new FormLoading();
			loadingDialog.Job = () =>
			{
				using var f = File.CreateText(path);
				f.WriteLine("#EXTM3U");
				for (int i = 0; i < _filteredFiles.Count; i++)
				{
					loadingDialog.SetProgress((float)i / _filteredFiles.Count);
					var file = _filteredFiles[i];
					file.LoadMeta();
					var line = "#EXTINF:";
					line += (int)file.Duration.TotalSeconds + ",";
					var author = file.Artists.Length > 0 ? file.Artists[0] : file.Author.Replace("_", " ");
					var title = file.Title != "" ? file.Title : file.SName.Replace("_", " ");
					if (author != "" && title != "")
						line += author + " - " + title;
					else
						line += file.Name.Replace("_", " ");
					f.WriteLine(line);
					f.WriteLine(rel ? file.RPath : file.FPath);
				}
				Utils.OpenExplorer(path);
				loadingDialog.Close();
			};
			loadingDialog.ShowDialog(this);
		}

		private string GetPlaylistName()
		{
			var name = "";
			if (FilterAuthor.Text != "" && FilterName.Text != "")
				name += $"{FilterAuthor.Text.Replace(" ", "_")}_-_{FilterName.Text.Replace(" ", "_")}";
			else if (FilterAuthor.Text != "")
				name += FilterAuthor.Text.Replace(" ", "_");
			else if (FilterName.Text != "")
				name += FilterName.Text.Replace(" ", "_");

			if (FilterUncategorized.Checked)
				if (name != "")
					return name;
				else
					return "Melodoruim";

			var opt = "";
			var mood = "";
			var moodAll = true;
			for (int i = 0; i < FilterMood.Items.Count; i++)
				if (FilterMood.GetItemChecked(i))
					mood += ((MusicMood)i).ToString()[..2];
				else
					moodAll = false;
			if (!moodAll)
				opt += mood;

			var like = "";
			var likeAll = true;
			for (int i = 0; i < FilterLike.Items.Count; i++)
				if (FilterLike.GetItemChecked(i))
					like += ((MusicLike)i).ToString()[..2];
				else
					likeAll = false;
			if (!likeAll)
			{
				if (opt != "")
					opt += "_";
				opt += like;
			}

			var lang = "";
			var langAll = true;
			for (int i = 0; i < FilterLang.Items.Count; i++)
				if (FilterLang.GetItemChecked(i))
					lang += ((MusicLang)i).ToString()[..2];
				else
					langAll = false;
			if (!langAll)
			{
				if (opt != "")
					opt += "_";
				opt += lang;
			}

			if (FilterTags.SelectedIndex >= 2)
			{
				if (opt != "")
					opt += "_";
				var tag = Program.MusicData.Tags[FilterTags.SelectedIndex - 2].Replace(" ", "_");
				opt += Utils.RemoveInvalidFileNameChars(tag);
			}
			if (FilterHidden.SelectedIndex == 1)
			{
				if (opt != "")
					opt += "_";
				opt += "all";
			}
			if (FilterHidden.SelectedIndex == 2)
			{
				if (opt != "")
					opt += "_";
				opt += "hidden";
			}
			if (name != "" && opt != "")
				return name + "_-_" + opt;
			if (name != "")
				return name;
			if (opt != "")
				return opt;
			return "Melodoruim";
		}

		private static string GetExportFolder(string selectedFolder)
		{
			if (selectedFolder.StartsWith("." + Path.DirectorySeparatorChar))
				return Program.Settings.GetFullPath(selectedFolder[2..]);
			if (selectedFolder.StartsWith('.'))
				return Program.Settings.GetFullPath(selectedFolder[1..]);
			if (selectedFolder == "")
				return Program.Settings.RootFolder;
			if (selectedFolder[1..].StartsWith(":" + Path.DirectorySeparatorChar))
				return selectedFolder;
			return Program.Settings.GetFullPath(selectedFolder);
		}

		private void BtnExportHelp_Click(object sender, EventArgs e)
		{
			MessageBox.Show("""
				relative:
					- you can move root music folder
					- you can not move playlist file
				not relative:
					- you can not move root music folder
					- you can move playlist file
				""", "Relatice playlist");
		}

		private void InpExportRel_CheckedChanged(object sender, EventArgs e)
		{
			var folder = GetExportFolder(InpExportFolder.Text);
			if (InpExportRel.Checked)
				if (Utils.IsPathInsideFolder(folder, Program.Settings.RootFolder))
				{
					var rel = Path.GetRelativePath(Program.Settings.RootFolder, folder);
					InpExportFolder.Text = "." + Path.DirectorySeparatorChar;
					if (rel != ".")
						InpExportFolder.Text += rel;
				}
				else
				{
					InpExportFolder.Text = "." + Path.DirectorySeparatorChar;
				}
			else
				InpExportFolder.Text = folder;
		}

		private void BtnSelectExportFolder_Click(object sender, EventArgs e)
		{
			FolderBrowser.InitialDirectory = GetExportFolder(InpExportFolder.Text);
			FolderBrowser.SelectedPath = FolderBrowser.InitialDirectory;
			if (FolderBrowser.ShowDialog() != DialogResult.OK)
				return;
			if (InpExportRel.Checked)
			{
				if (!Utils.IsPathInsideFolder(FolderBrowser.SelectedPath, Program.Settings.RootFolder))
				{
					MessageBox.Show("You cant export outside of the root music folder because the relative path is enabled");
					return;
				}
				var rel = Path.GetRelativePath(Program.Settings.RootFolder, FolderBrowser.SelectedPath);
				InpExportFolder.Text = "." + Path.DirectorySeparatorChar;
				if (rel != ".")
					InpExportFolder.Text += rel;
			}
			else
			{
				InpExportFolder.Text = FolderBrowser.SelectedPath;
			}
		}

		private void BtnSelectCopyFolder_Click(object sender, EventArgs e)
		{
			FolderBrowser.InitialDirectory = InpCopyFolder.Text;
			FolderBrowser.SelectedPath = InpCopyFolder.Text;
			if (FolderBrowser.ShowDialog() != DialogResult.OK)
				return;
			InpCopyFolder.Text = FolderBrowser.SelectedPath;
		}

		private void BtnCopyPlaylist_Click(object sender, EventArgs e)
		{
			ShowMusicList();

			var name = GetPlaylistName();
			var folder = Utils.GetFreeDirectoryName(Path.Join(InpCopyFolder.Text, name), relative: false);
			try
			{
				Directory.CreateDirectory(folder);
			}
			catch (UnauthorizedAccessException)
			{
				MessageBox.Show("Access denied to selected export folder", "Copy playlist", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			catch
			{
				MessageBox.Show("Cant create folder", "Copy playlist", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			var diRoot = new DirectoryInfo(Program.Settings.RootFolder);
			var diDest = new DirectoryInfo(folder);
			var useHardLink = diDest.Root.FullName == diRoot.Root.FullName;

			using var loadingDialog = new FormLoading();
			loadingDialog.EnableCancel();
			loadingDialog.Job = () =>
			{
				for (int i = 0; i < _filteredFiles.Count; i++)
				{
					loadingDialog.SetProgress((float)i / _filteredFiles.Count);
					if (loadingDialog.Canceled)
						break;

					var file = _filteredFiles[i];
					var path = Path.Combine(folder, file.FName);
					if (Path.Exists(path))
						path = Path.Combine(folder, file.Name + $" ({file.RFolder.Replace(Path.DirectorySeparatorChar, '-')})" + file.Ext);
					var success = useHardLink && HardLink.Create(path, file.FPath);
					if (!success)
						File.Copy(file.FPath, path);
				}
				Utils.OpenExplorer(folder);
				loadingDialog.Close();
			};
			loadingDialog.ShowDialog(this);
		}

		private void BtnSpExport_Click(object sender, EventArgs e)
		{
			using var dialog = new FormSpExport();
			dialog.ShowDialog(this);
		}

		private void BtnPlayer_Click(object sender, EventArgs e)
		{
			Program.Player.Show();
			Program.Player.Activate();
		}

		private void InpPlayerAtStartup_CheckedChanged(object sender, EventArgs e)
		{
			Program.Settings.OpenPlayerAtStartup = InpPlayerAtStartup.Checked;
			Program.Settings.Save();
		}

		private void ListFilesMenuItem_Add_Click(object sender, EventArgs e)
		{
			AddSelectedToPlaylist();
		}

		private void ListFilesMenuItem_AddRnd_Click(object sender, EventArgs e)
		{
			AddSelectedToPlaylist(randomize: false);
		}

		private void AddSelectedToPlaylist(bool randomize = false)
		{
			var files = ListFiles.SelectedItems.Cast<ListViewItem>().Select(v => v.Tag as MusicFile).ToList();
			if (randomize)
				files.Shuffle();
			foreach (var file in files)
			{
				Debug.Assert(file != null);
				Program.Player.AddTrackToPlaylist(file);
			}
		}

		private void ListFilesMenuItem_AddAll_Click(object sender, EventArgs e)
		{
			foreach (var file in _filteredFiles)
			{
				Program.Player.AddTrackToPlaylist(file);
			}
		}
	}
}
 
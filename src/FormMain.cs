﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
		private bool _updatingValues = true;
		private bool _updatingTime = false;
		private bool _metaChanged = false;
		private bool _metaDeleteImg = false;
		private string? _metaNewImg;

		public ReadOnlyCollection<MusicFile> FilteredFiles { get => _filteredFiles.AsReadOnly(); }

		public FormMain()
		{
			InitializeComponent();
			TrayIcon.Text = "Melodorium v1.0";
			InpAutoApply.Checked = Program.Settings.AutoApply;
			_audioPlayer.Volume = Program.Settings.Volume;
			_audioPlayer.TrackEnded += (object? sender, EventArgs e) =>
			{
				PlayMusic();
			};
			InpVolume.Value = Program.Settings.Volume;
			FilterMood.Items.Clear();
			FilterMood.Items.Add("Rock", true);
			FilterMood.Items.Add("Energistic", true);
			FilterMood.Items.Add("Cheerful", true);
			FilterMood.Items.Add("Calm", true);
			FilterMood.Items.Add("Sleep", true);
			FilterLike.Items.Clear();
			FilterLike.Items.Add("Best", true);
			FilterLike.Items.Add("Like", true);
			FilterLike.Items.Add("Good", true);
			FilterLike.Items.Add("Normal", true);
			FilterLike.Items.Add("------", CheckState.Indeterminate);
			FilterLike.Items.Add("Happy", true);
			FilterLike.Items.Add("Neutral", true);
			FilterLike.Items.Add("Sad", true);
			FilterLang.Items.Clear();
			FilterLang.Items.Add("Wordless", true);
			FilterLang.Items.Add("Russian", true);
			FilterLang.Items.Add("Another", true);
			FilterLang.Items.Add("English", true);
			FilterLang.Items.Add("French", true);
			FilterLang.Items.Add("German", true);
			FilterLang.Items.Add("Italian", true);
			FilterLang.Items.Add("Asian", true);
			FilterHidden.SelectedIndex = 0;
			InpMood.Items.Clear();
			InpMood.Items.Add("Rock");
			InpMood.Items.Add("Energistic");
			InpMood.Items.Add("Cheerful");
			InpMood.Items.Add("Calm");
			InpMood.Items.Add("Sleep");
			InpLike.Items.Clear();
			InpLike.Items.Add("Best");
			InpLike.Items.Add("Like");
			InpLike.Items.Add("Good");
			InpLike.Items.Add("Normal");
			InpLang.Items.Clear();
			InpLang.Items.Add("Wordless");
			InpLang.Items.Add("Russian");
			InpLang.Items.Add("Another");
			InpLang.Items.Add("English");
			InpLang.Items.Add("French");
			InpLang.Items.Add("German");
			InpLang.Items.Add("Italian");
			InpLang.Items.Add("Asian");
			InpEmo.Items.Clear();
			InpEmo.Items.Add("Happy");
			InpEmo.Items.Add("Neutral");
			InpEmo.Items.Add("Sad");
			_updatingValues = false;
		}

		public void CloseForm()
		{
			_closing = true;
			Close();
		}

		public void ShowBalloonTip(string text, ToolTipIcon icon)
		{
			TrayIcon.ShowBalloonTip(500, "Melodorium", text, icon);
		}

		private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!Program.Player.WasOpened)
			{
				Program.Player.CloseForm();
				_closing = true;
			}

			if (!_closing)
			{
				e.Cancel = true;
				Hide();
				return;
			}
			_audioPlayer.Dispose();
		}

		private void FormMain_Shown(object sender, EventArgs e)
		{
			if (Program.Settings.RootFolder == "")
				OpenFolder();
			else
				UpdateMusicFull();
		}

		private void TrayIcon_Click(object sender, EventArgs e)
		{
			if (e is MouseEventArgs me && me.Button == MouseButtons.Left)
			{
				Program.Player.Show();
				Program.Player.Activate();
			}
		}

		private void TrayIconMenuItem_Player_Click(object sender, EventArgs e)
		{
			Program.Player.Show();
			Program.Player.Activate();
		}

		private void TrayIconMenuItem_Manager_Click(object sender, EventArgs e)
		{
			Show();
			Activate();
		}

		private void TrayIconMenuItem_Exit_Click(object sender, EventArgs e)
		{
			Program.Player.CloseForm();
			CloseForm();
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
				Program.Player.ClearPlaylist(save: false);
				Program.Player.AddTracksToPlaylist(
					Program.MusicData.Playlist
					.Select(v => Program.MusicData.Files.Find(file => file.RPath == v))
					.WhereNotNull()
					);
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

		private void FilterMood_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (_updatingValues) return;
			if (!Program.Settings.AutoApply) return;
			BeginInvoke((MethodInvoker)(() => ShowMusicList()));
		}

		private void FilterLike_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (_updatingValues) return;
			if (!Program.Settings.AutoApply) return;
			if (e.Index == 4)
			{
				e.NewValue = e.CurrentValue;
				return;
			}
			BeginInvoke((MethodInvoker)(() => ShowMusicList()));
		}

		private void FilterLang_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (_updatingValues) return;
			if (!Program.Settings.AutoApply) return;
			BeginInvoke((MethodInvoker)(() => ShowMusicList()));
		}

		private void FilterTags_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (_updatingValues) return;
			if (!Program.Settings.AutoApply) return;
			BeginInvoke((MethodInvoker)(() => ShowMusicList()));
		}

		private void FilterAuthor_TextChanged(object sender, EventArgs e)
		{
			if (_updatingValues) return;
			if (!Program.Settings.AutoApply) return;
			ShowMusicList();
		}

		private void FilterName_TextChanged(object sender, EventArgs e)
		{
			if (_updatingValues) return;
			if (!Program.Settings.AutoApply) return;
			ShowMusicList();
		}

		private void FilterHidden_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_updatingValues) return;
			if (!Program.Settings.AutoApply) return;
			ShowMusicList();
		}

		private void FilterUncategorized_CheckedChanged(object sender, EventArgs e)
		{
			if (_updatingValues) return;
			if (!Program.Settings.AutoApply) return;
			ShowMusicList();
		}

		private void BtnFilter_Click(object sender, EventArgs e)
		{
			ShowMusicList();
		}

		private void InpAutoApply_CheckedChanged(object sender, EventArgs e)
		{
			if (_updatingValues) return;
			Program.Settings.AutoApply = InpAutoApply.Checked;
			Program.Settings.Save();
		}

		private void BtnResetFilter_Click(object sender, EventArgs e)
		{
			_updatingValues = true;
			FilterUncategorized.Checked = false;
			FilterAuthor.Text = "";
			FilterName.Text = "";
			FilterHidden.SelectedIndex = 0;
			for (int i = 0; i < FilterMood.Items.Count; i++)
				FilterMood.SetItemChecked(i, true);
			for (int i = 0; i < FilterLike.Items.Count; i++)
				FilterLike.SetItemChecked(i, true);
			FilterLike.SetItemCheckState(4, CheckState.Indeterminate);
			for (int i = 0; i < FilterLang.Items.Count; i++)
				FilterLang.SetItemChecked(i, true);
			for (int i = 0; i < FilterTags.Items.Count; i++)
				FilterTags.SetItemChecked(i, true);
			_updatingValues = false;
			if (Program.Settings.AutoApply) ShowMusicList();
		}

		private void ShowMusicList()
		{
			_updatingValues = true;
			FilterAuthor.Text = FilterAuthor.Text.Trim();
			FilterName.Text = FilterName.Text.Trim();
			_updatingValues = false;
			var author = FilterAuthor.Text.Replace(" ", "_");
			var name = FilterName.Text.Replace(" ", "_");
			var selectedTags = FilterTags.CheckedItems.Cast<object>().Where(v => v is string).Cast<string>().ToList();
			var noTagSelected = FilterTags.GetItemChecked(0);
			ListFiles.Items.Clear();
			var items = new List<ListViewItem>();
			_selectedFileI = null;
			_filteredFiles = [];
			var c = 0;
			for (int i = 0; i < Program.MusicData.Files.Count; i++)
			{
				var file = Program.MusicData.Files[i];
				if (FilterUncategorized.Checked && file.Data.IsLoaded)
					continue;
				if (!FilterUncategorized.Checked && !file.Data.IsLoaded)
					continue;
				if (author != "")
					if (!file.Author.Contains(author, StringComparison.CurrentCultureIgnoreCase))
						continue;
				if (name != "")
					if (!(file.SName != "" ? file.SName : file.Name)
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
				if (!FilterLike.CheckedIndices.Contains((int)file.Data.Emo + 5))
					continue;
				if (!FilterLang.CheckedIndices.Contains((int)file.Data.Lang))
					continue;
				if (file.Data.Tag == "")
				{
					if (!noTagSelected)
						continue;
				}
				else
				{
					var tags = file.Data.Tag.Split(";");
					if (!tags.Any(selectedTags.Contains))
						continue;
				}

				_filteredFiles.Add(file);
				var item = new ListViewItem(file.RPath + file.Tags) { Tag = file };
				items.Add(item);
				if (_selectedFile == file)
				{
					_selectedFileI = i;
					item.Selected = true;
				}
				c++;
			}
			ListFiles.Items.AddRange(items.ToArray());
			ListFiles.Columns[0].Text = $"Music [{c}]";
			ListFiles.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
		}

		private void UpdateUI(bool updateData = false)
		{
			_updatingValues = true;
			if (updateData)
				Program.MusicData.UpdateTagsList();

			var tagsFilter = new Dictionary<string, bool>();
			for (int i = 0; i < FilterTags.Items.Count; i++)
				if (FilterTags.Items[i] is string item)
					tagsFilter[item] = FilterTags.GetItemChecked(i);

			FilterTags.Items.Clear();
			for (int i = -1; i < Program.MusicData.Tags.Count; i++)
			{
				var tag = i == -1 ? "<no tag>" : Program.MusicData.Tags[i];
				FilterTags.Items.Add(tag);
				if (!tagsFilter.TryGetValue(tag, out var check))
					check = true;
				FilterTags.SetItemChecked(i + 1, check);
			}

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
			_updatingValues = false;
		}

		private void ListFiles_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_updatingValues) return;
			if (ListFiles.SelectedItems.Count == 0) return;
			var item = ListFiles.SelectedItems[0];
			if (item.Tag is not MusicFile file)
				return;
			_selectedFile = file;
			_selectedFileI = ListFiles.SelectedIndices[0];
			file.LoadMeta();

			LblMusicAuthor.Text = file.Author.Replace("_", " ");
			LblMusicName.Text = file.SName.Replace("_", " ");
			InpMood.SelectedIndex = file.Data.IsLoaded ? (int)file.Data.Mood : -1;
			InpLike.SelectedIndex = file.Data.IsLoaded ? (int)file.Data.Like : -1;
			InpLang.SelectedIndex = file.Data.IsLoaded ? (int)file.Data.Lang : -1;
			InpEmo.SelectedIndex = file.Data.IsLoaded ? (int)file.Data.Emo : -1;
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

			_metaChanged = false;
			_metaDeleteImg = false;

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
			else if (InpEmo.SelectedIndex < 0)
				err = "Emo";
			if (err != "")
			{
				MessageBox.Show($"{err} not selected", "Saving music data");
				return;
			}

			_selectedFile.Data.Mood = (MusicMood)InpMood.SelectedIndex;
			_selectedFile.Data.Like = (MusicLike)InpLike.SelectedIndex;
			_selectedFile.Data.Lang = (MusicLang)InpLang.SelectedIndex;
			_selectedFile.Data.Emo = (MusicEmo)InpEmo.SelectedIndex;
			_selectedFile.Data.Hidden = InpHidden.Checked;
			_selectedFile.Data.Tag = InpTags.Text.Trim();

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
					_metaNewImg = null;
				}
				_selectedFile.SaveMeta();
				if (musicPlaying)
				{
					PlayMusic();
					_audioPlayer.TimeCurrent = curTime;
				}
			}
			LblState.Text = "Saved";

			if (_selectedFileI != null)
				ListFiles.Items[_selectedFileI.Value].Text = _selectedFile.RPath + _selectedFile.Tags;
			UpdateUI(updateData: true);
		}

		private void BtnPlay_Click(object sender, EventArgs e)
		{
			PlayMusic(toggle: true);
		}

		private void PlayMusic(bool toggle = false)
		{
			if (_selectedFile == null) return;

			if (toggle) _audioPlayer.PlayPause(_selectedFile);
			else _audioPlayer.Play(_selectedFile);
			LblTime.Text = _audioPlayer.PlaytimeDisplay;
			BtnPlay.Text = _audioPlayer.IsPlaying ? "Pause" : "Play";
		}

		private void BtnStop_Click(object sender, EventArgs e)
		{
			_audioPlayer.Stop();
			BtnPlay.Text = "Play";
		}

		private void BtnPrev_Click(object sender, EventArgs e)
		{
			if (_selectedFileI == null) return;
			if (_selectedFileI - 1 >= 0)
			{
				_updatingValues = true;
				foreach (ListViewItem item in ListFiles.SelectedItems)
					item.Selected = false;
				_updatingValues = false;
				ListFiles.EnsureVisible(_selectedFileI.Value - 1);
				ListFiles.Items[_selectedFileI.Value - 1].Selected = true;
			}
		}

		private void BtnNext_Click(object sender, EventArgs e)
		{
			if (_selectedFileI == null) return;
			if (_selectedFileI + 1 < _filteredFiles.Count)
			{
				_updatingValues = true;
				foreach (ListViewItem item in ListFiles.SelectedItems)
					item.Selected = false;
				_updatingValues = false;
				ListFiles.EnsureVisible(_selectedFileI.Value + 1);
				ListFiles.Items[_selectedFileI.Value + 1].Selected = true;
			}
		}

		private void BtnTime1_Click(object sender, EventArgs e)
		{
			if (!_audioPlayer.IsPlaying) return;
			_audioPlayer.TimeNormalized = 0.25;
			UpdateTimeDisplay();
		}

		private void BtnTime2_Click(object sender, EventArgs e)
		{
			if (!_audioPlayer.IsPlaying) return;
			_audioPlayer.TimeNormalized = 0.5;
			UpdateTimeDisplay();
		}

		private void BtnTime3_Click(object sender, EventArgs e)
		{
			if (!_audioPlayer.IsPlaying) return;
			_audioPlayer.TimeNormalized = 0.75;
			UpdateTimeDisplay();
		}

		private void InpVolume_VolumeChanged(object sender, EventArgs e)
		{
			if (_updatingValues) return;
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
			UpdateTimeDisplay();
		}

		private void UpdateTimeDisplay()
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

		private void InpEmo_SelectedIndexChanged(object sender, EventArgs e)
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
				_metaChanged = true;
				LblState.Text = "Unsaved";
			}
		}

		private void InpTags_TextChanged(object sender, EventArgs e)
		{
			if (_selectedFile == null) return;
			LblState.Text = "Unsaved";
			if (InpTags.Text.Length > 0 && InpTags.Text[InpTags.Text.Length - 1] == ';')
			{
				var selected = InpTags.Text.Split(";");
				InpTags.Items.Clear();
				foreach (var tag in Program.MusicData.Tags)
					if (!selected.Contains(tag))
						InpTags.Items.Add(InpTags.Text + tag);
			}
		}

		private void BtnExportPlaylist_Click(object sender, EventArgs e)
		{
			var rel = InpExportRel.Checked;
			var exportFolder = GetExportFolder(InpExportFolder.Text);
			if (InpExportRel.Checked && !Utils.IsPathInsideFolder(exportFolder, Program.Settings.RootFolder))
			{
				MessageBox.Show("Selected export folder is not relative to root", "Export playlist", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			Program.Settings.ExportFolder = exportFolder;
			Program.Settings.Save();

			var path = Utils.GetFreeFileName(Path.Join(exportFolder, "Melodorium"), ".m3u8", relative: false);
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

			var files = Program.Player.Playlist;
			using var loadingDialog = new FormLoading();
			loadingDialog.Job = () =>
			{
				using var f = File.CreateText(path);
				f.WriteLine("#EXTM3U");
				for (int i = 0; i < files.Count; i++)
				{
					loadingDialog.SetProgress((float)i / files.Count);
					var file = files[i];
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
			var folder = Utils.GetFreeDirectoryName(Path.Join(InpCopyFolder.Text, "Melodorium"), relative: false);
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

			var files = Program.Player.Playlist;
			using var loadingDialog = new FormLoading();
			loadingDialog.EnableCancel();
			loadingDialog.Job = () =>
			{
				for (int i = 0; i < files.Count; i++)
				{
					loadingDialog.SetProgress((float)i / files.Count);
					if (loadingDialog.Canceled)
						break;

					var file = files[i];
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

		private void ListFilesMenuItem_Add_Click(object sender, EventArgs e)
		{
			AddSelectedToPlaylist();
		}

		private void ListFilesMenuItem_AddRnd_Click(object sender, EventArgs e)
		{
			AddSelectedToPlaylist(randomize: true);
		}

		private void AddSelectedToPlaylist(bool randomize = false)
		{
			var files = ListFiles.SelectedItems.Cast<ListViewItem>().Select(v => v.Tag as MusicFile).WhereNotNull().ToList();
			if (randomize)
				files.Shuffle();
			Program.Player.AddTracksToPlaylist(files);
		}

		private void ListFilesMenuItem_AddAll_Click(object sender, EventArgs e)
		{
			Program.Player.AddTracksToPlaylist(_filteredFiles);
		}

		private void ListFilesMenuItem_Explorer_Click(object sender, EventArgs e)
		{
			if (ListFiles.SelectedItems.Count == 0) return;
			var item = ListFiles.SelectedItems[0];
			if (item.Tag is MusicFile file)
			{
				Utils.OpenExplorer(file.FPath);
			}
		}

		private void FilterMoodBtn_Click(object sender, EventArgs e)
		{
			_updatingValues = true;
			var check = FilterMood.Items.Count != FilterMood.CheckedItems.Count;
			for (int i = 0; i < FilterMood.Items.Count; i++)
				FilterMood.SetItemChecked(i, check);
			_updatingValues = false;
			if (Program.Settings.AutoApply) ShowMusicList();
		}

		private void FilterLikeBtn_Click(object sender, EventArgs e)
		{
			_updatingValues = true;
			var check = FilterLike.Items.Count != FilterLike.CheckedItems.Count;
			for (int i = 0; i < FilterLike.Items.Count; i++)
				FilterLike.SetItemChecked(i, check);
			FilterLike.SetItemCheckState(4, CheckState.Indeterminate);
			_updatingValues = false;
			if (Program.Settings.AutoApply) ShowMusicList();
		}

		private void FilterLangBtn_Click(object sender, EventArgs e)
		{
			_updatingValues = true;
			var check = FilterLang.Items.Count != FilterLang.CheckedItems.Count;
			for (int i = 0; i < FilterLang.Items.Count; i++)
				FilterLang.SetItemChecked(i, check);
			_updatingValues = false;
			if (Program.Settings.AutoApply) ShowMusicList();
		}

		private void FilterTagsBtn_Click(object sender, EventArgs e)
		{
			_updatingValues = true;
			var check = FilterTags.Items.Count != FilterTags.CheckedItems.Count;
			for (int i = 0; i < FilterTags.Items.Count; i++)
				FilterTags.SetItemChecked(i, check);
			_updatingValues = false;
			if (Program.Settings.AutoApply) ShowMusicList();
		}
	}
}
 
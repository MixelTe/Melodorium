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
using NAudio.Wave.SampleProviders;
using TagLib.Mpeg;
using static System.Net.Mime.MediaTypeNames;

namespace Melodorium
{
	public partial class FormMain : Form
	{
		private readonly WaveOutEvent _outputDevice = new();
		private AudioFileReader? _audioFile;
		private string _audioFileCur = "";
		private MusicFile? _selectedFile;
		private int _selectedFileI = 0;
		private bool _closing = false;
		private bool _updatingTime = false;
		private bool _autoplaying = false;
		private bool _metaChanged = false;
		private bool _metaDeleteImg = false;
		private string? _metaNewImg;

		public FormMain()
		{
			InitializeComponent();
			_outputDevice.PlaybackStopped += (object? sender, StoppedEventArgs args) =>
			{
				if (_closing)
				{
					_outputDevice.Dispose();
					_audioFile?.Dispose();
				}
				else
				{
					if (_selectedFile == null) return;
					if (!InpAutoplay.Checked) return;
					if (_autoplaying) return;
					ListFiles.Invoke(() =>
					{
						var toSelectI = (_selectedFileI + 1) % ListFiles.Items.Count;
						_autoplaying = true;
						ListFiles.Items[toSelectI].Selected = true;
						_autoplaying = false;
					});
				}
			};
			_outputDevice.Volume = Program.Settings.Volume;
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

		private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			_closing = true;
			_outputDevice.Stop();
		}

		private void FormMain_Shown(object sender, EventArgs e)
		{
			if (Program.Settings.RootFolder == "")
				OpenFolder();
			UpdateTags();
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
			UpdateTags();
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
			UpdateTags();
			ShowMusicList();
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
					ListFiles.Items.Add(new ListViewItem(file.RPath + tags) { Tag = file });
					c++;
				}
				ListFiles.Columns[0].Text = $"Music [{c}]";
				loadingDialog.Close();
			};
			loadingDialog.ShowDialog(this);
		}

		private void UpdateTags(bool updateData = false)
		{
			var selectedTagI = FilterTags.SelectedIndex;
			var selectedTag = selectedTagI >= 2 ? Program.MusicData.Tags[FilterTags.SelectedIndex - 2] : "";
			if (updateData)
				Program.MusicData.UpdateTagsList();
			FilterTags.Items.Clear();
			FilterTags.Items.Add("");
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

			InpTags.Items.Clear();
			foreach (var tag in Program.MusicData.Tags)
				InpTags.Items.Add(tag);
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
				PBMusicImage.Image = System.Drawing.Image.FromStream(ms);
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
				TimeSpan? curTime = null;
				if (_audioFile != null)
				{
					_outputDevice.Stop();
					curTime = _audioFile.CurrentTime;
					_audioFile.Dispose();
					_audioFile = null;
				}
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
				if (curTime != null)
				{
					PlayMusic();
					if (_audioFile != null)
						_audioFile.CurrentTime = (TimeSpan)curTime;
				}
			}
			LblState.Text = "Saved";

			var tags = " [";
			tags += _selectedFile.Data.Mood.ToString()[..2] + ";";
			tags += _selectedFile.Data.Like.ToString()[..2] + ";";
			tags += _selectedFile.Data.Lang.ToString()[..2] + "]";
			ListFiles.Items[_selectedFileI].Text = _selectedFile.RPath + tags;
			UpdateTags(updateData: true);
		}

		private void BtnPlay_Click(object sender, EventArgs e)
		{
			PlayMusic();
		}

		private void PlayMusic()
		{
			if (_selectedFile == null) return;

			if (_audioFile == null || _audioFileCur != _selectedFile.FPath)
			{
				_outputDevice.Stop();
				_audioFile?.Dispose();
				_audioFile = new AudioFileReader(_selectedFile.FPath);
				_audioFileCur = _selectedFile.FPath;
				_outputDevice.Init(_audioFile);
			}
			LblTime.Text = $"{_audioFile.CurrentTime:mm\\:ss}/{_audioFile.TotalTime:mm\\:ss}";
			_outputDevice.Play();
		}

		private void BtnStop_Click(object sender, EventArgs e)
		{
			_outputDevice?.Pause();
		}

		private void InpVolume_VolumeChanged(object sender, EventArgs e)
		{
			Program.Settings.Volume = (float)InpVolume.Value;
			Program.Settings.Save();
			_outputDevice.Volume = Program.Settings.Volume;
		}

		private void InpMusicTime_ValueChanged(object sender, EventArgs e)
		{
			if (_updatingTime) return;
			if (_audioFile == null) return;
			_audioFile.CurrentTime = _audioFile.TotalTime * InpMusicTime.Value / 100;
			LblTime.Text = $"{_audioFile.CurrentTime:mm\\:ss}/{_audioFile.TotalTime:mm\\:ss}";
		}

		private void MusicTimer_Tick(object sender, EventArgs e)
		{
			if (_audioFile == null) return;
			_updatingTime = true;
			InpMusicTime.Value = (int)(_audioFile.CurrentTime / _audioFile.TotalTime * 100);
			LblTime.Text = $"{_audioFile.CurrentTime:mm\\:ss}/{_audioFile.TotalTime:mm\\:ss}";
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
	}
}

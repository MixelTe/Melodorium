﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
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

		private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			_closing = true;
			_outputDevice.Stop();
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
			_selectedFileI = ListFiles.SelectedIndices[0];

			LblMusicAuthor.Text = file.Author.Replace("_", " ");
			LblMusicName.Text = file.SName == "" ? file.Name : file.SName.Replace("_", " ");
			InpMood.SelectedIndex = (int)file.Data.Mood;
			InpLike.SelectedIndex = (int)file.Data.Like;
			InpLang.SelectedIndex = (int)file.Data.Lang;
			InpHidden.Checked = file.Data.Hidden;

			if (InpAutoplay.Checked)
				PlayMusic();
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

		private void BtnPlay_Click(object sender, EventArgs e)
		{
			PlayMusic();
		}

		private void PlayMusic()
		{
			if (_selectedFile == null) return;

			_outputDevice.Stop();
			if (_audioFile == null || _audioFileCur != _selectedFile.FPath)
			{
				_audioFile?.Dispose();
				_audioFile = new AudioFileReader(_selectedFile.FPath);
				_audioFileCur = _selectedFile.FPath;
				_outputDevice.Init(_audioFile);
			}
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
		}

		private void MusicTimer_Tick(object sender, EventArgs e)
		{
			if (_audioFile == null) return;
			_updatingTime = true;
			InpMusicTime.Value = (int)(_audioFile.CurrentTime / _audioFile.TotalTime * 100);
			_updatingTime = false;
		}
	}
}

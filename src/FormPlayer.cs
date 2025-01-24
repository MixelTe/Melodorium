using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TagLib.Mpeg;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Melodorium
{
	public partial class FormPlayer : Form
	{
		public bool WasOpened = false;
		private List<MusicFile> _playlist = [];
		private readonly AudioPlayer _audioPlayer = new();
		private int _selectedFileI = 0;
		private bool _closing = false;
		private bool _updatingTime = false;

		public FormPlayer()
		{
			InitializeComponent();
			_audioPlayer.TrackEnded += (object? sender, EventArgs args) =>
			{
				ListFiles.Invoke(PlayNext);
			};
			_audioPlayer.Volume = Program.Settings.Volume;
			InpVolume.Value = Program.Settings.Volume;
			if (Program.Settings.PlayerRect.X >= 0)
			{
				StartPosition = FormStartPosition.Manual;
				Location = Program.Settings.PlayerRect.Location;
				Size = Program.Settings.PlayerRect.Size;
			}
		}

		public void AddTrackToPlaylist(MusicFile file)
		{
			_playlist.Add(file);
			ListFiles.Items.Add(new ListViewItem(file.PlaylistName + file.Tags) { Tag = file });
			ListFiles.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
		}

		public void CloseForm()
		{
			_closing = true;
			Close();
		}

		private void FormPlayer_Shown(object sender, EventArgs e)
		{
			WasOpened = true;
		}

		private void FormPlayer_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!_closing)
			{
				e.Cancel = true;
				Hide();
				return;
			}
			_audioPlayer.Stop();
		}

		private void Play(int i)
		{
			if (i < 0) i = 0;
			if (i > _playlist.Count) i = _playlist.Count - 1;
			_selectedFileI = i;
			Play();
		}
		private void Play()
		{
			var file = _selectedFileI >= 0 && _selectedFileI < _playlist.Count ? _playlist[_selectedFileI] : null;
			if (file == null) return;

			var ok = _audioPlayer.PlayPause(file);
			if (ok) file.LoadMeta();
			ListFiles.Items[_selectedFileI].Text = file.PlaylistName + file.Tags;
            foreach (ListViewItem item in ListFiles.Items)
				item.BackColor = Color.Transparent;
			ListFiles.Items[_selectedFileI].BackColor = Color.LightBlue;

			LblMusicName.Text = file.PlaylistName;
			LblTime.Text = _audioPlayer.PlaytimeDisplay;
			BtnPlay.Text = _audioPlayer.IsPlaying ? "Pause" : "Play";

			if (!ok) PlayNext();
		}

		private void PlayNext()
		{
			if (_playlist.Count == 0) return;
			Play((_selectedFileI + 1) % _playlist.Count);
		}

		private void BtnPlay_Click(object sender, EventArgs e)
		{
			Play(_selectedFileI);
		}

		private void BtnStop_Click(object sender, EventArgs e)
		{
			_audioPlayer.Stop();
			LblTime.Text = _audioPlayer.PlaytimeDisplay;
			BtnPlay.Text = "Play";
		}

		private void BtnPrev_Click(object sender, EventArgs e)
		{
			if (_playlist.Count == 0) return;
			Play((_selectedFileI - 1 + _playlist.Count) % _playlist.Count);
		}

		private void BtnNext_Click(object sender, EventArgs e)
		{
			if (_playlist.Count == 0) return;
			PlayNext();
		}

		private void InpVolume_ValueChanged(object sender, EventArgs e)
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
			_updatingTime = true;
			InpMusicTime.Value = (int)(_audioPlayer.TimeNormalized * 100);
			LblTime.Text = _audioPlayer.PlaytimeDisplay;
			_updatingTime = false;
		}

		private void FormPlayer_ResizeEnd(object sender, EventArgs e)
		{
			Program.Settings.PlayerRect = new(Location, Size);
			Program.Settings.Save();
		}

		private void ListFiles_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			var info = ListFiles.HitTest(e.X, e.Y);
			var item = info.Item;

			if (item == null) return;
			var i = ListFiles.Items.IndexOf(item);
			Play(i);
		}

		private void BtnOpenManager_Click(object sender, EventArgs e)
		{
			Program.Manager.Show();
			Program.Manager.Activate();
		}

		private void ListFilesMenuItem_Delete_Click(object sender, EventArgs e)
		{
			var indexes = ListFiles.SelectedIndices.Cast<int>().OrderDescending().ToList();
			foreach (var i in indexes)
			{
				if (i <= _selectedFileI) _selectedFileI--;
				ListFiles.Items.RemoveAt(i);
				_playlist.RemoveAt(i);
			}
		}

		private void ListFiles_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.A && e.Control)
			{
				foreach (ListViewItem item in ListFiles.Items)
				{
					item.Selected = true;
				}
			}
		}
	}
}

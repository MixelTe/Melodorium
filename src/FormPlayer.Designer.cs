﻿namespace Melodorium
{
	partial class FormPlayer
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPlayer));
			LblTime = new Label();
			BtnStop = new Button();
			BtnPlay = new Button();
			LblMusicName = new Label();
			InpMusicTime = new TrackBar();
			InpVolume = new NAudio.Gui.Pot();
			ListFiles = new ListView();
			Playlist = new ColumnHeader();
			BtnPrev = new Button();
			BtnNext = new Button();
			MusicTimer = new System.Windows.Forms.Timer(components);
			((System.ComponentModel.ISupportInitialize)InpMusicTime).BeginInit();
			SuspendLayout();
			// 
			// LblTime
			// 
			LblTime.AutoSize = true;
			LblTime.Location = new Point(115, 65);
			LblTime.Margin = new Padding(4, 0, 4, 0);
			LblTime.Name = "LblTime";
			LblTime.Size = new Size(66, 15);
			LblTime.TabIndex = 20;
			LblTime.Text = "00:00/00:00";
			// 
			// BtnStop
			// 
			BtnStop.Location = new Point(66, 61);
			BtnStop.Margin = new Padding(4, 3, 4, 3);
			BtnStop.Name = "BtnStop";
			BtnStop.Size = new Size(42, 23);
			BtnStop.TabIndex = 17;
			BtnStop.Text = "Stop";
			BtnStop.UseVisualStyleBackColor = true;
			BtnStop.Click += BtnStop_Click;
			// 
			// BtnPlay
			// 
			BtnPlay.Location = new Point(12, 61);
			BtnPlay.Margin = new Padding(4, 3, 4, 3);
			BtnPlay.Name = "BtnPlay";
			BtnPlay.Size = new Size(49, 23);
			BtnPlay.TabIndex = 16;
			BtnPlay.Text = "Play";
			BtnPlay.UseVisualStyleBackColor = true;
			BtnPlay.Click += BtnPlay_Click;
			// 
			// LblMusicName
			// 
			LblMusicName.AutoSize = true;
			LblMusicName.Font = new Font("Segoe UI", 11F);
			LblMusicName.Location = new Point(12, 9);
			LblMusicName.Margin = new Padding(4, 0, 4, 0);
			LblMusicName.Name = "LblMusicName";
			LblMusicName.Size = new Size(82, 20);
			LblMusicName.TabIndex = 15;
			LblMusicName.Text = "No playing";
			// 
			// InpMusicTime
			// 
			InpMusicTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			InpMusicTime.Location = new Point(12, 32);
			InpMusicTime.Margin = new Padding(4, 3, 4, 3);
			InpMusicTime.Maximum = 100;
			InpMusicTime.Name = "InpMusicTime";
			InpMusicTime.Size = new Size(268, 45);
			InpMusicTime.TabIndex = 19;
			InpMusicTime.ValueChanged += InpMusicTime_ValueChanged;
			// 
			// InpVolume
			// 
			InpVolume.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			InpVolume.Location = new Point(241, 61);
			InpVolume.Margin = new Padding(4, 3, 4, 3);
			InpVolume.Maximum = 1D;
			InpVolume.Minimum = 0D;
			InpVolume.Name = "InpVolume";
			InpVolume.Size = new Size(37, 37);
			InpVolume.TabIndex = 18;
			InpVolume.Value = 0.5D;
			InpVolume.ValueChanged += InpVolume_ValueChanged;
			// 
			// ListFiles
			// 
			ListFiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			ListFiles.Columns.AddRange(new ColumnHeader[] { Playlist });
			ListFiles.Font = new Font("Segoe UI", 8F);
			ListFiles.Location = new Point(9, 90);
			ListFiles.Margin = new Padding(4, 3, 4, 3);
			ListFiles.Name = "ListFiles";
			ListFiles.Size = new Size(270, 164);
			ListFiles.TabIndex = 21;
			ListFiles.UseCompatibleStateImageBehavior = false;
			ListFiles.View = View.Details;
			ListFiles.MouseDoubleClick += ListFiles_MouseDoubleClick;
			// 
			// Playlist
			// 
			Playlist.Text = "Playlist";
			Playlist.Width = 240;
			// 
			// BtnPrev
			// 
			BtnPrev.Location = new Point(187, 61);
			BtnPrev.Margin = new Padding(4, 3, 4, 3);
			BtnPrev.Name = "BtnPrev";
			BtnPrev.Size = new Size(23, 23);
			BtnPrev.TabIndex = 22;
			BtnPrev.Text = "<";
			BtnPrev.UseVisualStyleBackColor = true;
			BtnPrev.Click += BtnPrev_Click;
			// 
			// BtnNext
			// 
			BtnNext.Location = new Point(216, 61);
			BtnNext.Margin = new Padding(4, 3, 4, 3);
			BtnNext.Name = "BtnNext";
			BtnNext.Size = new Size(23, 23);
			BtnNext.TabIndex = 23;
			BtnNext.Text = ">";
			BtnNext.UseVisualStyleBackColor = true;
			BtnNext.Click += BtnNext_Click;
			// 
			// MusicTimer
			// 
			MusicTimer.Enabled = true;
			MusicTimer.Interval = 1000;
			MusicTimer.Tick += MusicTimer_Tick;
			// 
			// FormPlayer
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(292, 267);
			Controls.Add(BtnNext);
			Controls.Add(BtnPrev);
			Controls.Add(ListFiles);
			Controls.Add(InpVolume);
			Controls.Add(LblTime);
			Controls.Add(BtnStop);
			Controls.Add(BtnPlay);
			Controls.Add(InpMusicTime);
			Controls.Add(LblMusicName);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(4, 3, 4, 3);
			MaximizeBox = false;
			MinimizeBox = false;
			MinimumSize = new Size(308, 306);
			Name = "FormPlayer";
			StartPosition = FormStartPosition.CenterParent;
			Text = "Melodorium | Player";
			FormClosing += FormPlayer_FormClosing;
			ResizeEnd += FormPlayer_ResizeEnd;
			((System.ComponentModel.ISupportInitialize)InpMusicTime).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label LblTime;
		private Button BtnStop;
		private Button BtnPlay;
		private Label LblMusicName;
		private TrackBar InpMusicTime;
		private NAudio.Gui.Pot InpVolume;
		private ListView ListFiles;
		private Button BtnPrev;
		private Button BtnNext;
		private System.Windows.Forms.Timer MusicTimer;
		private ColumnHeader Playlist;
	}
}
namespace Melodorium
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
			PlaylistColumn = new ColumnHeader();
			ListFilesMenu = new ContextMenuStrip(components);
			ListFilesMenuItem_Delete = new ToolStripMenuItem();
			ListFilesMenuItem_Explorer = new ToolStripMenuItem();
			toolStripSeparator1 = new ToolStripSeparator();
			ListFilesMenuItem_Clear = new ToolStripMenuItem();
			ListFilesMenuItem_Shuffle = new ToolStripMenuItem();
			BtnPrev = new Button();
			BtnNext = new Button();
			MusicTimer = new System.Windows.Forms.Timer(components);
			BtnOpenManager = new Button();
			InpAutoplay = new CheckBox();
			InpLoop = new CheckBox();
			BtnAddTrack = new Button();
			BtnHotkeys = new Button();
			ToolTip1 = new ToolTip(components);
			((System.ComponentModel.ISupportInitialize)InpMusicTime).BeginInit();
			ListFilesMenu.SuspendLayout();
			SuspendLayout();
			// 
			// LblTime
			// 
			LblTime.AutoSize = true;
			LblTime.Location = new Point(113, 61);
			LblTime.Margin = new Padding(4, 0, 4, 0);
			LblTime.Name = "LblTime";
			LblTime.Size = new Size(66, 15);
			LblTime.TabIndex = 20;
			LblTime.Text = "00:00/00:00";
			// 
			// BtnStop
			// 
			BtnStop.Location = new Point(65, 57);
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
			BtnPlay.Location = new Point(12, 57);
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
			LblMusicName.Location = new Point(4, 4);
			LblMusicName.Margin = new Padding(4, 0, 4, 0);
			LblMusicName.Name = "LblMusicName";
			LblMusicName.Size = new Size(82, 20);
			LblMusicName.TabIndex = 15;
			LblMusicName.Text = "No playing";
			// 
			// InpMusicTime
			// 
			InpMusicTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			InpMusicTime.Location = new Point(4, 27);
			InpMusicTime.Margin = new Padding(4, 3, 4, 3);
			InpMusicTime.Maximum = 100;
			InpMusicTime.Name = "InpMusicTime";
			InpMusicTime.Size = new Size(276, 45);
			InpMusicTime.TabIndex = 19;
			InpMusicTime.ValueChanged += InpMusicTime_ValueChanged;
			// 
			// InpVolume
			// 
			InpVolume.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			InpVolume.Location = new Point(243, 57);
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
			ListFiles.Columns.AddRange(new ColumnHeader[] { PlaylistColumn });
			ListFiles.ContextMenuStrip = ListFilesMenu;
			ListFiles.Font = new Font("Segoe UI", 8F);
			ListFiles.Location = new Point(4, 86);
			ListFiles.Margin = new Padding(4, 3, 4, 3);
			ListFiles.Name = "ListFiles";
			ListFiles.Size = new Size(276, 147);
			ListFiles.TabIndex = 21;
			ListFiles.UseCompatibleStateImageBehavior = false;
			ListFiles.View = View.Details;
			ListFiles.KeyDown += ListFiles_KeyDown;
			ListFiles.MouseDoubleClick += ListFiles_MouseDoubleClick;
			// 
			// PlaylistColumn
			// 
			PlaylistColumn.Text = "Playlist";
			PlaylistColumn.Width = 240;
			// 
			// ListFilesMenu
			// 
			ListFilesMenu.Items.AddRange(new ToolStripItem[] { ListFilesMenuItem_Delete, ListFilesMenuItem_Explorer, toolStripSeparator1, ListFilesMenuItem_Clear, ListFilesMenuItem_Shuffle });
			ListFilesMenu.Name = "ListFilesMenu";
			ListFilesMenu.Size = new Size(163, 98);
			// 
			// ListFilesMenuItem_Delete
			// 
			ListFilesMenuItem_Delete.Name = "ListFilesMenuItem_Delete";
			ListFilesMenuItem_Delete.Size = new Size(162, 22);
			ListFilesMenuItem_Delete.Text = "Remove";
			ListFilesMenuItem_Delete.Click += ListFilesMenuItem_Delete_Click;
			// 
			// ListFilesMenuItem_Explorer
			// 
			ListFilesMenuItem_Explorer.Name = "ListFilesMenuItem_Explorer";
			ListFilesMenuItem_Explorer.Size = new Size(162, 22);
			ListFilesMenuItem_Explorer.Text = "Open in explorer";
			ListFilesMenuItem_Explorer.Click += ListFilesMenuItem_Explorer_Click;
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new Size(159, 6);
			// 
			// ListFilesMenuItem_Clear
			// 
			ListFilesMenuItem_Clear.Name = "ListFilesMenuItem_Clear";
			ListFilesMenuItem_Clear.Size = new Size(162, 22);
			ListFilesMenuItem_Clear.Text = "Clear playlist";
			ListFilesMenuItem_Clear.Click += ListFilesMenuItem_Clear_Click;
			// 
			// ListFilesMenuItem_Shuffle
			// 
			ListFilesMenuItem_Shuffle.Name = "ListFilesMenuItem_Shuffle";
			ListFilesMenuItem_Shuffle.Size = new Size(162, 22);
			ListFilesMenuItem_Shuffle.Text = "Shuffle playlist";
			ListFilesMenuItem_Shuffle.Click += ListFilesMenuItem_Shuffle_Click;
			// 
			// BtnPrev
			// 
			BtnPrev.Location = new Point(187, 57);
			BtnPrev.Margin = new Padding(4, 3, 4, 3);
			BtnPrev.Name = "BtnPrev";
			BtnPrev.Size = new Size(23, 23);
			BtnPrev.TabIndex = 22;
			BtnPrev.Text = "<";
			ToolTip1.SetToolTip(BtnPrev, "Previous track");
			BtnPrev.UseVisualStyleBackColor = true;
			BtnPrev.Click += BtnPrev_Click;
			// 
			// BtnNext
			// 
			BtnNext.Location = new Point(216, 57);
			BtnNext.Margin = new Padding(4, 3, 4, 3);
			BtnNext.Name = "BtnNext";
			BtnNext.Size = new Size(23, 23);
			BtnNext.TabIndex = 23;
			BtnNext.Text = ">";
			ToolTip1.SetToolTip(BtnNext, "Next track");
			BtnNext.UseVisualStyleBackColor = true;
			BtnNext.Click += BtnNext_Click;
			// 
			// MusicTimer
			// 
			MusicTimer.Enabled = true;
			MusicTimer.Interval = 1000;
			MusicTimer.Tick += MusicTimer_Tick;
			// 
			// BtnOpenManager
			// 
			BtnOpenManager.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			BtnOpenManager.Location = new Point(4, 237);
			BtnOpenManager.Margin = new Padding(4, 3, 4, 3);
			BtnOpenManager.Name = "BtnOpenManager";
			BtnOpenManager.Size = new Size(23, 23);
			BtnOpenManager.TabIndex = 24;
			BtnOpenManager.Text = "M";
			ToolTip1.SetToolTip(BtnOpenManager, "Manager");
			BtnOpenManager.UseVisualStyleBackColor = true;
			BtnOpenManager.Click += BtnOpenManager_Click;
			// 
			// InpAutoplay
			// 
			InpAutoplay.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			InpAutoplay.AutoSize = true;
			InpAutoplay.Location = new Point(80, 240);
			InpAutoplay.Name = "InpAutoplay";
			InpAutoplay.Size = new Size(72, 19);
			InpAutoplay.TabIndex = 25;
			InpAutoplay.Text = "autoplay";
			InpAutoplay.UseVisualStyleBackColor = true;
			InpAutoplay.CheckedChanged += InpAutoplay_CheckedChanged;
			// 
			// InpLoop
			// 
			InpLoop.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			InpLoop.AutoSize = true;
			InpLoop.Location = new Point(156, 240);
			InpLoop.Name = "InpLoop";
			InpLoop.Size = new Size(79, 19);
			InpLoop.TabIndex = 26;
			InpLoop.Text = "loop track";
			InpLoop.UseVisualStyleBackColor = true;
			InpLoop.CheckedChanged += InpLoop_CheckedChanged;
			// 
			// BtnAddTrack
			// 
			BtnAddTrack.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			BtnAddTrack.Location = new Point(54, 237);
			BtnAddTrack.Margin = new Padding(4, 3, 4, 3);
			BtnAddTrack.Name = "BtnAddTrack";
			BtnAddTrack.Size = new Size(23, 23);
			BtnAddTrack.TabIndex = 27;
			BtnAddTrack.Text = "A";
			ToolTip1.SetToolTip(BtnAddTrack, "Add track (auto)");
			BtnAddTrack.UseVisualStyleBackColor = true;
			BtnAddTrack.Click += BtnAddTrack_Click;
			// 
			// BtnHotkeys
			// 
			BtnHotkeys.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			BtnHotkeys.Location = new Point(29, 237);
			BtnHotkeys.Margin = new Padding(4, 3, 4, 3);
			BtnHotkeys.Name = "BtnHotkeys";
			BtnHotkeys.Size = new Size(23, 23);
			BtnHotkeys.TabIndex = 28;
			BtnHotkeys.Text = "H";
			ToolTip1.SetToolTip(BtnHotkeys, "Hotkeys");
			BtnHotkeys.UseVisualStyleBackColor = true;
			BtnHotkeys.Click += BtnHotkeys_Click;
			// 
			// FormPlayer
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(284, 264);
			Controls.Add(BtnHotkeys);
			Controls.Add(BtnAddTrack);
			Controls.Add(InpLoop);
			Controls.Add(InpAutoplay);
			Controls.Add(BtnOpenManager);
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
			MinimumSize = new Size(300, 220);
			Name = "FormPlayer";
			StartPosition = FormStartPosition.CenterParent;
			Text = "Melodorium | Player";
			FormClosing += FormPlayer_FormClosing;
			Shown += FormPlayer_Shown;
			ResizeEnd += FormPlayer_ResizeEnd;
			((System.ComponentModel.ISupportInitialize)InpMusicTime).EndInit();
			ListFilesMenu.ResumeLayout(false);
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
		private ColumnHeader PlaylistColumn;
		private Button BtnOpenManager;
		private ContextMenuStrip ListFilesMenu;
		private ToolStripMenuItem ListFilesMenuItem_Delete;
		private ToolStripMenuItem ListFilesMenuItem_Clear;
		private ToolStripMenuItem ListFilesMenuItem_Shuffle;
		private ToolStripMenuItem ListFilesMenuItem_Explorer;
		private ToolStripSeparator toolStripSeparator1;
		private CheckBox InpAutoplay;
		private CheckBox InpLoop;
		private Button BtnAddTrack;
		private Button BtnHotkeys;
		private ToolTip ToolTip1;
	}
}
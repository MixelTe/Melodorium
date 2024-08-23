namespace Melodorium
{
	partial class FormMain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			BtnChangeFolder = new Button();
			BtnExport = new Button();
			BtnManage = new Button();
			FilterMood = new CheckedListBox();
			groupBox1 = new GroupBox();
			BtnResetFilter = new Button();
			label2 = new Label();
			FilterName = new TextBox();
			FilterHidden = new ComboBox();
			BtnFilter = new Button();
			FilterUncategorized = new CheckBox();
			FilterAuthor = new TextBox();
			label1 = new Label();
			FilterLang = new CheckedListBox();
			FilterLike = new CheckedListBox();
			splitContainer1 = new SplitContainer();
			ListFiles = new ListView();
			columnHeader1 = new ColumnHeader();
			LblState = new Label();
			InpAutoplay = new CheckBox();
			BtnStop = new Button();
			BtnPlay = new Button();
			InpVolume = new NAudio.Gui.Pot();
			InpMusicTime = new TrackBar();
			InpHidden = new CheckBox();
			BtnSaveMusic = new Button();
			InpLike = new ComboBox();
			InpLang = new ComboBox();
			InpMood = new ComboBox();
			LblMusicAuthor = new Label();
			LblMusicName = new Label();
			BtnExportPlaylist = new Button();
			MusicTimer = new System.Windows.Forms.Timer(components);
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)InpMusicTime).BeginInit();
			SuspendLayout();
			// 
			// BtnChangeFolder
			// 
			BtnChangeFolder.Location = new Point(12, 12);
			BtnChangeFolder.Name = "BtnChangeFolder";
			BtnChangeFolder.Size = new Size(80, 23);
			BtnChangeFolder.TabIndex = 0;
			BtnChangeFolder.Text = "Open folder";
			BtnChangeFolder.UseVisualStyleBackColor = true;
			BtnChangeFolder.Click += BtnChangeFolder_Click;
			// 
			// BtnExport
			// 
			BtnExport.Location = new Point(98, 12);
			BtnExport.Name = "BtnExport";
			BtnExport.Size = new Size(75, 23);
			BtnExport.TabIndex = 1;
			BtnExport.Text = "Export data";
			BtnExport.UseVisualStyleBackColor = true;
			BtnExport.Click += BtnExport_Click;
			// 
			// BtnManage
			// 
			BtnManage.Location = new Point(179, 12);
			BtnManage.Name = "BtnManage";
			BtnManage.Size = new Size(84, 23);
			BtnManage.TabIndex = 2;
			BtnManage.Text = "Manage files";
			BtnManage.UseVisualStyleBackColor = true;
			BtnManage.Click += BtnManage_Click;
			// 
			// FilterMood
			// 
			FilterMood.CheckOnClick = true;
			FilterMood.FormattingEnabled = true;
			FilterMood.Location = new Point(6, 22);
			FilterMood.Name = "FilterMood";
			FilterMood.Size = new Size(100, 148);
			FilterMood.TabIndex = 3;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(BtnResetFilter);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(FilterName);
			groupBox1.Controls.Add(FilterHidden);
			groupBox1.Controls.Add(BtnFilter);
			groupBox1.Controls.Add(FilterUncategorized);
			groupBox1.Controls.Add(FilterAuthor);
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(FilterLang);
			groupBox1.Controls.Add(FilterLike);
			groupBox1.Controls.Add(FilterMood);
			groupBox1.Location = new Point(12, 41);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(566, 178);
			groupBox1.TabIndex = 4;
			groupBox1.TabStop = false;
			groupBox1.Text = "Filters";
			// 
			// BtnResetFilter
			// 
			BtnResetFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			BtnResetFilter.Location = new Point(482, 120);
			BtnResetFilter.Name = "BtnResetFilter";
			BtnResetFilter.Size = new Size(75, 23);
			BtnResetFilter.TabIndex = 13;
			BtnResetFilter.Text = "Reset filter";
			BtnResetFilter.UseVisualStyleBackColor = true;
			BtnResetFilter.Click += BtnResetFilter_Click;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(324, 53);
			label2.Name = "label2";
			label2.Size = new Size(39, 15);
			label2.TabIndex = 12;
			label2.Text = "Name";
			// 
			// FilterName
			// 
			FilterName.Location = new Point(374, 50);
			FilterName.Name = "FilterName";
			FilterName.PlaceholderText = "Any";
			FilterName.Size = new Size(183, 23);
			FilterName.TabIndex = 11;
			// 
			// FilterHidden
			// 
			FilterHidden.DropDownStyle = ComboBoxStyle.DropDownList;
			FilterHidden.FormattingEnabled = true;
			FilterHidden.Items.AddRange(new object[] { "normal", "all", "hidden" });
			FilterHidden.Location = new Point(324, 120);
			FilterHidden.Name = "FilterHidden";
			FilterHidden.Size = new Size(64, 23);
			FilterHidden.TabIndex = 10;
			// 
			// BtnFilter
			// 
			BtnFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			BtnFilter.Location = new Point(482, 146);
			BtnFilter.Name = "BtnFilter";
			BtnFilter.Size = new Size(75, 23);
			BtnFilter.TabIndex = 9;
			BtnFilter.Text = "Apply";
			BtnFilter.UseVisualStyleBackColor = true;
			BtnFilter.Click += BtnFilter_Click;
			// 
			// FilterUncategorized
			// 
			FilterUncategorized.AutoSize = true;
			FilterUncategorized.Location = new Point(324, 149);
			FilterUncategorized.Name = "FilterUncategorized";
			FilterUncategorized.Size = new Size(102, 19);
			FilterUncategorized.TabIndex = 8;
			FilterUncategorized.Text = "Uncategorized";
			FilterUncategorized.UseVisualStyleBackColor = true;
			// 
			// FilterAuthor
			// 
			FilterAuthor.Location = new Point(374, 21);
			FilterAuthor.Name = "FilterAuthor";
			FilterAuthor.PlaceholderText = "Any";
			FilterAuthor.Size = new Size(183, 23);
			FilterAuthor.TabIndex = 7;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(324, 24);
			label1.Name = "label1";
			label1.Size = new Size(44, 15);
			label1.TabIndex = 6;
			label1.Text = "Author";
			// 
			// FilterLang
			// 
			FilterLang.CheckOnClick = true;
			FilterLang.FormattingEnabled = true;
			FilterLang.Location = new Point(218, 21);
			FilterLang.Name = "FilterLang";
			FilterLang.Size = new Size(100, 148);
			FilterLang.TabIndex = 5;
			// 
			// FilterLike
			// 
			FilterLike.CheckOnClick = true;
			FilterLike.FormattingEnabled = true;
			FilterLike.Location = new Point(112, 22);
			FilterLike.Name = "FilterLike";
			FilterLike.Size = new Size(100, 148);
			FilterLike.TabIndex = 4;
			// 
			// splitContainer1
			// 
			splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			splitContainer1.Location = new Point(12, 225);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(ListFiles);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(LblState);
			splitContainer1.Panel2.Controls.Add(InpAutoplay);
			splitContainer1.Panel2.Controls.Add(BtnStop);
			splitContainer1.Panel2.Controls.Add(BtnPlay);
			splitContainer1.Panel2.Controls.Add(InpVolume);
			splitContainer1.Panel2.Controls.Add(InpMusicTime);
			splitContainer1.Panel2.Controls.Add(InpHidden);
			splitContainer1.Panel2.Controls.Add(BtnSaveMusic);
			splitContainer1.Panel2.Controls.Add(InpLike);
			splitContainer1.Panel2.Controls.Add(InpLang);
			splitContainer1.Panel2.Controls.Add(InpMood);
			splitContainer1.Panel2.Controls.Add(LblMusicAuthor);
			splitContainer1.Panel2.Controls.Add(LblMusicName);
			splitContainer1.Size = new Size(776, 213);
			splitContainer1.SplitterDistance = 378;
			splitContainer1.TabIndex = 5;
			// 
			// ListFiles
			// 
			ListFiles.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
			ListFiles.Dock = DockStyle.Fill;
			ListFiles.Location = new Point(0, 0);
			ListFiles.MultiSelect = false;
			ListFiles.Name = "ListFiles";
			ListFiles.Size = new Size(378, 213);
			ListFiles.TabIndex = 0;
			ListFiles.UseCompatibleStateImageBehavior = false;
			ListFiles.View = View.Details;
			ListFiles.SelectedIndexChanged += ListFiles_SelectedIndexChanged;
			// 
			// columnHeader1
			// 
			columnHeader1.Text = "Music";
			columnHeader1.Width = 350;
			// 
			// LblState
			// 
			LblState.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			LblState.Location = new Point(3, 187);
			LblState.Name = "LblState";
			LblState.Size = new Size(307, 23);
			LblState.TabIndex = 13;
			LblState.TextAlign = ContentAlignment.MiddleRight;
			// 
			// InpAutoplay
			// 
			InpAutoplay.AutoSize = true;
			InpAutoplay.Location = new Point(268, 133);
			InpAutoplay.Name = "InpAutoplay";
			InpAutoplay.Size = new Size(74, 19);
			InpAutoplay.TabIndex = 12;
			InpAutoplay.Text = "Autoplay";
			InpAutoplay.UseVisualStyleBackColor = true;
			// 
			// BtnStop
			// 
			BtnStop.Location = new Point(65, 129);
			BtnStop.Name = "BtnStop";
			BtnStop.Size = new Size(56, 23);
			BtnStop.TabIndex = 8;
			BtnStop.Text = "Stop";
			BtnStop.UseVisualStyleBackColor = true;
			BtnStop.Click += BtnStop_Click;
			// 
			// BtnPlay
			// 
			BtnPlay.Location = new Point(3, 129);
			BtnPlay.Name = "BtnPlay";
			BtnPlay.Size = new Size(56, 23);
			BtnPlay.TabIndex = 7;
			BtnPlay.Text = "Play";
			BtnPlay.UseVisualStyleBackColor = true;
			BtnPlay.Click += BtnPlay_Click;
			// 
			// InpVolume
			// 
			InpVolume.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			InpVolume.Location = new Point(353, 129);
			InpVolume.Margin = new Padding(4, 3, 4, 3);
			InpVolume.Maximum = 1D;
			InpVolume.Minimum = 0D;
			InpVolume.Name = "InpVolume";
			InpVolume.Size = new Size(37, 37);
			InpVolume.TabIndex = 10;
			InpVolume.Value = 0.5D;
			InpVolume.ValueChanged += InpVolume_VolumeChanged;
			// 
			// InpMusicTime
			// 
			InpMusicTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			InpMusicTime.Location = new Point(3, 100);
			InpMusicTime.Maximum = 100;
			InpMusicTime.Name = "InpMusicTime";
			InpMusicTime.Size = new Size(388, 45);
			InpMusicTime.TabIndex = 11;
			InpMusicTime.ValueChanged += InpMusicTime_ValueChanged;
			// 
			// InpHidden
			// 
			InpHidden.AutoSize = true;
			InpHidden.Location = new Point(3, 75);
			InpHidden.Name = "InpHidden";
			InpHidden.Size = new Size(65, 19);
			InpHidden.TabIndex = 6;
			InpHidden.Text = "Hidden";
			InpHidden.UseVisualStyleBackColor = true;
			InpHidden.CheckedChanged += InpHidden_CheckedChanged;
			// 
			// BtnSaveMusic
			// 
			BtnSaveMusic.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BtnSaveMusic.Location = new Point(316, 187);
			BtnSaveMusic.Name = "BtnSaveMusic";
			BtnSaveMusic.Size = new Size(75, 23);
			BtnSaveMusic.TabIndex = 5;
			BtnSaveMusic.Text = "Save";
			BtnSaveMusic.UseVisualStyleBackColor = true;
			BtnSaveMusic.Click += BtnSaveMusic_Click;
			// 
			// InpLike
			// 
			InpLike.DropDownStyle = ComboBoxStyle.DropDownList;
			InpLike.FormattingEnabled = true;
			InpLike.Location = new Point(84, 46);
			InpLike.Name = "InpLike";
			InpLike.Size = new Size(75, 23);
			InpLike.TabIndex = 4;
			InpLike.SelectedIndexChanged += InpLike_SelectedIndexChanged;
			// 
			// InpLang
			// 
			InpLang.DropDownStyle = ComboBoxStyle.DropDownList;
			InpLang.FormattingEnabled = true;
			InpLang.Location = new Point(165, 46);
			InpLang.Name = "InpLang";
			InpLang.Size = new Size(75, 23);
			InpLang.TabIndex = 3;
			InpLang.SelectedIndexChanged += InpLang_SelectedIndexChanged;
			// 
			// InpMood
			// 
			InpMood.DropDownStyle = ComboBoxStyle.DropDownList;
			InpMood.FormattingEnabled = true;
			InpMood.Location = new Point(3, 46);
			InpMood.Name = "InpMood";
			InpMood.Size = new Size(75, 23);
			InpMood.TabIndex = 2;
			InpMood.SelectedIndexChanged += InpMood_SelectedIndexChanged;
			// 
			// LblMusicAuthor
			// 
			LblMusicAuthor.AutoSize = true;
			LblMusicAuthor.Location = new Point(2, 0);
			LblMusicAuthor.Name = "LblMusicAuthor";
			LblMusicAuthor.Size = new Size(57, 15);
			LblMusicAuthor.TabIndex = 1;
			LblMusicAuthor.Text = "Select file";
			// 
			// LblMusicName
			// 
			LblMusicName.AutoSize = true;
			LblMusicName.Font = new Font("Segoe UI", 11F);
			LblMusicName.Location = new Point(2, 15);
			LblMusicName.Name = "LblMusicName";
			LblMusicName.Size = new Size(74, 20);
			LblMusicName.TabIndex = 0;
			LblMusicName.Text = "Select file";
			// 
			// BtnExportPlaylist
			// 
			BtnExportPlaylist.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			BtnExportPlaylist.Location = new Point(643, 188);
			BtnExportPlaylist.Name = "BtnExportPlaylist";
			BtnExportPlaylist.Size = new Size(145, 23);
			BtnExportPlaylist.TabIndex = 6;
			BtnExportPlaylist.Text = "Export playlist";
			BtnExportPlaylist.UseVisualStyleBackColor = true;
			// 
			// MusicTimer
			// 
			MusicTimer.Enabled = true;
			MusicTimer.Interval = 1000;
			MusicTimer.Tick += MusicTimer_Tick;
			// 
			// FormMain
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(BtnExportPlaylist);
			Controls.Add(splitContainer1);
			Controls.Add(groupBox1);
			Controls.Add(BtnManage);
			Controls.Add(BtnExport);
			Controls.Add(BtnChangeFolder);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FormMain";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Melodorium";
			FormClosing += FormMain_FormClosing;
			Shown += FormMain_Shown;
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)InpMusicTime).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Button BtnChangeFolder;
		private Button BtnExport;
		private Button BtnManage;
		private CheckedListBox FilterMood;
		private GroupBox groupBox1;
		private CheckedListBox FilterLang;
		private CheckedListBox FilterLike;
		private TextBox FilterAuthor;
		private Label label1;
		private CheckBox FilterUncategorized;
		private SplitContainer splitContainer1;
		private ListView ListFiles;
		private Label LblMusicName;
		private Button BtnExportPlaylist;
		private Button BtnFilter;
		private ColumnHeader columnHeader1;
		private ComboBox FilterHidden;
		private Label LblMusicAuthor;
		private ComboBox InpLike;
		private ComboBox InpLang;
		private ComboBox InpMood;
		private Button BtnSaveMusic;
		private CheckBox InpHidden;
		private Button BtnPlay;
		private Button BtnStop;
		private NAudio.Gui.Pot InpVolume;
		private TrackBar InpMusicTime;
		private System.Windows.Forms.Timer MusicTimer;
		private CheckBox InpAutoplay;
		private Label label2;
		private TextBox FilterName;
		private Button BtnResetFilter;
		private Label LblState;
	}
}
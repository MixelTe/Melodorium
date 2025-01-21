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
			FilterTags = new ComboBox();
			label7 = new Label();
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
			ListFilesMenu = new ContextMenuStrip(components);
			ListFilesMenuItem_Add = new ToolStripMenuItem();
			ListFilesMenuItem_AddRnd = new ToolStripMenuItem();
			InpTags = new ComboBox();
			label6 = new Label();
			InpVolume = new NAudio.Gui.Pot();
			groupBox2 = new GroupBox();
			PBMusicImage = new PictureBox();
			BtnDeleteImage = new Button();
			InpAlbum = new TextBox();
			label5 = new Label();
			InpArtists = new TextBox();
			label3 = new Label();
			InpTitle = new TextBox();
			label4 = new Label();
			LblTime = new Label();
			LblState = new Label();
			InpAutoplay = new CheckBox();
			BtnStop = new Button();
			BtnPlay = new Button();
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
			groupBox3 = new GroupBox();
			label10 = new Label();
			BtnCopyPlaylist = new Button();
			BtnSelectCopyFolder = new Button();
			InpCopyFolder = new TextBox();
			label8 = new Label();
			BtnSpExport = new Button();
			BtnExportHelp = new Button();
			InpExportRel = new CheckBox();
			groupBox4 = new GroupBox();
			BtnSelectExportFolder = new Button();
			InpExportFolder = new TextBox();
			label9 = new Label();
			FolderBrowser = new FolderBrowserDialog();
			BtnSync = new Button();
			BtnPlayer = new Button();
			ListFilesMenuItem_AddAll = new ToolStripMenuItem();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			ListFilesMenu.SuspendLayout();
			groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)PBMusicImage).BeginInit();
			((System.ComponentModel.ISupportInitialize)InpMusicTime).BeginInit();
			groupBox3.SuspendLayout();
			groupBox4.SuspendLayout();
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
			groupBox1.Controls.Add(FilterTags);
			groupBox1.Controls.Add(label7);
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
			// FilterTags
			// 
			FilterTags.DropDownStyle = ComboBoxStyle.DropDownList;
			FilterTags.FormattingEnabled = true;
			FilterTags.Items.AddRange(new object[] { "normal", "all", "hidden" });
			FilterTags.Location = new Point(374, 79);
			FilterTags.Name = "FilterTags";
			FilterTags.Size = new Size(183, 23);
			FilterTags.TabIndex = 15;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(324, 82);
			label7.Name = "label7";
			label7.Size = new Size(25, 15);
			label7.TabIndex = 14;
			label7.Text = "Tag";
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
			splitContainer1.Panel2.Controls.Add(InpTags);
			splitContainer1.Panel2.Controls.Add(label6);
			splitContainer1.Panel2.Controls.Add(InpVolume);
			splitContainer1.Panel2.Controls.Add(groupBox2);
			splitContainer1.Panel2.Controls.Add(LblTime);
			splitContainer1.Panel2.Controls.Add(LblState);
			splitContainer1.Panel2.Controls.Add(InpAutoplay);
			splitContainer1.Panel2.Controls.Add(BtnStop);
			splitContainer1.Panel2.Controls.Add(BtnPlay);
			splitContainer1.Panel2.Controls.Add(InpMusicTime);
			splitContainer1.Panel2.Controls.Add(InpHidden);
			splitContainer1.Panel2.Controls.Add(BtnSaveMusic);
			splitContainer1.Panel2.Controls.Add(InpLike);
			splitContainer1.Panel2.Controls.Add(InpLang);
			splitContainer1.Panel2.Controls.Add(InpMood);
			splitContainer1.Panel2.Controls.Add(LblMusicAuthor);
			splitContainer1.Panel2.Controls.Add(LblMusicName);
			splitContainer1.Size = new Size(787, 296);
			splitContainer1.SplitterDistance = 368;
			splitContainer1.TabIndex = 5;
			// 
			// ListFiles
			// 
			ListFiles.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
			ListFiles.ContextMenuStrip = ListFilesMenu;
			ListFiles.Dock = DockStyle.Fill;
			ListFiles.Location = new Point(0, 0);
			ListFiles.Name = "ListFiles";
			ListFiles.Size = new Size(368, 296);
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
			// ListFilesMenu
			// 
			ListFilesMenu.Items.AddRange(new ToolStripItem[] { ListFilesMenuItem_Add, ListFilesMenuItem_AddRnd, ListFilesMenuItem_AddAll });
			ListFilesMenu.Name = "contextMenuStrip1";
			ListFilesMenu.Size = new Size(181, 92);
			// 
			// ListFilesMenuItem_Add
			// 
			ListFilesMenuItem_Add.Name = "ListFilesMenuItem_Add";
			ListFilesMenuItem_Add.Size = new Size(180, 22);
			ListFilesMenuItem_Add.Text = "Add to playlist";
			ListFilesMenuItem_Add.Click += ListFilesMenuItem_Add_Click;
			// 
			// ListFilesMenuItem_AddRnd
			// 
			ListFilesMenuItem_AddRnd.Name = "ListFilesMenuItem_AddRnd";
			ListFilesMenuItem_AddRnd.Size = new Size(180, 22);
			ListFilesMenuItem_AddRnd.Text = "Add to playlist (rnd)";
			ListFilesMenuItem_AddRnd.Click += ListFilesMenuItem_AddRnd_Click;
			// 
			// InpTags
			// 
			InpTags.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			InpTags.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			InpTags.AutoCompleteSource = AutoCompleteSource.ListItems;
			InpTags.FormattingEnabled = true;
			InpTags.Location = new Point(246, 46);
			InpTags.Name = "InpTags";
			InpTags.Size = new Size(144, 23);
			InpTags.TabIndex = 20;
			InpTags.TextChanged += InpTags_TextChanged;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(246, 76);
			label6.Name = "label6";
			label6.Size = new Size(80, 15);
			label6.TabIndex = 19;
			label6.Text = "Custom tag ^";
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
			// groupBox2
			// 
			groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			groupBox2.Controls.Add(PBMusicImage);
			groupBox2.Controls.Add(BtnDeleteImage);
			groupBox2.Controls.Add(InpAlbum);
			groupBox2.Controls.Add(label5);
			groupBox2.Controls.Add(InpArtists);
			groupBox2.Controls.Add(label3);
			groupBox2.Controls.Add(InpTitle);
			groupBox2.Controls.Add(label4);
			groupBox2.Location = new Point(3, 158);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(387, 109);
			groupBox2.TabIndex = 18;
			groupBox2.TabStop = false;
			groupBox2.Text = "Metadata tags";
			// 
			// PBMusicImage
			// 
			PBMusicImage.Cursor = Cursors.Hand;
			PBMusicImage.Location = new Point(329, 22);
			PBMusicImage.Name = "PBMusicImage";
			PBMusicImage.Size = new Size(52, 52);
			PBMusicImage.SizeMode = PictureBoxSizeMode.Zoom;
			PBMusicImage.TabIndex = 23;
			PBMusicImage.TabStop = false;
			PBMusicImage.Click += PBMusicImage_Click;
			// 
			// BtnDeleteImage
			// 
			BtnDeleteImage.Location = new Point(329, 80);
			BtnDeleteImage.Name = "BtnDeleteImage";
			BtnDeleteImage.Size = new Size(52, 23);
			BtnDeleteImage.TabIndex = 22;
			BtnDeleteImage.Text = "Delete";
			BtnDeleteImage.UseVisualStyleBackColor = true;
			BtnDeleteImage.Click += BtnDeleteImage_Click;
			// 
			// InpAlbum
			// 
			InpAlbum.Location = new Point(55, 80);
			InpAlbum.Name = "InpAlbum";
			InpAlbum.Size = new Size(268, 23);
			InpAlbum.TabIndex = 21;
			InpAlbum.TextChanged += InpAlbum_TextChanged;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(6, 83);
			label5.Name = "label5";
			label5.Size = new Size(43, 15);
			label5.TabIndex = 20;
			label5.Text = "Album";
			// 
			// InpArtists
			// 
			InpArtists.Location = new Point(55, 51);
			InpArtists.Name = "InpArtists";
			InpArtists.Size = new Size(268, 23);
			InpArtists.TabIndex = 19;
			InpArtists.TextChanged += InpArtists_TextChanged;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(6, 54);
			label3.Name = "label3";
			label3.Size = new Size(40, 15);
			label3.TabIndex = 18;
			label3.Text = "Artists";
			// 
			// InpTitle
			// 
			InpTitle.Location = new Point(55, 22);
			InpTitle.Name = "InpTitle";
			InpTitle.Size = new Size(268, 23);
			InpTitle.TabIndex = 17;
			InpTitle.TextChanged += InpTitle_TextChanged;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(6, 25);
			label4.Name = "label4";
			label4.Size = new Size(29, 15);
			label4.TabIndex = 16;
			label4.Text = "Title";
			// 
			// LblTime
			// 
			LblTime.AutoSize = true;
			LblTime.Location = new Point(127, 133);
			LblTime.Name = "LblTime";
			LblTime.Size = new Size(66, 15);
			LblTime.TabIndex = 14;
			LblTime.Text = "00:00/00:00";
			// 
			// LblState
			// 
			LblState.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			LblState.Location = new Point(217, 270);
			LblState.Name = "LblState";
			LblState.Size = new Size(93, 23);
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
			BtnSaveMusic.Location = new Point(316, 270);
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
			BtnExportPlaylist.Location = new Point(153, 46);
			BtnExportPlaylist.Name = "BtnExportPlaylist";
			BtnExportPlaylist.Size = new Size(56, 23);
			BtnExportPlaylist.TabIndex = 6;
			BtnExportPlaylist.Text = "Export";
			BtnExportPlaylist.UseVisualStyleBackColor = true;
			BtnExportPlaylist.Click += BtnExportPlaylist_Click;
			// 
			// MusicTimer
			// 
			MusicTimer.Enabled = true;
			MusicTimer.Interval = 1000;
			MusicTimer.Tick += MusicTimer_Tick;
			// 
			// groupBox3
			// 
			groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			groupBox3.Controls.Add(label10);
			groupBox3.Controls.Add(BtnCopyPlaylist);
			groupBox3.Controls.Add(BtnSelectCopyFolder);
			groupBox3.Controls.Add(InpCopyFolder);
			groupBox3.Controls.Add(label8);
			groupBox3.Location = new Point(584, 41);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new Size(215, 97);
			groupBox3.TabIndex = 7;
			groupBox3.TabStop = false;
			groupBox3.Text = "Export playlist";
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Location = new Point(6, 70);
			label10.Name = "label10";
			label10.Size = new Size(137, 15);
			label10.TabIndex = 13;
			label10.Text = "Subfolder will be created";
			// 
			// BtnCopyPlaylist
			// 
			BtnCopyPlaylist.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			BtnCopyPlaylist.Location = new Point(153, 66);
			BtnCopyPlaylist.Name = "BtnCopyPlaylist";
			BtnCopyPlaylist.Size = new Size(56, 23);
			BtnCopyPlaylist.TabIndex = 12;
			BtnCopyPlaylist.Text = "Copy";
			BtnCopyPlaylist.UseVisualStyleBackColor = true;
			BtnCopyPlaylist.Click += BtnCopyPlaylist_Click;
			// 
			// BtnSelectCopyFolder
			// 
			BtnSelectCopyFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			BtnSelectCopyFolder.Location = new Point(186, 37);
			BtnSelectCopyFolder.Name = "BtnSelectCopyFolder";
			BtnSelectCopyFolder.Size = new Size(23, 23);
			BtnSelectCopyFolder.TabIndex = 11;
			BtnSelectCopyFolder.Text = "S";
			BtnSelectCopyFolder.UseVisualStyleBackColor = true;
			BtnSelectCopyFolder.Click += BtnSelectCopyFolder_Click;
			// 
			// InpCopyFolder
			// 
			InpCopyFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			InpCopyFolder.Location = new Point(6, 37);
			InpCopyFolder.Name = "InpCopyFolder";
			InpCopyFolder.Size = new Size(178, 23);
			InpCopyFolder.TabIndex = 10;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new Point(6, 19);
			label8.Name = "label8";
			label8.Size = new Size(73, 15);
			label8.TabIndex = 9;
			label8.Text = "Copy files to";
			// 
			// BtnSpExport
			// 
			BtnSpExport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			BtnSpExport.Location = new Point(609, 12);
			BtnSpExport.Name = "BtnSpExport";
			BtnSpExport.Size = new Size(96, 23);
			BtnSpExport.TabIndex = 13;
			BtnSpExport.Text = "Special export";
			BtnSpExport.UseVisualStyleBackColor = true;
			BtnSpExport.Click += BtnSpExport_Click;
			// 
			// BtnExportHelp
			// 
			BtnExportHelp.Location = new Point(79, 46);
			BtnExportHelp.Name = "BtnExportHelp";
			BtnExportHelp.Size = new Size(23, 23);
			BtnExportHelp.TabIndex = 8;
			BtnExportHelp.Text = "?";
			BtnExportHelp.UseVisualStyleBackColor = true;
			BtnExportHelp.Click += BtnExportHelp_Click;
			// 
			// InpExportRel
			// 
			InpExportRel.AutoSize = true;
			InpExportRel.Checked = true;
			InpExportRel.CheckState = CheckState.Checked;
			InpExportRel.Location = new Point(6, 48);
			InpExportRel.Name = "InpExportRel";
			InpExportRel.Size = new Size(67, 19);
			InpExportRel.TabIndex = 7;
			InpExportRel.Text = "Relative";
			InpExportRel.UseVisualStyleBackColor = true;
			InpExportRel.CheckedChanged += InpExportRel_CheckedChanged;
			// 
			// groupBox4
			// 
			groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			groupBox4.Controls.Add(BtnSelectExportFolder);
			groupBox4.Controls.Add(InpExportFolder);
			groupBox4.Controls.Add(label9);
			groupBox4.Controls.Add(BtnExportPlaylist);
			groupBox4.Controls.Add(InpExportRel);
			groupBox4.Controls.Add(BtnExportHelp);
			groupBox4.Location = new Point(584, 144);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new Size(215, 75);
			groupBox4.TabIndex = 9;
			groupBox4.TabStop = false;
			groupBox4.Text = "Export playlist .m3u8";
			// 
			// BtnSelectExportFolder
			// 
			BtnSelectExportFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			BtnSelectExportFolder.Location = new Point(186, 19);
			BtnSelectExportFolder.Name = "BtnSelectExportFolder";
			BtnSelectExportFolder.Size = new Size(23, 23);
			BtnSelectExportFolder.TabIndex = 12;
			BtnSelectExportFolder.Text = "S";
			BtnSelectExportFolder.UseVisualStyleBackColor = true;
			BtnSelectExportFolder.Click += BtnSelectExportFolder_Click;
			// 
			// InpExportFolder
			// 
			InpExportFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			InpExportFolder.Location = new Point(31, 19);
			InpExportFolder.Name = "InpExportFolder";
			InpExportFolder.Size = new Size(153, 23);
			InpExportFolder.TabIndex = 10;
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new Point(6, 22);
			label9.Name = "label9";
			label9.Size = new Size(19, 15);
			label9.TabIndex = 9;
			label9.Text = "To";
			// 
			// BtnSync
			// 
			BtnSync.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			BtnSync.Location = new Point(711, 12);
			BtnSync.Name = "BtnSync";
			BtnSync.Size = new Size(88, 23);
			BtnSync.TabIndex = 10;
			BtnSync.Text = "Sync folders";
			BtnSync.UseVisualStyleBackColor = true;
			BtnSync.Click += BtnSync_Click;
			// 
			// BtnPlayer
			// 
			BtnPlayer.Location = new Point(269, 12);
			BtnPlayer.Name = "BtnPlayer";
			BtnPlayer.Size = new Size(61, 23);
			BtnPlayer.TabIndex = 14;
			BtnPlayer.Text = "Player";
			BtnPlayer.UseVisualStyleBackColor = true;
			BtnPlayer.Click += BtnPlayer_Click;
			// 
			// ListFilesMenuItem_AddAll
			// 
			ListFilesMenuItem_AddAll.Name = "ListFilesMenuItem_AddAll";
			ListFilesMenuItem_AddAll.Size = new Size(180, 22);
			ListFilesMenuItem_AddAll.Text = "Add all to playlist";
			ListFilesMenuItem_AddAll.Click += ListFilesMenuItem_AddAll_Click;
			// 
			// FormMain
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(811, 533);
			Controls.Add(BtnPlayer);
			Controls.Add(BtnSpExport);
			Controls.Add(BtnSync);
			Controls.Add(groupBox4);
			Controls.Add(groupBox3);
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
			ListFilesMenu.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)PBMusicImage).EndInit();
			((System.ComponentModel.ISupportInitialize)InpMusicTime).EndInit();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			groupBox4.ResumeLayout(false);
			groupBox4.PerformLayout();
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
		private Label LblTime;
		private GroupBox groupBox2;
		private TextBox InpTitle;
		private Label label4;
		private TextBox InpAlbum;
		private Label label5;
		private TextBox InpArtists;
		private Label label3;
		private PictureBox PBMusicImage;
		private Button BtnDeleteImage;
		private ComboBox InpTags;
		private Label label6;
		private ComboBox FilterTags;
		private Label label7;
		private GroupBox groupBox3;
		private Button BtnExportHelp;
		private CheckBox InpExportRel;
		private TextBox InpCopyFolder;
		private Label label8;
		private Button BtnCopyPlaylist;
		private Button BtnSelectCopyFolder;
		private GroupBox groupBox4;
		private Button BtnSelectExportFolder;
		private TextBox InpExportFolder;
		private Label label9;
		private FolderBrowserDialog FolderBrowser;
		private Button BtnSync;
		private Button BtnSpExport;
		private Label label10;
		private ContextMenuStrip ListFilesMenu;
		private ToolStripMenuItem ListFilesMenuItem_Add;
		private ToolStripMenuItem ListFilesMenuItem_AddRnd;
		private Button BtnPlayer;
		private ToolStripMenuItem ListFilesMenuItem_AddAll;
	}
}
namespace Melodorium
{
	partial class FormManageFiles
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormManageFiles));
			label1 = new Label();
			splitContainer1 = new SplitContainer();
			ListProblems = new ListView();
			columnHeader1 = new ColumnHeader();
			BtnOpenInExplorer = new Button();
			label5 = new Label();
			PBAlreadyExist = new PictureBox();
			PBGoodName = new PictureBox();
			label4 = new Label();
			label3 = new Label();
			BtnRename = new Button();
			InpRenameNew = new TextBox();
			InpRenameOld = new TextBox();
			label2 = new Label();
			label6 = new Label();
			splitContainer2 = new SplitContainer();
			ListFolders = new ListView();
			columnHeader2 = new ColumnHeader();
			BtnSave = new Button();
			BtnOpenInExplorerFolder = new Button();
			InpAuthorMode_Any = new RadioButton();
			InpAuthorMode_Manual = new RadioButton();
			InpAuthorMode_Auto = new RadioButton();
			InpAuthor = new TextBox();
			label8 = new Label();
			InpFolder = new TextBox();
			label7 = new Label();
			label9 = new Label();
			splitContainer3 = new SplitContainer();
			ListMismatch = new ListView();
			columnHeader3 = new ColumnHeader();
			PBAlreadyExistMismatch = new PictureBox();
			label13 = new Label();
			BtnMoveMismatch = new Button();
			splitContainer4 = new SplitContainer();
			label11 = new Label();
			InpMismatchFolder = new TextBox();
			label12 = new Label();
			InpMismatchFolderExpected = new TextBox();
			InpMismatchName = new TextBox();
			label10 = new Label();
			BtnOpenInExplorerMismatch = new Button();
			Tabs = new TabControl();
			tabPage1 = new TabPage();
			tabPage2 = new TabPage();
			tabPage3 = new TabPage();
			tabPage4 = new TabPage();
			splitContainer5 = new SplitContainer();
			ListSimilar = new ListView();
			columnHeader4 = new ColumnHeader();
			BtnApplySimilarity = new Button();
			LblSimiarityLevel = new Label();
			label17 = new Label();
			InpSimiarityLevel = new TrackBar();
			CbxStrictComparison = new CheckBox();
			CbxIgnoreAuthor = new CheckBox();
			label16 = new Label();
			ListSimilarFiles = new ListView();
			columnHeader5 = new ColumnHeader();
			label15 = new Label();
			label14 = new Label();
			tabPage5 = new TabPage();
			label21 = new Label();
			splitContainer6 = new SplitContainer();
			TreeGroup = new TreeView();
			LblGroupFolderExist = new Label();
			BtnMoveGroup = new Button();
			label20 = new Label();
			InpGroupName = new TextBox();
			InpItemsInGroup = new NumericUpDown();
			label19 = new Label();
			label18 = new Label();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)PBAlreadyExist).BeginInit();
			((System.ComponentModel.ISupportInitialize)PBGoodName).BeginInit();
			((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
			splitContainer2.Panel1.SuspendLayout();
			splitContainer2.Panel2.SuspendLayout();
			splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
			splitContainer3.Panel1.SuspendLayout();
			splitContainer3.Panel2.SuspendLayout();
			splitContainer3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)PBAlreadyExistMismatch).BeginInit();
			((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
			splitContainer4.Panel1.SuspendLayout();
			splitContainer4.Panel2.SuspendLayout();
			splitContainer4.SuspendLayout();
			Tabs.SuspendLayout();
			tabPage1.SuspendLayout();
			tabPage2.SuspendLayout();
			tabPage3.SuspendLayout();
			tabPage4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer5).BeginInit();
			splitContainer5.Panel1.SuspendLayout();
			splitContainer5.Panel2.SuspendLayout();
			splitContainer5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)InpSimiarityLevel).BeginInit();
			tabPage5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer6).BeginInit();
			splitContainer6.Panel1.SuspendLayout();
			splitContainer6.Panel2.SuspendLayout();
			splitContainer6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)InpItemsInGroup).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(3, 3);
			label1.Name = "label1";
			label1.Size = new Size(132, 15);
			label1.TabIndex = 0;
			label1.Text = "Problems with filename";
			// 
			// splitContainer1
			// 
			splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			splitContainer1.Location = new Point(0, 21);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(ListProblems);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(BtnOpenInExplorer);
			splitContainer1.Panel2.Controls.Add(label5);
			splitContainer1.Panel2.Controls.Add(PBAlreadyExist);
			splitContainer1.Panel2.Controls.Add(PBGoodName);
			splitContainer1.Panel2.Controls.Add(label4);
			splitContainer1.Panel2.Controls.Add(label3);
			splitContainer1.Panel2.Controls.Add(BtnRename);
			splitContainer1.Panel2.Controls.Add(InpRenameNew);
			splitContainer1.Panel2.Controls.Add(InpRenameOld);
			splitContainer1.Panel2.Controls.Add(label2);
			splitContainer1.Size = new Size(777, 382);
			splitContainer1.SplitterDistance = 372;
			splitContainer1.TabIndex = 1;
			// 
			// ListProblems
			// 
			ListProblems.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
			ListProblems.Dock = DockStyle.Fill;
			ListProblems.Location = new Point(0, 0);
			ListProblems.MultiSelect = false;
			ListProblems.Name = "ListProblems";
			ListProblems.Size = new Size(372, 382);
			ListProblems.TabIndex = 0;
			ListProblems.UseCompatibleStateImageBehavior = false;
			ListProblems.View = View.Details;
			ListProblems.SelectedIndexChanged += ListProblems_SelectedIndexChanged;
			// 
			// columnHeader1
			// 
			columnHeader1.Text = "Path";
			columnHeader1.Width = 340;
			// 
			// BtnOpenInExplorer
			// 
			BtnOpenInExplorer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			BtnOpenInExplorer.Enabled = false;
			BtnOpenInExplorer.Location = new Point(291, 101);
			BtnOpenInExplorer.Name = "BtnOpenInExplorer";
			BtnOpenInExplorer.Size = new Size(107, 23);
			BtnOpenInExplorer.TabIndex = 9;
			BtnOpenInExplorer.Text = "Open in explorer";
			BtnOpenInExplorer.UseVisualStyleBackColor = true;
			BtnOpenInExplorer.Click += BtnOpenInExplorer_Click;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(3, 105);
			label5.Name = "label5";
			label5.Size = new Size(238, 15);
			label5.TabIndex = 8;
			label5.Text = "Name example: Group_name_-_Song_name";
			// 
			// PBAlreadyExist
			// 
			PBAlreadyExist.Location = new Point(198, 80);
			PBAlreadyExist.Name = "PBAlreadyExist";
			PBAlreadyExist.Size = new Size(16, 16);
			PBAlreadyExist.TabIndex = 7;
			PBAlreadyExist.TabStop = false;
			// 
			// PBGoodName
			// 
			PBGoodName.Location = new Point(81, 80);
			PBGoodName.Name = "PBGoodName";
			PBGoodName.Size = new Size(16, 16);
			PBGoodName.TabIndex = 6;
			PBGoodName.TabStop = false;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(115, 80);
			label4.Name = "label4";
			label4.Size = new Size(77, 15);
			label4.TabIndex = 5;
			label4.Text = "Already exist:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(3, 80);
			label3.Name = "label3";
			label3.Size = new Size(72, 15);
			label3.TabIndex = 4;
			label3.Text = "Good name:";
			// 
			// BtnRename
			// 
			BtnRename.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			BtnRename.Enabled = false;
			BtnRename.Location = new Point(323, 76);
			BtnRename.Name = "BtnRename";
			BtnRename.Size = new Size(75, 23);
			BtnRename.TabIndex = 3;
			BtnRename.Text = "Rename";
			BtnRename.UseVisualStyleBackColor = true;
			BtnRename.Click += BtnRename_Click;
			// 
			// InpRenameNew
			// 
			InpRenameNew.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			InpRenameNew.Location = new Point(3, 47);
			InpRenameNew.Name = "InpRenameNew";
			InpRenameNew.Size = new Size(395, 23);
			InpRenameNew.TabIndex = 2;
			InpRenameNew.TextChanged += InpRenameNew_TextChanged;
			// 
			// InpRenameOld
			// 
			InpRenameOld.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			InpRenameOld.Location = new Point(3, 18);
			InpRenameOld.Name = "InpRenameOld";
			InpRenameOld.ReadOnly = true;
			InpRenameOld.Size = new Size(395, 23);
			InpRenameOld.TabIndex = 1;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(3, 0);
			label2.Name = "label2";
			label2.Size = new Size(50, 15);
			label2.TabIndex = 0;
			label2.Text = "Rename";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(3, 3);
			label6.Name = "label6";
			label6.Size = new Size(103, 15);
			label6.TabIndex = 2;
			label6.Text = "Authors in Folders";
			// 
			// splitContainer2
			// 
			splitContainer2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			splitContainer2.Location = new Point(0, 21);
			splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			splitContainer2.Panel1.Controls.Add(ListFolders);
			// 
			// splitContainer2.Panel2
			// 
			splitContainer2.Panel2.Controls.Add(BtnSave);
			splitContainer2.Panel2.Controls.Add(BtnOpenInExplorerFolder);
			splitContainer2.Panel2.Controls.Add(InpAuthorMode_Any);
			splitContainer2.Panel2.Controls.Add(InpAuthorMode_Manual);
			splitContainer2.Panel2.Controls.Add(InpAuthorMode_Auto);
			splitContainer2.Panel2.Controls.Add(InpAuthor);
			splitContainer2.Panel2.Controls.Add(label8);
			splitContainer2.Panel2.Controls.Add(InpFolder);
			splitContainer2.Panel2.Controls.Add(label7);
			splitContainer2.Size = new Size(774, 382);
			splitContainer2.SplitterDistance = 372;
			splitContainer2.TabIndex = 3;
			// 
			// ListFolders
			// 
			ListFolders.Columns.AddRange(new ColumnHeader[] { columnHeader2 });
			ListFolders.Dock = DockStyle.Fill;
			ListFolders.Location = new Point(0, 0);
			ListFolders.MultiSelect = false;
			ListFolders.Name = "ListFolders";
			ListFolders.Size = new Size(372, 382);
			ListFolders.TabIndex = 0;
			ListFolders.UseCompatibleStateImageBehavior = false;
			ListFolders.View = View.Details;
			ListFolders.SelectedIndexChanged += ListFolders_SelectedIndexChanged;
			// 
			// columnHeader2
			// 
			columnHeader2.Text = "Folder";
			columnHeader2.Width = 340;
			// 
			// BtnSave
			// 
			BtnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			BtnSave.Enabled = false;
			BtnSave.Location = new Point(291, 117);
			BtnSave.Name = "BtnSave";
			BtnSave.Size = new Size(104, 23);
			BtnSave.TabIndex = 11;
			BtnSave.Text = "Save all changes";
			BtnSave.UseVisualStyleBackColor = true;
			BtnSave.Click += BtnSave_Click;
			// 
			// BtnOpenInExplorerFolder
			// 
			BtnOpenInExplorerFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			BtnOpenInExplorerFolder.Enabled = false;
			BtnOpenInExplorerFolder.Location = new Point(288, 65);
			BtnOpenInExplorerFolder.Name = "BtnOpenInExplorerFolder";
			BtnOpenInExplorerFolder.Size = new Size(107, 23);
			BtnOpenInExplorerFolder.TabIndex = 10;
			BtnOpenInExplorerFolder.Text = "Open in explorer";
			BtnOpenInExplorerFolder.UseVisualStyleBackColor = true;
			BtnOpenInExplorerFolder.Click += BtnOpenInExplorerFolder_Click;
			// 
			// InpAuthorMode_Any
			// 
			InpAuthorMode_Any.AutoSize = true;
			InpAuthorMode_Any.Location = new Point(179, 69);
			InpAuthorMode_Any.Name = "InpAuthorMode_Any";
			InpAuthorMode_Any.Size = new Size(44, 19);
			InpAuthorMode_Any.TabIndex = 6;
			InpAuthorMode_Any.Text = "any";
			InpAuthorMode_Any.UseVisualStyleBackColor = true;
			InpAuthorMode_Any.CheckedChanged += InpAuthorMode_Any_CheckedChanged;
			// 
			// InpAuthorMode_Manual
			// 
			InpAuthorMode_Manual.AutoSize = true;
			InpAuthorMode_Manual.Location = new Point(108, 69);
			InpAuthorMode_Manual.Name = "InpAuthorMode_Manual";
			InpAuthorMode_Manual.Size = new Size(65, 19);
			InpAuthorMode_Manual.TabIndex = 5;
			InpAuthorMode_Manual.Text = "manual";
			InpAuthorMode_Manual.UseVisualStyleBackColor = true;
			InpAuthorMode_Manual.CheckedChanged += InpAuthorMode_Manual_CheckedChanged;
			// 
			// InpAuthorMode_Auto
			// 
			InpAuthorMode_Auto.AutoSize = true;
			InpAuthorMode_Auto.Checked = true;
			InpAuthorMode_Auto.Location = new Point(53, 67);
			InpAuthorMode_Auto.Name = "InpAuthorMode_Auto";
			InpAuthorMode_Auto.Size = new Size(49, 19);
			InpAuthorMode_Auto.TabIndex = 4;
			InpAuthorMode_Auto.TabStop = true;
			InpAuthorMode_Auto.Text = "auto";
			InpAuthorMode_Auto.UseVisualStyleBackColor = true;
			InpAuthorMode_Auto.CheckedChanged += InpAuthorMode_Auto_CheckedChanged;
			// 
			// InpAuthor
			// 
			InpAuthor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			InpAuthor.Location = new Point(53, 36);
			InpAuthor.Name = "InpAuthor";
			InpAuthor.ReadOnly = true;
			InpAuthor.Size = new Size(342, 23);
			InpAuthor.TabIndex = 3;
			InpAuthor.TextChanged += InpAuthor_TextChanged;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new Point(3, 39);
			label8.Name = "label8";
			label8.Size = new Size(44, 15);
			label8.TabIndex = 2;
			label8.Text = "Author";
			// 
			// InpFolder
			// 
			InpFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			InpFolder.Location = new Point(53, 7);
			InpFolder.Name = "InpFolder";
			InpFolder.ReadOnly = true;
			InpFolder.Size = new Size(342, 23);
			InpFolder.TabIndex = 1;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(3, 10);
			label7.Name = "label7";
			label7.Size = new Size(40, 15);
			label7.TabIndex = 0;
			label7.Text = "Folder";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new Point(3, 3);
			label9.Name = "label9";
			label9.Size = new Size(158, 15);
			label9.TabIndex = 4;
			label9.Text = "Mismatch author with folder";
			// 
			// splitContainer3
			// 
			splitContainer3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			splitContainer3.Location = new Point(0, 21);
			splitContainer3.Name = "splitContainer3";
			// 
			// splitContainer3.Panel1
			// 
			splitContainer3.Panel1.Controls.Add(ListMismatch);
			// 
			// splitContainer3.Panel2
			// 
			splitContainer3.Panel2.Controls.Add(PBAlreadyExistMismatch);
			splitContainer3.Panel2.Controls.Add(label13);
			splitContainer3.Panel2.Controls.Add(BtnMoveMismatch);
			splitContainer3.Panel2.Controls.Add(splitContainer4);
			splitContainer3.Panel2.Controls.Add(InpMismatchName);
			splitContainer3.Panel2.Controls.Add(label10);
			splitContainer3.Panel2.Controls.Add(BtnOpenInExplorerMismatch);
			splitContainer3.Size = new Size(774, 382);
			splitContainer3.SplitterDistance = 372;
			splitContainer3.TabIndex = 5;
			// 
			// ListMismatch
			// 
			ListMismatch.Columns.AddRange(new ColumnHeader[] { columnHeader3 });
			ListMismatch.Dock = DockStyle.Fill;
			ListMismatch.Location = new Point(0, 0);
			ListMismatch.MultiSelect = false;
			ListMismatch.Name = "ListMismatch";
			ListMismatch.Size = new Size(372, 382);
			ListMismatch.TabIndex = 1;
			ListMismatch.UseCompatibleStateImageBehavior = false;
			ListMismatch.View = View.Details;
			ListMismatch.SelectedIndexChanged += ListMismatch_SelectedIndexChanged;
			// 
			// columnHeader3
			// 
			columnHeader3.Text = "File";
			columnHeader3.Width = 340;
			// 
			// PBAlreadyExistMismatch
			// 
			PBAlreadyExistMismatch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			PBAlreadyExistMismatch.Location = new Point(274, 69);
			PBAlreadyExistMismatch.Name = "PBAlreadyExistMismatch";
			PBAlreadyExistMismatch.Size = new Size(16, 16);
			PBAlreadyExistMismatch.TabIndex = 20;
			PBAlreadyExistMismatch.TabStop = false;
			// 
			// label13
			// 
			label13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			label13.AutoSize = true;
			label13.Location = new Point(191, 69);
			label13.Name = "label13";
			label13.Size = new Size(77, 15);
			label13.TabIndex = 19;
			label13.Text = "Already exist:";
			// 
			// BtnMoveMismatch
			// 
			BtnMoveMismatch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			BtnMoveMismatch.Enabled = false;
			BtnMoveMismatch.Location = new Point(320, 65);
			BtnMoveMismatch.Name = "BtnMoveMismatch";
			BtnMoveMismatch.Size = new Size(75, 23);
			BtnMoveMismatch.TabIndex = 18;
			BtnMoveMismatch.Text = "Move";
			BtnMoveMismatch.UseVisualStyleBackColor = true;
			BtnMoveMismatch.Click += BtnMoveMismatch_Click;
			// 
			// splitContainer4
			// 
			splitContainer4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			splitContainer4.IsSplitterFixed = true;
			splitContainer4.Location = new Point(2, 36);
			splitContainer4.Name = "splitContainer4";
			// 
			// splitContainer4.Panel1
			// 
			splitContainer4.Panel1.Controls.Add(label11);
			splitContainer4.Panel1.Controls.Add(InpMismatchFolder);
			// 
			// splitContainer4.Panel2
			// 
			splitContainer4.Panel2.Controls.Add(label12);
			splitContainer4.Panel2.Controls.Add(InpMismatchFolderExpected);
			splitContainer4.Size = new Size(393, 23);
			splitContainer4.SplitterDistance = 186;
			splitContainer4.SplitterWidth = 1;
			splitContainer4.TabIndex = 17;
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Location = new Point(-1, 3);
			label11.Name = "label11";
			label11.Size = new Size(40, 15);
			label11.TabIndex = 13;
			label11.Text = "Folder";
			// 
			// InpMismatchFolder
			// 
			InpMismatchFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			InpMismatchFolder.Location = new Point(51, 0);
			InpMismatchFolder.Name = "InpMismatchFolder";
			InpMismatchFolder.ReadOnly = true;
			InpMismatchFolder.Size = new Size(135, 23);
			InpMismatchFolder.TabIndex = 14;
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Location = new Point(2, 3);
			label12.Name = "label12";
			label12.Size = new Size(55, 15);
			label12.TabIndex = 15;
			label12.Text = "Expected";
			// 
			// InpMismatchFolderExpected
			// 
			InpMismatchFolderExpected.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			InpMismatchFolderExpected.Location = new Point(63, 0);
			InpMismatchFolderExpected.Name = "InpMismatchFolderExpected";
			InpMismatchFolderExpected.ReadOnly = true;
			InpMismatchFolderExpected.Size = new Size(239, 23);
			InpMismatchFolderExpected.TabIndex = 16;
			// 
			// InpMismatchName
			// 
			InpMismatchName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			InpMismatchName.Location = new Point(53, 7);
			InpMismatchName.Name = "InpMismatchName";
			InpMismatchName.ReadOnly = true;
			InpMismatchName.Size = new Size(342, 23);
			InpMismatchName.TabIndex = 12;
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Location = new Point(2, 10);
			label10.Name = "label10";
			label10.Size = new Size(39, 15);
			label10.TabIndex = 11;
			label10.Text = "Name";
			// 
			// BtnOpenInExplorerMismatch
			// 
			BtnOpenInExplorerMismatch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			BtnOpenInExplorerMismatch.Enabled = false;
			BtnOpenInExplorerMismatch.Location = new Point(288, 105);
			BtnOpenInExplorerMismatch.Name = "BtnOpenInExplorerMismatch";
			BtnOpenInExplorerMismatch.Size = new Size(107, 23);
			BtnOpenInExplorerMismatch.TabIndex = 10;
			BtnOpenInExplorerMismatch.Text = "Open in explorer";
			BtnOpenInExplorerMismatch.UseVisualStyleBackColor = true;
			BtnOpenInExplorerMismatch.Click += BtnOpenInExplorerMismatch_Click;
			// 
			// Tabs
			// 
			Tabs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			Tabs.Controls.Add(tabPage1);
			Tabs.Controls.Add(tabPage2);
			Tabs.Controls.Add(tabPage3);
			Tabs.Controls.Add(tabPage4);
			Tabs.Controls.Add(tabPage5);
			Tabs.Location = new Point(9, 12);
			Tabs.Name = "Tabs";
			Tabs.SelectedIndex = 0;
			Tabs.Size = new Size(785, 431);
			Tabs.TabIndex = 6;
			Tabs.SelectedIndexChanged += Tabs_SelectedIndexChanged;
			// 
			// tabPage1
			// 
			tabPage1.Controls.Add(splitContainer1);
			tabPage1.Controls.Add(label1);
			tabPage1.Location = new Point(4, 24);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new Padding(3);
			tabPage1.Size = new Size(777, 403);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "Filename";
			tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			tabPage2.Controls.Add(label6);
			tabPage2.Controls.Add(splitContainer2);
			tabPage2.Location = new Point(4, 24);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new Padding(3);
			tabPage2.Size = new Size(777, 403);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "Authors";
			tabPage2.UseVisualStyleBackColor = true;
			// 
			// tabPage3
			// 
			tabPage3.Controls.Add(label9);
			tabPage3.Controls.Add(splitContainer3);
			tabPage3.Location = new Point(4, 24);
			tabPage3.Name = "tabPage3";
			tabPage3.Size = new Size(777, 403);
			tabPage3.TabIndex = 2;
			tabPage3.Text = "Mismatch";
			tabPage3.UseVisualStyleBackColor = true;
			// 
			// tabPage4
			// 
			tabPage4.Controls.Add(splitContainer5);
			tabPage4.Controls.Add(label14);
			tabPage4.Location = new Point(4, 24);
			tabPage4.Name = "tabPage4";
			tabPage4.Padding = new Padding(3);
			tabPage4.Size = new Size(777, 403);
			tabPage4.TabIndex = 3;
			tabPage4.Text = "Doubles";
			tabPage4.UseVisualStyleBackColor = true;
			// 
			// splitContainer5
			// 
			splitContainer5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			splitContainer5.Location = new Point(0, 21);
			splitContainer5.Name = "splitContainer5";
			// 
			// splitContainer5.Panel1
			// 
			splitContainer5.Panel1.Controls.Add(ListSimilar);
			// 
			// splitContainer5.Panel2
			// 
			splitContainer5.Panel2.Controls.Add(BtnApplySimilarity);
			splitContainer5.Panel2.Controls.Add(LblSimiarityLevel);
			splitContainer5.Panel2.Controls.Add(label17);
			splitContainer5.Panel2.Controls.Add(InpSimiarityLevel);
			splitContainer5.Panel2.Controls.Add(CbxStrictComparison);
			splitContainer5.Panel2.Controls.Add(CbxIgnoreAuthor);
			splitContainer5.Panel2.Controls.Add(label16);
			splitContainer5.Panel2.Controls.Add(ListSimilarFiles);
			splitContainer5.Panel2.Controls.Add(label15);
			splitContainer5.Size = new Size(774, 382);
			splitContainer5.SplitterDistance = 372;
			splitContainer5.TabIndex = 6;
			// 
			// ListSimilar
			// 
			ListSimilar.Columns.AddRange(new ColumnHeader[] { columnHeader4 });
			ListSimilar.Dock = DockStyle.Fill;
			ListSimilar.Location = new Point(0, 0);
			ListSimilar.MultiSelect = false;
			ListSimilar.Name = "ListSimilar";
			ListSimilar.Size = new Size(372, 382);
			ListSimilar.TabIndex = 1;
			ListSimilar.UseCompatibleStateImageBehavior = false;
			ListSimilar.View = View.Details;
			ListSimilar.SelectedIndexChanged += ListSimilar_SelectedIndexChanged;
			// 
			// columnHeader4
			// 
			columnHeader4.Text = "Name";
			columnHeader4.Width = 340;
			// 
			// BtnApplySimilarity
			// 
			BtnApplySimilarity.Enabled = false;
			BtnApplySimilarity.Location = new Point(320, 284);
			BtnApplySimilarity.Name = "BtnApplySimilarity";
			BtnApplySimilarity.Size = new Size(75, 23);
			BtnApplySimilarity.TabIndex = 9;
			BtnApplySimilarity.Text = "Apply";
			BtnApplySimilarity.UseVisualStyleBackColor = true;
			BtnApplySimilarity.Click += BtnApplySimilarity_Click;
			// 
			// LblSimiarityLevel
			// 
			LblSimiarityLevel.AutoSize = true;
			LblSimiarityLevel.Location = new Point(224, 288);
			LblSimiarityLevel.Name = "LblSimiarityLevel";
			LblSimiarityLevel.Size = new Size(29, 15);
			LblSimiarityLevel.TabIndex = 8;
			LblSimiarityLevel.Text = "00%";
			// 
			// label17
			// 
			label17.AutoSize = true;
			label17.Location = new Point(132, 288);
			label17.Name = "label17";
			label17.Size = new Size(86, 15);
			label17.TabIndex = 7;
			label17.Text = "Similarity level:";
			// 
			// InpSimiarityLevel
			// 
			InpSimiarityLevel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			InpSimiarityLevel.Enabled = false;
			InpSimiarityLevel.LargeChange = 8;
			InpSimiarityLevel.Location = new Point(132, 258);
			InpSimiarityLevel.Maximum = 100;
			InpSimiarityLevel.Minimum = 50;
			InpSimiarityLevel.Name = "InpSimiarityLevel";
			InpSimiarityLevel.Size = new Size(263, 45);
			InpSimiarityLevel.SmallChange = 2;
			InpSimiarityLevel.TabIndex = 6;
			InpSimiarityLevel.Value = 85;
			InpSimiarityLevel.Scroll += InpSimiarityLevel_Scroll;
			// 
			// CbxStrictComparison
			// 
			CbxStrictComparison.AutoSize = true;
			CbxStrictComparison.Checked = true;
			CbxStrictComparison.CheckState = CheckState.Checked;
			CbxStrictComparison.Location = new Point(2, 258);
			CbxStrictComparison.Name = "CbxStrictComparison";
			CbxStrictComparison.Size = new Size(119, 19);
			CbxStrictComparison.TabIndex = 5;
			CbxStrictComparison.Text = "Strict comparison";
			CbxStrictComparison.UseVisualStyleBackColor = true;
			CbxStrictComparison.CheckedChanged += CbxStrictComparison_CheckedChanged;
			// 
			// CbxIgnoreAuthor
			// 
			CbxIgnoreAuthor.AutoSize = true;
			CbxIgnoreAuthor.Location = new Point(2, 283);
			CbxIgnoreAuthor.Name = "CbxIgnoreAuthor";
			CbxIgnoreAuthor.Size = new Size(103, 19);
			CbxIgnoreAuthor.TabIndex = 4;
			CbxIgnoreAuthor.Text = "Ignore authors";
			CbxIgnoreAuthor.UseVisualStyleBackColor = true;
			CbxIgnoreAuthor.CheckedChanged += CbxIgnoreAuthor_CheckedChanged;
			// 
			// label16
			// 
			label16.AutoSize = true;
			label16.Location = new Point(3, 214);
			label16.Name = "label16";
			label16.Size = new Size(133, 15);
			label16.TabIndex = 3;
			label16.Text = "Cick to open in explorer";
			// 
			// ListSimilarFiles
			// 
			ListSimilarFiles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			ListSimilarFiles.Columns.AddRange(new ColumnHeader[] { columnHeader5 });
			ListSimilarFiles.Location = new Point(3, 18);
			ListSimilarFiles.MultiSelect = false;
			ListSimilarFiles.Name = "ListSimilarFiles";
			ListSimilarFiles.Size = new Size(392, 193);
			ListSimilarFiles.TabIndex = 2;
			ListSimilarFiles.UseCompatibleStateImageBehavior = false;
			ListSimilarFiles.View = View.Details;
			ListSimilarFiles.SelectedIndexChanged += ListSimilarFiles_SelectedIndexChanged;
			// 
			// columnHeader5
			// 
			columnHeader5.Text = "File";
			columnHeader5.Width = 365;
			// 
			// label15
			// 
			label15.AutoSize = true;
			label15.Location = new Point(3, 0);
			label15.Name = "label15";
			label15.Size = new Size(46, 15);
			label15.TabIndex = 0;
			label15.Text = "Similar:";
			// 
			// label14
			// 
			label14.AutoSize = true;
			label14.Location = new Point(3, 3);
			label14.Name = "label14";
			label14.Size = new Size(97, 15);
			label14.TabIndex = 5;
			label14.Text = "Similar filenames";
			// 
			// tabPage5
			// 
			tabPage5.Controls.Add(label21);
			tabPage5.Controls.Add(splitContainer6);
			tabPage5.Controls.Add(label18);
			tabPage5.Location = new Point(4, 24);
			tabPage5.Name = "tabPage5";
			tabPage5.Padding = new Padding(3);
			tabPage5.Size = new Size(777, 403);
			tabPage5.TabIndex = 4;
			tabPage5.Text = "Group";
			tabPage5.UseVisualStyleBackColor = true;
			// 
			// label21
			// 
			label21.AutoSize = true;
			label21.Location = new Point(199, 3);
			label21.Name = "label21";
			label21.Size = new Size(173, 15);
			label21.TabIndex = 8;
			label21.Text = "dbl click to open file in explorer";
			// 
			// splitContainer6
			// 
			splitContainer6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			splitContainer6.Location = new Point(0, 21);
			splitContainer6.Name = "splitContainer6";
			// 
			// splitContainer6.Panel1
			// 
			splitContainer6.Panel1.Controls.Add(TreeGroup);
			// 
			// splitContainer6.Panel2
			// 
			splitContainer6.Panel2.Controls.Add(LblGroupFolderExist);
			splitContainer6.Panel2.Controls.Add(BtnMoveGroup);
			splitContainer6.Panel2.Controls.Add(label20);
			splitContainer6.Panel2.Controls.Add(InpGroupName);
			splitContainer6.Panel2.Controls.Add(InpItemsInGroup);
			splitContainer6.Panel2.Controls.Add(label19);
			splitContainer6.Size = new Size(775, 382);
			splitContainer6.SplitterDistance = 372;
			splitContainer6.TabIndex = 7;
			// 
			// TreeGroup
			// 
			TreeGroup.Dock = DockStyle.Fill;
			TreeGroup.Location = new Point(0, 0);
			TreeGroup.Name = "TreeGroup";
			TreeGroup.Size = new Size(372, 382);
			TreeGroup.TabIndex = 0;
			TreeGroup.NodeMouseClick += TreeGroup_NodeMouseClick;
			TreeGroup.NodeMouseDoubleClick += TreeGroup_NodeMouseDoubleClick;
			// 
			// LblGroupFolderExist
			// 
			LblGroupFolderExist.AutoSize = true;
			LblGroupFolderExist.Location = new Point(208, 69);
			LblGroupFolderExist.Name = "LblGroupFolderExist";
			LblGroupFolderExist.Size = new Size(106, 15);
			LblGroupFolderExist.TabIndex = 5;
			LblGroupFolderExist.Text = "folder already exist";
			LblGroupFolderExist.Visible = false;
			// 
			// BtnMoveGroup
			// 
			BtnMoveGroup.Enabled = false;
			BtnMoveGroup.Location = new Point(202, 43);
			BtnMoveGroup.Name = "BtnMoveGroup";
			BtnMoveGroup.Size = new Size(118, 23);
			BtnMoveGroup.TabIndex = 4;
			BtnMoveGroup.Text = "Move to new folder";
			BtnMoveGroup.UseVisualStyleBackColor = true;
			BtnMoveGroup.Click += BtnMoveGroup_Click;
			// 
			// label20
			// 
			label20.AutoSize = true;
			label20.Location = new Point(3, 46);
			label20.Name = "label20";
			label20.Size = new Size(40, 15);
			label20.TabIndex = 3;
			label20.Text = "Group";
			// 
			// InpGroupName
			// 
			InpGroupName.Location = new Point(49, 43);
			InpGroupName.Name = "InpGroupName";
			InpGroupName.ReadOnly = true;
			InpGroupName.Size = new Size(147, 23);
			InpGroupName.TabIndex = 2;
			// 
			// InpItemsInGroup
			// 
			InpItemsInGroup.Location = new Point(151, 5);
			InpItemsInGroup.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			InpItemsInGroup.Name = "InpItemsInGroup";
			InpItemsInGroup.Size = new Size(45, 23);
			InpItemsInGroup.TabIndex = 1;
			InpItemsInGroup.Value = new decimal(new int[] { 5, 0, 0, 0 });
			InpItemsInGroup.ValueChanged += InpItemsInGroup_ValueChanged;
			// 
			// label19
			// 
			label19.AutoSize = true;
			label19.Location = new Point(3, 7);
			label19.Name = "label19";
			label19.Size = new Size(142, 15);
			label19.TabIndex = 0;
			label19.Text = "Min items count in group";
			// 
			// label18
			// 
			label18.AutoSize = true;
			label18.Location = new Point(3, 3);
			label18.Name = "label18";
			label18.Size = new Size(133, 15);
			label18.TabIndex = 6;
			label18.Text = "Authors in any to group";
			// 
			// FormManageFiles
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(Tabs);
			Icon = (Icon)resources.GetObject("$this.Icon");
			MinimumSize = new Size(720, 320);
			Name = "FormManageFiles";
			StartPosition = FormStartPosition.CenterParent;
			Text = "Melodorium | Manage files";
			Shown += FormManageFiles_Shown;
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)PBAlreadyExist).EndInit();
			((System.ComponentModel.ISupportInitialize)PBGoodName).EndInit();
			splitContainer2.Panel1.ResumeLayout(false);
			splitContainer2.Panel2.ResumeLayout(false);
			splitContainer2.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
			splitContainer2.ResumeLayout(false);
			splitContainer3.Panel1.ResumeLayout(false);
			splitContainer3.Panel2.ResumeLayout(false);
			splitContainer3.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
			splitContainer3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)PBAlreadyExistMismatch).EndInit();
			splitContainer4.Panel1.ResumeLayout(false);
			splitContainer4.Panel1.PerformLayout();
			splitContainer4.Panel2.ResumeLayout(false);
			splitContainer4.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
			splitContainer4.ResumeLayout(false);
			Tabs.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage1.PerformLayout();
			tabPage2.ResumeLayout(false);
			tabPage2.PerformLayout();
			tabPage3.ResumeLayout(false);
			tabPage3.PerformLayout();
			tabPage4.ResumeLayout(false);
			tabPage4.PerformLayout();
			splitContainer5.Panel1.ResumeLayout(false);
			splitContainer5.Panel2.ResumeLayout(false);
			splitContainer5.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer5).EndInit();
			splitContainer5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)InpSimiarityLevel).EndInit();
			tabPage5.ResumeLayout(false);
			tabPage5.PerformLayout();
			splitContainer6.Panel1.ResumeLayout(false);
			splitContainer6.Panel2.ResumeLayout(false);
			splitContainer6.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer6).EndInit();
			splitContainer6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)InpItemsInGroup).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Label label1;
		private SplitContainer splitContainer1;
		private ListView ListProblems;
		private ColumnHeader columnHeader1;
		private Label label3;
		private Button BtnRename;
		private TextBox InpRenameNew;
		private TextBox InpRenameOld;
		private Label label2;
		private PictureBox PBGoodName;
		private Label label4;
		private PictureBox PBAlreadyExist;
		private Label label5;
		private Button BtnOpenInExplorer;
		private Label label6;
		private SplitContainer splitContainer2;
		private ListView ListFolders;
		private ColumnHeader columnHeader2;
		private RadioButton InpAuthorMode_Any;
		private RadioButton InpAuthorMode_Manual;
		private RadioButton InpAuthorMode_Auto;
		private TextBox InpAuthor;
		private Label label8;
		private TextBox InpFolder;
		private Label label7;
		private Button BtnOpenInExplorerFolder;
		private Button BtnSave;
		private Label label9;
		private SplitContainer splitContainer3;
		private ListView ListMismatch;
		private ColumnHeader columnHeader3;
		private Button BtnOpenInExplorerMismatch;
		private TextBox InpMismatchFolderExpected;
		private Label label12;
		private TextBox InpMismatchFolder;
		private Label label11;
		private TextBox InpMismatchName;
		private Label label10;
		private SplitContainer splitContainer4;
		private Button BtnMoveMismatch;
		private PictureBox PBAlreadyExistMismatch;
		private Label label13;
		private TabControl Tabs;
		private TabPage tabPage1;
		private TabPage tabPage2;
		private TabPage tabPage3;
		private TabPage tabPage4;
		private SplitContainer splitContainer5;
		private ListView ListSimilar;
		private ColumnHeader columnHeader4;
		private Label label14;
		private ListView ListSimilarFiles;
		private ColumnHeader columnHeader5;
		private Label label15;
		private CheckBox CbxIgnoreAuthor;
		private Label label16;
		private CheckBox CbxStrictComparison;
		private Label label17;
		private TrackBar InpSimiarityLevel;
		private Label LblSimiarityLevel;
		private Button BtnApplySimilarity;
		private TabPage tabPage5;
		private Label label18;
		private SplitContainer splitContainer6;
		private TreeView TreeGroup;
		private Label label19;
		private NumericUpDown InpItemsInGroup;
		private Label LblGroupFolderExist;
		private Button BtnMoveGroup;
		private Label label20;
		private TextBox InpGroupName;
		private Label label21;
	}
}
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
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 9);
			label1.Name = "label1";
			label1.Size = new Size(132, 15);
			label1.TabIndex = 0;
			label1.Text = "Problems with filename";
			// 
			// splitContainer1
			// 
			splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			splitContainer1.Location = new Point(12, 27);
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
			splitContainer1.Size = new Size(776, 133);
			splitContainer1.SplitterDistance = 373;
			splitContainer1.TabIndex = 1;
			// 
			// ListProblems
			// 
			ListProblems.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
			ListProblems.Dock = DockStyle.Fill;
			ListProblems.Location = new Point(0, 0);
			ListProblems.MultiSelect = false;
			ListProblems.Name = "ListProblems";
			ListProblems.Size = new Size(373, 133);
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
			BtnOpenInExplorer.Location = new Point(289, 101);
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
			BtnRename.Location = new Point(321, 76);
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
			InpRenameNew.Size = new Size(393, 23);
			InpRenameNew.TabIndex = 2;
			InpRenameNew.TextChanged += InpRenameNew_TextChanged;
			// 
			// InpRenameOld
			// 
			InpRenameOld.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			InpRenameOld.Location = new Point(3, 18);
			InpRenameOld.Name = "InpRenameOld";
			InpRenameOld.ReadOnly = true;
			InpRenameOld.Size = new Size(393, 23);
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
			label6.Location = new Point(12, 163);
			label6.Name = "label6";
			label6.Size = new Size(103, 15);
			label6.TabIndex = 2;
			label6.Text = "Authors in Folders";
			// 
			// splitContainer2
			// 
			splitContainer2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			splitContainer2.Location = new Point(12, 181);
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
			splitContainer2.Size = new Size(773, 143);
			splitContainer2.SplitterDistance = 257;
			splitContainer2.TabIndex = 3;
			// 
			// ListFolders
			// 
			ListFolders.Columns.AddRange(new ColumnHeader[] { columnHeader2 });
			ListFolders.Dock = DockStyle.Fill;
			ListFolders.Location = new Point(0, 0);
			ListFolders.MultiSelect = false;
			ListFolders.Name = "ListFolders";
			ListFolders.Size = new Size(257, 143);
			ListFolders.TabIndex = 0;
			ListFolders.UseCompatibleStateImageBehavior = false;
			ListFolders.View = View.Details;
			ListFolders.SelectedIndexChanged += ListFolders_SelectedIndexChanged;
			// 
			// columnHeader2
			// 
			columnHeader2.Text = "Folder";
			columnHeader2.Width = 230;
			// 
			// BtnSave
			// 
			BtnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			BtnSave.Enabled = false;
			BtnSave.Location = new Point(405, 117);
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
			BtnOpenInExplorerFolder.Location = new Point(402, 65);
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
			InpAuthor.Size = new Size(456, 23);
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
			InpFolder.Size = new Size(456, 23);
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
			// FormManageFiles
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(splitContainer2);
			Controls.Add(label6);
			Controls.Add(splitContainer1);
			Controls.Add(label1);
			Icon = (Icon)resources.GetObject("$this.Icon");
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
			ResumeLayout(false);
			PerformLayout();
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
	}
}
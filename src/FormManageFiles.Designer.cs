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
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)PBAlreadyExist).BeginInit();
			((System.ComponentModel.ISupportInitialize)PBGoodName).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 9);
			label1.Name = "label1";
			label1.Size = new Size(57, 15);
			label1.TabIndex = 0;
			label1.Text = "Problems";
			// 
			// splitContainer1
			// 
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
			// FormManageFiles
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
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
	}
}
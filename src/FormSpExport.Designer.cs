namespace Melodorium
{
	partial class FormSpExport
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSpExport));
			BtnSelectFolder = new Button();
			InpFolder = new TextBox();
			label8 = new Label();
			label1 = new Label();
			label2 = new Label();
			CheckListFolders = new CheckedListBox();
			FolderBrowser = new FolderBrowserDialog();
			BtnExport = new Button();
			CheckListTags = new CheckedListBox();
			label3 = new Label();
			SuspendLayout();
			// 
			// BtnSelectFolder
			// 
			BtnSelectFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			BtnSelectFolder.Location = new Point(260, 27);
			BtnSelectFolder.Name = "BtnSelectFolder";
			BtnSelectFolder.Size = new Size(23, 23);
			BtnSelectFolder.TabIndex = 13;
			BtnSelectFolder.Text = "S";
			BtnSelectFolder.UseVisualStyleBackColor = true;
			BtnSelectFolder.Click += BtnSelectFolder_Click;
			// 
			// InpFolder
			// 
			InpFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			InpFolder.Location = new Point(12, 27);
			InpFolder.Name = "InpFolder";
			InpFolder.Size = new Size(242, 23);
			InpFolder.TabIndex = 12;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new Point(12, 9);
			label8.Name = "label8";
			label8.Size = new Size(73, 15);
			label8.TabIndex = 14;
			label8.Text = "Copy files to";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 53);
			label1.Name = "label1";
			label1.Size = new Size(175, 15);
			label1.TabIndex = 15;
			label1.Text = "Music will be grouped by mood";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(12, 80);
			label2.Name = "label2";
			label2.Size = new Size(138, 15);
			label2.TabIndex = 16;
			label2.Text = "Leave it in its own folder:";
			// 
			// CheckListFolders
			// 
			CheckListFolders.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			CheckListFolders.CheckOnClick = true;
			CheckListFolders.FormattingEnabled = true;
			CheckListFolders.Location = new Point(12, 98);
			CheckListFolders.Name = "CheckListFolders";
			CheckListFolders.Size = new Size(271, 184);
			CheckListFolders.TabIndex = 17;
			// 
			// BtnExport
			// 
			BtnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BtnExport.Location = new Point(208, 421);
			BtnExport.Name = "BtnExport";
			BtnExport.Size = new Size(75, 23);
			BtnExport.TabIndex = 18;
			BtnExport.Text = "Export";
			BtnExport.UseVisualStyleBackColor = true;
			BtnExport.Click += BtnExport_Click;
			// 
			// CheckListTags
			// 
			CheckListTags.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			CheckListTags.CheckOnClick = true;
			CheckListTags.FormattingEnabled = true;
			CheckListTags.Location = new Point(12, 303);
			CheckListTags.Name = "CheckListTags";
			CheckListTags.Size = new Size(271, 112);
			CheckListTags.TabIndex = 20;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(12, 285);
			label3.Name = "label3";
			label3.Size = new Size(175, 15);
			label3.TabIndex = 19;
			label3.Text = "Move the tag to separate folder:";
			// 
			// FormSpExport
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(295, 453);
			Controls.Add(CheckListTags);
			Controls.Add(label3);
			Controls.Add(BtnExport);
			Controls.Add(CheckListFolders);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(label8);
			Controls.Add(BtnSelectFolder);
			Controls.Add(InpFolder);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FormSpExport";
			StartPosition = FormStartPosition.CenterParent;
			Text = "Melodorium | Export";
			Shown += FormSpExport_Shown;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button BtnSelectFolder;
		private TextBox InpFolder;
		private Label label8;
		private Label label1;
		private Label label2;
		private CheckedListBox CheckListFolders;
		private FolderBrowserDialog FolderBrowser;
		private Button BtnExport;
		private CheckedListBox CheckListTags;
		private Label label3;
	}
}
namespace Melodorium
{
	partial class FormOpenData
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOpenData));
			LblFolder = new Label();
			RootFolderDialog = new FolderBrowserDialog();
			InpIgnore = new TextBox();
			label1 = new Label();
			splitContainer1 = new SplitContainer();
			ListMusic = new ListView();
			columnHeader1 = new ColumnHeader();
			BtnFilter = new Button();
			ListMusicIgnore = new ListView();
			columnHeader2 = new ColumnHeader();
			BtnSave = new Button();
			InpExts = new TextBox();
			label2 = new Label();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			SuspendLayout();
			// 
			// LblFolder
			// 
			LblFolder.AutoSize = true;
			LblFolder.Location = new Point(12, 9);
			LblFolder.Name = "LblFolder";
			LblFolder.Size = new Size(97, 15);
			LblFolder.TabIndex = 0;
			LblFolder.Text = "Select root folder";
			LblFolder.Click += LblFolder_Click;
			// 
			// InpIgnore
			// 
			InpIgnore.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			InpIgnore.Location = new Point(3, 32);
			InpIgnore.Multiline = true;
			InpIgnore.Name = "InpIgnore";
			InpIgnore.Size = new Size(273, 120);
			InpIgnore.TabIndex = 4;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(3, 7);
			label1.Name = "label1";
			label1.Size = new Size(84, 15);
			label1.TabIndex = 5;
			label1.Text = "Ignore (regex):";
			// 
			// splitContainer1
			// 
			splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			splitContainer1.Location = new Point(12, 56);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(ListMusic);
			splitContainer1.Panel1.Padding = new Padding(0, 0, 3, 0);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(BtnFilter);
			splitContainer1.Panel2.Controls.Add(ListMusicIgnore);
			splitContainer1.Panel2.Controls.Add(label1);
			splitContainer1.Panel2.Controls.Add(InpIgnore);
			splitContainer1.Size = new Size(776, 380);
			splitContainer1.SplitterDistance = 493;
			splitContainer1.TabIndex = 7;
			// 
			// ListMusic
			// 
			ListMusic.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
			ListMusic.Dock = DockStyle.Fill;
			ListMusic.Location = new Point(0, 0);
			ListMusic.Name = "ListMusic";
			ListMusic.Size = new Size(490, 380);
			ListMusic.TabIndex = 0;
			ListMusic.UseCompatibleStateImageBehavior = false;
			ListMusic.View = View.Details;
			ListMusic.MouseDoubleClick += ListMusic_MouseDoubleClick;
			// 
			// columnHeader1
			// 
			columnHeader1.Text = "Path";
			columnHeader1.Width = 450;
			// 
			// BtnFilter
			// 
			BtnFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			BtnFilter.Location = new Point(201, 3);
			BtnFilter.Name = "BtnFilter";
			BtnFilter.Size = new Size(75, 23);
			BtnFilter.TabIndex = 7;
			BtnFilter.Text = "Apply";
			BtnFilter.UseVisualStyleBackColor = true;
			BtnFilter.Click += BtnFilter_Click;
			// 
			// ListMusicIgnore
			// 
			ListMusicIgnore.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			ListMusicIgnore.Columns.AddRange(new ColumnHeader[] { columnHeader2 });
			ListMusicIgnore.Location = new Point(3, 158);
			ListMusicIgnore.Name = "ListMusicIgnore";
			ListMusicIgnore.Size = new Size(273, 219);
			ListMusicIgnore.TabIndex = 6;
			ListMusicIgnore.UseCompatibleStateImageBehavior = false;
			ListMusicIgnore.View = View.Details;
			// 
			// columnHeader2
			// 
			columnHeader2.Text = "Path";
			columnHeader2.Width = 250;
			// 
			// BtnSave
			// 
			BtnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			BtnSave.Location = new Point(683, 9);
			BtnSave.Name = "BtnSave";
			BtnSave.Size = new Size(102, 41);
			BtnSave.TabIndex = 8;
			BtnSave.Text = "Save changes";
			BtnSave.UseVisualStyleBackColor = true;
			BtnSave.Click += BtnSave_Click;
			// 
			// InpExts
			// 
			InpExts.Location = new Point(12, 27);
			InpExts.Name = "InpExts";
			InpExts.ReadOnly = true;
			InpExts.Size = new Size(285, 23);
			InpExts.TabIndex = 9;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(354, 31);
			label2.Name = "label2";
			label2.Size = new Size(115, 15);
			label2.TabIndex = 10;
			label2.Text = "Dbl click to ignore  v";
			// 
			// FormOpenData
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 452);
			Controls.Add(label2);
			Controls.Add(InpExts);
			Controls.Add(BtnSave);
			Controls.Add(splitContainer1);
			Controls.Add(LblFolder);
			Icon = (Icon)resources.GetObject("$this.Icon");
			MinimumSize = new Size(620, 400);
			Name = "FormOpenData";
			StartPosition = FormStartPosition.CenterParent;
			Text = "Melodorium | files";
			Shown += FormOpenData_Shown;
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label LblFolder;
		private FolderBrowserDialog RootFolderDialog;
		private TextBox InpIgnore;
		private Label label1;
		private SplitContainer splitContainer1;
		private ListView ListMusic;
		private ColumnHeader columnHeader1;
		private ListView ListMusicIgnore;
		private ColumnHeader columnHeader2;
		private Button BtnSave;
		private Button BtnFilter;
		private TextBox InpExts;
		private Label label2;
	}
}

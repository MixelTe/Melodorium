namespace Melodorium
{
	partial class FormSync
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSync));
			label1 = new Label();
			InpSource = new TextBox();
			BtnSelectSource = new Button();
			label2 = new Label();
			BtnSelectDest = new Button();
			InpDest = new TextBox();
			BtnSync = new Button();
			label3 = new Label();
			FolderBrowser = new FolderBrowserDialog();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 9);
			label1.Name = "label1";
			label1.Size = new Size(102, 15);
			label1.TabIndex = 0;
			label1.Text = "Source root folder";
			// 
			// InpSource
			// 
			InpSource.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			InpSource.Location = new Point(12, 27);
			InpSource.Name = "InpSource";
			InpSource.Size = new Size(251, 23);
			InpSource.TabIndex = 1;
			// 
			// BtnSelectSource
			// 
			BtnSelectSource.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			BtnSelectSource.Location = new Point(269, 27);
			BtnSelectSource.Name = "BtnSelectSource";
			BtnSelectSource.Size = new Size(23, 23);
			BtnSelectSource.TabIndex = 2;
			BtnSelectSource.Text = "S";
			BtnSelectSource.UseVisualStyleBackColor = true;
			BtnSelectSource.Click += BtnSelectSource_Click;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(12, 53);
			label2.Name = "label2";
			label2.Size = new Size(141, 15);
			label2.TabIndex = 3;
			label2.Text = "Old copy of source folder";
			// 
			// BtnSelectDest
			// 
			BtnSelectDest.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			BtnSelectDest.Location = new Point(269, 71);
			BtnSelectDest.Name = "BtnSelectDest";
			BtnSelectDest.Size = new Size(23, 23);
			BtnSelectDest.TabIndex = 5;
			BtnSelectDest.Text = "S";
			BtnSelectDest.UseVisualStyleBackColor = true;
			BtnSelectDest.Click += BtnSelectDest_Click;
			// 
			// InpDest
			// 
			InpDest.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			InpDest.Location = new Point(12, 71);
			InpDest.Name = "InpDest";
			InpDest.Size = new Size(251, 23);
			InpDest.TabIndex = 4;
			// 
			// BtnSync
			// 
			BtnSync.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BtnSync.Location = new Point(250, 121);
			BtnSync.Name = "BtnSync";
			BtnSync.Size = new Size(42, 23);
			BtnSync.TabIndex = 6;
			BtnSync.Text = "Sync";
			BtnSync.UseVisualStyleBackColor = true;
			BtnSync.Click += BtnSync_Click;
			// 
			// label3
			// 
			label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			label3.AutoSize = true;
			label3.Location = new Point(12, 125);
			label3.Name = "label3";
			label3.Size = new Size(194, 15);
			label3.TabIndex = 7;
			label3.Text = "Sync dont detect file/folder rename";
			// 
			// FormSync
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(304, 156);
			Controls.Add(label3);
			Controls.Add(BtnSync);
			Controls.Add(BtnSelectDest);
			Controls.Add(InpDest);
			Controls.Add(label2);
			Controls.Add(BtnSelectSource);
			Controls.Add(InpSource);
			Controls.Add(label1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FormSync";
			StartPosition = FormStartPosition.CenterParent;
			Text = "Melodorium | Sync";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private TextBox InpSource;
		private Button BtnSelectSource;
		private Label label2;
		private Button BtnSelectDest;
		private TextBox InpDest;
		private Button BtnSync;
		private Label label3;
		private FolderBrowserDialog FolderBrowser;
	}
}
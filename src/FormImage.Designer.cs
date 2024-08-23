namespace Melodorium
{
	partial class FormImage
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImage));
			PBImage = new PictureBox();
			BtnChangeImg = new Button();
			FileDialog = new OpenFileDialog();
			BtnExport = new Button();
			((System.ComponentModel.ISupportInitialize)PBImage).BeginInit();
			SuspendLayout();
			// 
			// PBImage
			// 
			PBImage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			PBImage.Location = new Point(0, 0);
			PBImage.Name = "PBImage";
			PBImage.Size = new Size(374, 374);
			PBImage.SizeMode = PictureBoxSizeMode.CenterImage;
			PBImage.TabIndex = 0;
			PBImage.TabStop = false;
			// 
			// BtnChangeImg
			// 
			BtnChangeImg.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			BtnChangeImg.Location = new Point(150, 380);
			BtnChangeImg.Name = "BtnChangeImg";
			BtnChangeImg.Size = new Size(75, 23);
			BtnChangeImg.TabIndex = 1;
			BtnChangeImg.Text = "Change";
			BtnChangeImg.UseVisualStyleBackColor = true;
			BtnChangeImg.Click += BtnChangeImg_Click;
			// 
			// FileDialog
			// 
			FileDialog.FileName = "openFileDialog1";
			FileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;|All files (*.*)|*.*";
			FileDialog.Title = "New music picture";
			// 
			// BtnExport
			// 
			BtnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			BtnExport.Location = new Point(12, 380);
			BtnExport.Name = "BtnExport";
			BtnExport.Size = new Size(51, 23);
			BtnExport.TabIndex = 2;
			BtnExport.Text = "Export";
			BtnExport.UseVisualStyleBackColor = true;
			BtnExport.Click += BtnExport_Click;
			// 
			// FormImage
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(374, 408);
			Controls.Add(BtnExport);
			Controls.Add(BtnChangeImg);
			Controls.Add(PBImage);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FormImage";
			StartPosition = FormStartPosition.CenterParent;
			Text = "Melodorium | Music picture";
			((System.ComponentModel.ISupportInitialize)PBImage).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private PictureBox PBImage;
		private Button BtnChangeImg;
		private OpenFileDialog FileDialog;
		private Button BtnExport;
	}
}
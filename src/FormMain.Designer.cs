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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			BtnChangeFolder = new Button();
			SuspendLayout();
			// 
			// BtnChangeFolder
			// 
			BtnChangeFolder.Location = new Point(12, 12);
			BtnChangeFolder.Name = "BtnChangeFolder";
			BtnChangeFolder.Size = new Size(140, 23);
			BtnChangeFolder.TabIndex = 0;
			BtnChangeFolder.Text = "Change/Update folder";
			BtnChangeFolder.UseVisualStyleBackColor = true;
			BtnChangeFolder.Click += BtnChangeFolder_Click;
			// 
			// FormMain
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(BtnChangeFolder);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FormMain";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Melodorium";
			Shown += FormMain_Shown;
			ResumeLayout(false);
		}

		#endregion

		private Button BtnChangeFolder;
	}
}
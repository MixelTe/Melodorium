namespace Melodorium
{
	partial class FormLoading
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoading));
			label1 = new Label();
			ProgBar = new ProgressBar();
			BtnCancel = new Button();
			SuspendLayout();
			// 
			// label1
			// 
			label1.Dock = DockStyle.Fill;
			label1.Font = new Font("Segoe UI", 16F);
			label1.ForeColor = Color.White;
			label1.Location = new Point(0, 0);
			label1.Name = "label1";
			label1.Size = new Size(300, 150);
			label1.TabIndex = 0;
			label1.Text = "Loading...";
			label1.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// ProgBar
			// 
			ProgBar.Location = new Point(12, 115);
			ProgBar.Name = "ProgBar";
			ProgBar.Size = new Size(276, 23);
			ProgBar.TabIndex = 1;
			ProgBar.Value = 41;
			// 
			// BtnCancel
			// 
			BtnCancel.Location = new Point(233, 12);
			BtnCancel.Name = "BtnCancel";
			BtnCancel.Size = new Size(55, 23);
			BtnCancel.TabIndex = 2;
			BtnCancel.Text = "Cancel";
			BtnCancel.UseVisualStyleBackColor = true;
			BtnCancel.Click += BtnCancel_Click;
			// 
			// FormLoading
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.Black;
			ClientSize = new Size(300, 150);
			Controls.Add(BtnCancel);
			Controls.Add(ProgBar);
			Controls.Add(label1);
			FormBorderStyle = FormBorderStyle.None;
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FormLoading";
			Opacity = 0.6D;
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterParent;
			Text = "Melodorium | loading";
			Shown += FormLoading_Shown;
			ResumeLayout(false);
		}

		#endregion

		private Label label1;
		private ProgressBar ProgBar;
		private Button BtnCancel;
	}
}
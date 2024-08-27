namespace Melodorium
{
	partial class FormLog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLog));
			InpLog = new RichTextBox();
			SuspendLayout();
			// 
			// InpLog
			// 
			InpLog.Dock = DockStyle.Fill;
			InpLog.Location = new Point(0, 0);
			InpLog.Name = "InpLog";
			InpLog.ReadOnly = true;
			InpLog.Size = new Size(611, 253);
			InpLog.TabIndex = 0;
			InpLog.Text = "";
			// 
			// FormLog
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(611, 253);
			Controls.Add(InpLog);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FormLog";
			StartPosition = FormStartPosition.CenterParent;
			Text = "Melodorium | Log";
			ResumeLayout(false);
		}

		#endregion

		private RichTextBox InpLog;
	}
}
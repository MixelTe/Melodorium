namespace Melodorium
{
	partial class FormHotkeys
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHotkeys));
			label1 = new Label();
			InpEnable = new CheckBox();
			InpShow = new TextBox();
			label2 = new Label();
			InpPlay = new TextBox();
			label3 = new Label();
			InpStop = new TextBox();
			label4 = new Label();
			InpNext = new TextBox();
			label5 = new Label();
			InpPrev = new TextBox();
			label6 = new Label();
			label7 = new Label();
			BtnReset = new Button();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 40);
			label1.Name = "label1";
			label1.Size = new Size(101, 15);
			label1.TabIndex = 0;
			label1.Text = "Show/Hide player";
			// 
			// InpEnable
			// 
			InpEnable.AutoSize = true;
			InpEnable.Location = new Point(12, 12);
			InpEnable.Name = "InpEnable";
			InpEnable.Size = new Size(105, 19);
			InpEnable.TabIndex = 1;
			InpEnable.Text = "Enable hotkeys";
			InpEnable.UseVisualStyleBackColor = true;
			InpEnable.CheckedChanged += InpEnable_CheckedChanged;
			// 
			// InpShow
			// 
			InpShow.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			InpShow.Location = new Point(121, 37);
			InpShow.Name = "InpShow";
			InpShow.Size = new Size(144, 23);
			InpShow.TabIndex = 2;
			InpShow.KeyDown += InpShow_KeyDown;
			InpShow.KeyPress += InpShow_KeyPress;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(153, 13);
			label2.Name = "label2";
			label2.Size = new Size(64, 15);
			label2.TabIndex = 3;
			label2.Text = "Esc - unset";
			// 
			// InpPlay
			// 
			InpPlay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			InpPlay.Location = new Point(121, 66);
			InpPlay.Name = "InpPlay";
			InpPlay.Size = new Size(144, 23);
			InpPlay.TabIndex = 5;
			InpPlay.KeyDown += InpPlay_KeyDown;
			InpPlay.KeyPress += InpPlay_KeyPress;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(12, 69);
			label3.Name = "label3";
			label3.Size = new Size(65, 15);
			label3.TabIndex = 4;
			label3.Text = "Play/Pause";
			// 
			// InpStop
			// 
			InpStop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			InpStop.Location = new Point(121, 95);
			InpStop.Name = "InpStop";
			InpStop.Size = new Size(144, 23);
			InpStop.TabIndex = 7;
			InpStop.KeyDown += InpStop_KeyDown;
			InpStop.KeyPress += InpStop_KeyPress;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(12, 98);
			label4.Name = "label4";
			label4.Size = new Size(31, 15);
			label4.TabIndex = 6;
			label4.Text = "Stop";
			// 
			// InpNext
			// 
			InpNext.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			InpNext.Location = new Point(121, 124);
			InpNext.Name = "InpNext";
			InpNext.Size = new Size(144, 23);
			InpNext.TabIndex = 9;
			InpNext.KeyDown += InpNext_KeyDown;
			InpNext.KeyPress += InpNext_KeyPress;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(12, 127);
			label5.Name = "label5";
			label5.Size = new Size(61, 15);
			label5.TabIndex = 8;
			label5.Text = "Next track";
			// 
			// InpPrev
			// 
			InpPrev.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			InpPrev.Location = new Point(121, 153);
			InpPrev.Name = "InpPrev";
			InpPrev.Size = new Size(144, 23);
			InpPrev.TabIndex = 11;
			InpPrev.KeyDown += InpPrev_KeyDown;
			InpPrev.KeyPress += InpPrev_KeyPress;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(12, 156);
			label6.Name = "label6";
			label6.Size = new Size(81, 15);
			label6.TabIndex = 10;
			label6.Text = "Previous track";
			// 
			// label7
			// 
			label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			label7.AutoSize = true;
			label7.Location = new Point(12, 184);
			label7.Name = "label7";
			label7.Size = new Size(255, 15);
			label7.TabIndex = 12;
			label7.Text = "Hotkeys are disabled while this window is open";
			// 
			// BtnReset
			// 
			BtnReset.Location = new Point(223, 9);
			BtnReset.Name = "BtnReset";
			BtnReset.Size = new Size(42, 23);
			BtnReset.TabIndex = 13;
			BtnReset.Text = "reset";
			BtnReset.UseVisualStyleBackColor = true;
			BtnReset.Click += BtnReset_Click;
			// 
			// FormHotkeys
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(277, 208);
			Controls.Add(BtnReset);
			Controls.Add(label7);
			Controls.Add(InpPrev);
			Controls.Add(label6);
			Controls.Add(InpNext);
			Controls.Add(label5);
			Controls.Add(InpStop);
			Controls.Add(label4);
			Controls.Add(InpPlay);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(InpShow);
			Controls.Add(InpEnable);
			Controls.Add(label1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			MaximumSize = new Size(293, 247);
			MinimizeBox = false;
			MinimumSize = new Size(293, 247);
			Name = "FormHotkeys";
			StartPosition = FormStartPosition.CenterParent;
			Text = "Melodorium | Hotkeys";
			FormClosed += FormHotkeys_FormClosed;
			Shown += FormHotkeys_Shown;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private CheckBox InpEnable;
		private TextBox InpShow;
		private Label label2;
		private TextBox InpPlay;
		private Label label3;
		private TextBox InpStop;
		private Label label4;
		private TextBox InpNext;
		private Label label5;
		private TextBox InpPrev;
		private Label label6;
		private Label label7;
		private Button BtnReset;
	}
}
namespace Melodorium
{
	public partial class FormLoading : Form
	{
		public Action? Job;
		public bool Canceled = false;
		public bool Delayed = false;
		public DateTime OpenedAt;

		public FormLoading()
		{
			InitializeComponent();
			ProgBar.Visible = false;
            BtnCancel.Visible = false;
			LblInfo.Visible = false;
		}
		public FormLoading(bool delayed) : this()
		{
			Delayed = delayed;
			OpenedAt = DateTime.Now;
		}

		private void FormLoading_Shown(object sender, EventArgs e)
		{
			if (Job == null) return;
			if (Delayed) Opacity = 0;
			Application.DoEvents();
			Job();
		}

		public void SetProgress(float progress)
		{
			ProgBar.Visible = true;
			ProgBar.Value = Math.Min(Math.Max((int)(progress * 100), 0), 100);
			CheckDelay();
			Application.DoEvents();
		}
        public void SetInfo(string info)
        {
            LblInfo.Visible = true;
            LblInfo.Text = info;
			CheckDelay();
			Application.DoEvents();
		}
		public void CheckDelay()
		{
			if (Delayed)
			{
				var d = DateTime.Now - OpenedAt;
				if (d.TotalMilliseconds > 300)
				{
					Opacity = 0.6;
					Delayed = false;
					Application.DoEvents();
				}
			}
		}

		public void EnableCancel()
		{
			BtnCancel.Visible = true;
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			Canceled = true;
		}
	}
}

namespace Melodorium
{
	public partial class FormLoading : Form
	{
		public Action? Job;
		public bool Canceled = false;

		public FormLoading()
		{
			InitializeComponent();
			ProgBar.Visible = false;
            BtnCancel.Visible = false;
			LblInfo.Visible = false;
		}

		private void FormLoading_Shown(object sender, EventArgs e)
		{
			if (Job == null) return;
			Application.DoEvents();
			Job();
		}

		public void SetProgress(float progress)
		{
			ProgBar.Visible = true;
			ProgBar.Value = Math.Min(Math.Max((int)(progress * 100), 0), 100);
            Application.DoEvents();
        }
        public void SetInfo(string info)
        {
            LblInfo.Visible = true;
            LblInfo.Text = info;
            Application.DoEvents();
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

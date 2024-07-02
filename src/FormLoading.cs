namespace Melodorium
{
	public partial class FormLoading : Form
	{
		public Action? Job;

		public FormLoading()
		{
			InitializeComponent();
			ProgBar.Visible = false;
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
			ProgBar.Value = (int)(progress * 100);
		}
	}
}

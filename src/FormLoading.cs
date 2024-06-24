namespace Melodorium
{
	public partial class FormLoading : Form
	{
		public Action? Job;

		public FormLoading()
		{
			InitializeComponent();
		}

		private void FormLoading_Shown(object sender, EventArgs e)
		{
			if (Job == null) return;
			Application.DoEvents();
			Job();
		}
	}
}

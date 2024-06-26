using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Melodorium
{
	public partial class FormMain : Form
	{
		public FormMain()
		{
			InitializeComponent();
		}

		private void FormMain_Shown(object sender, EventArgs e)
		{
			if (Program.Settings.RootFolder == "")
				OpenFolder();
		}

		private void BtnChangeFolder_Click(object sender, EventArgs e)
		{
			OpenFolder();
		}

		private void OpenFolder()
		{
			using var dialog = new FormOpenData();
			Hide();
			dialog.ShowDialog(this);
			Show();
			MusicData.LoadFull();
		}

		private void BtnExport_Click(object sender, EventArgs e)
		{
			Program.MusicData.ExportData();
		}

		private void BtnManage_Click(object sender, EventArgs e)
		{
			using var dialog = new FormManageFiles();
			Hide();
			dialog.ShowDialog(this);
			Show();
			MusicData.LoadFull();
		}
	}
}

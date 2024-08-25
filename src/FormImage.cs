using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Melodorium
{
	public partial class FormImage : Form
	{
		public string? NewImage;
		public Image Image { get => PBImage.Image; }
		private MusicFile _musicFile;

		public FormImage(MusicFile musicFile, Image image)
		{
			InitializeComponent();
			_musicFile = musicFile;
			PBImage.Image = image;
			if (musicFile.Picture == null)
				BtnExport.Enabled = false;
		}

		private void BtnChangeImg_Click(object sender, EventArgs e)
		{
			if (FileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					PBImage.Image = Image.FromFile(FileDialog.FileName);
					NewImage = FileDialog.FileName;
					BtnExport.Enabled = false;
				}
				catch (Exception)
				{
					MessageBox.Show("Cant open image", "Open Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void BtnExport_Click(object sender, EventArgs e)
		{
			var path = Utils.GetFreeFileName(_musicFile.Name, ".png");
			PBImage.Image.Save(path, System.Drawing.Imaging.ImageFormat.Png);
			Utils.OpenExplorer(path);
		}
	}
}

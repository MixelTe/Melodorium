using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Melodorium
{
	public partial class FormSync : Form
	{
		public FormSync()
		{
			InitializeComponent();
		}

		private void BtnSelectSource_Click(object sender, EventArgs e)
		{
			FolderBrowser.InitialDirectory = InpSource.Text;
			FolderBrowser.SelectedPath = FolderBrowser.InitialDirectory;
			if (FolderBrowser.ShowDialog() != DialogResult.OK)
				return;

			InpSource.Text = FolderBrowser.SelectedPath;
		}

		private void BtnSelectDest_Click(object sender, EventArgs e)
		{
			FolderBrowser.InitialDirectory = InpDest.Text;
			FolderBrowser.SelectedPath = FolderBrowser.InitialDirectory;
			if (FolderBrowser.ShowDialog() != DialogResult.OK)
				return;

			InpDest.Text = FolderBrowser.SelectedPath;
		}

		private void BtnSync_Click(object sender, EventArgs e)
		{
			var log = "";
			using var loadingDialog = new FormLoading();
			loadingDialog.EnableCancel();
			loadingDialog.Job = () =>
			{
				log = Sync(loadingDialog);
				loadingDialog.Close();
			};
			loadingDialog.ShowDialog(this);
			if (log != "")
			{
				using var dialog = new FormLog(log);
				dialog.ShowDialog(this);
			}
		}

		private string Sync(FormLoading loadingDialog)
		{
			var source = InpSource.Text;
			var dest = InpDest.Text;
			var deletedFolderName = "__deleted__";
			var trash = Path.Combine(dest, deletedFolderName);
			var trashUpdated = Path.Combine(trash, "updated");
			if (!Directory.Exists(source))
			{
				MessageBox.Show("Source directory does not exist", "Sync");
				return "";
			}
			if (!Directory.Exists(dest))
			{
				MessageBox.Show("Sync directory does not exist", "Sync");
				return "";
			}
			if (!Utils.IsDirectoryWritable(dest))
			{
				MessageBox.Show("Access to Sync directory is denied", "Sync");
				return "";
			}
			if (!Directory.Exists(trash))
				Directory.CreateDirectory(trash);
			if (!Directory.Exists(trashUpdated))
				Directory.CreateDirectory(trashUpdated);

			var diSource = new DirectoryInfo(source);
			var diDest = new DirectoryInfo(dest);
			var useHardLink = diDest.Root.FullName == diSource.Root.FullName;

			var files = Utils.GetFileNames(source, relative: true, order: true);
			var oldFiles = Utils.GetFileNames(dest, relative: true, order: true);
			var log = "Log:";
			for (int i = 0; i < oldFiles.Count; i++)
            {
				loadingDialog.SetProgress((float)i / oldFiles.Count);
				Application.DoEvents();
				if (loadingDialog.Canceled)
					return log;

				var file = oldFiles[i];
				if (file.StartsWith(deletedFolderName + Path.DirectorySeparatorChar))
					continue;
				if (files.BinarySearch(file) >= 0)
					continue;
				var fname = Path.GetFileNameWithoutExtension(file);
				var newPath = Utils.GetFreeFileName(Path.Combine(trash, fname), Path.GetExtension(file), false);
				var fpath = Path.Combine(dest, file);
				File.Move(fpath, newPath);
				log += $"\ndelete: {file}";
			}

			for (int i = 0; i < files.Count; i++)
			{
				loadingDialog.SetProgress((float)i / files.Count);
				Application.DoEvents();
				if (loadingDialog.Canceled)
					return log;

				var file = files[i];
				if (oldFiles.BinarySearch(file) >= 0)
				{
					var sourcePath = Path.Combine(source, file);
					var fpath = Path.Combine(dest, file);

					var contentsAreEqual = Utils.FilesContentsAreEqual(sourcePath, fpath);
					var musicDataAreEqual = MusicFile.DataAreEqual(sourcePath, fpath);
					if (contentsAreEqual && musicDataAreEqual)
						continue;

					var fname = Path.GetFileNameWithoutExtension(file);
					var newPath = Utils.GetFreeFileName(Path.Combine(trashUpdated, fname), Path.GetExtension(file), false);
					File.Move(fpath, newPath);
					var success = useHardLink && HardLink.Create(fpath, sourcePath);
					if (!success)
						File.Copy(sourcePath, fpath);

					log += $"\nupdated: {file}";
				}
				else
				{
					var sourcePath = Path.Combine(source, file);
					var fpath = Path.Combine(dest, file);
					var dir = Path.GetDirectoryName(fpath) ?? "";
					if (!Directory.Exists(dir))
						Directory.CreateDirectory(dir);
					var success = useHardLink && HardLink.Create(fpath, sourcePath);
					if (!success)
						File.Copy(sourcePath, fpath);
					log += $"\nadded: {file}";
				}
			}
			return log;
		}
	}
}

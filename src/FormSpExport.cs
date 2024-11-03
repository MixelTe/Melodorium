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
	public partial class FormSpExport : Form
	{
		private List<string> _folders = [];

		public FormSpExport()
		{
			InitializeComponent();
			var di = new DirectoryInfo(Program.Settings.RootFolder);
			InpFolder.Text = di.Root.FullName;
		}

		private void FormSpExport_Shown(object sender, EventArgs e)
		{
			using var loadingDialog = new FormLoading();
			loadingDialog.Job = () =>
			{
				_folders = Program.MusicData.Files.Select(v => v.RFolder).Distinct().ToList();
				CheckListFolders.Items.Clear();
				for (var i = 0; i < _folders.Count; i++)
				{
					var folder = _folders[i];
					CheckListFolders.Items.Add(folder);
				}

				Program.MusicData.UpdateTagsList();
				CheckListTags.Items.Clear();
				for (var i = 0; i < Program.MusicData.Tags.Count; i++)
				{
					var tag = Program.MusicData.Tags[i];
					CheckListTags.Items.Add(tag);
				}

				loadingDialog.Close();
			};
			loadingDialog.ShowDialog(this);
		}

		private void BtnSelectFolder_Click(object sender, EventArgs e)
		{
			FolderBrowser.InitialDirectory = InpFolder.Text;
			FolderBrowser.SelectedPath = InpFolder.Text;
			if (FolderBrowser.ShowDialog() != DialogResult.OK)
				return;
			InpFolder.Text = FolderBrowser.SelectedPath;
		}

		private void BtnExport_Click(object sender, EventArgs e)
		{
			var folderRoot = Utils.GetFreeDirectoryName(Path.Join(InpFolder.Text, "Melodorium"), relative: false);
			var folderOther = Path.Join(folderRoot, "!Other");
			var folderRock = Path.Join(folderRoot, "!Rock");
			var folderRockBest = Path.Join(folderRock, "Best");
			var folderEnergistic = Path.Join(folderRoot, "!Energistic");
			var folderEnergisticBest = Path.Join(folderEnergistic, "Best");
			var folderCalm = Path.Join(folderRoot, "!Calm");
			var folderCalmBest = Path.Join(folderCalm, "Best");
			var folderSleep = Path.Join(folderRoot, "!Sleep");
			var folderSleepBest = Path.Join(folderSleep, "Best");
			try
			{
				Directory.CreateDirectory(folderRoot);
				Directory.CreateDirectory(folderOther);
				Directory.CreateDirectory(folderRock);
				Directory.CreateDirectory(folderEnergistic);
				Directory.CreateDirectory(folderCalm);
				Directory.CreateDirectory(folderSleep);
				Directory.CreateDirectory(folderRockBest);
				Directory.CreateDirectory(folderEnergisticBest);
				Directory.CreateDirectory(folderCalmBest);
				Directory.CreateDirectory(folderSleepBest);
			}
			catch (UnauthorizedAccessException)
			{
				MessageBox.Show("Access denied to selected export folder", "Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			catch
			{
				MessageBox.Show("Cant create folder", "Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			var diRoot = new DirectoryInfo(Program.Settings.RootFolder);
			var diDest = new DirectoryInfo(folderRoot);
			var useHardLink = diDest.Root.FullName == diRoot.Root.FullName;

			using var loadingDialog = new FormLoading();
			loadingDialog.EnableCancel();
			loadingDialog.Job = () =>
			{
				for (int i = 0; i < Program.MusicData.Files.Count; i++)
				{
					loadingDialog.SetProgress((float)i / Program.MusicData.Files.Count);
					if (loadingDialog.Canceled)
						break;

					var file = Program.MusicData.Files[i];
					var folderI = _folders.IndexOf(file.RFolder);
					var tagI = Program.MusicData.Tags.IndexOf(file.Data.Tag);
					var folder = folderOther;
					if (folderI >= 0 && CheckListFolders.GetItemChecked(folderI))
					{
						folder = Path.Combine(folderRoot, file.RFolder);
						if (file.Data.Like == MusicLike.Best)
							folder = Path.Combine(folder, "Best");
						if (!Directory.Exists(folder))
							Directory.CreateDirectory(folder);
					}
					if (tagI >= 0 && CheckListTags.GetItemChecked(tagI))
					{
						var tag = Utils.RemoveInvalidFileNameChars(Program.MusicData.Tags[tagI]);
						folder = Path.Combine(folderRoot, tag);
						if (file.Data.Like == MusicLike.Best)
							folder = Path.Combine(folder, "Best");
						if (!Directory.Exists(folder))
							Directory.CreateDirectory(folder);
					}
					else if (file.Data.IsLoaded)
						if (file.Data.Mood == MusicMood.Rock)
							folder = file.Data.Like == MusicLike.Best ? folderRockBest : folderRock;
						else if (file.Data.Mood == MusicMood.Energistic)
							folder = file.Data.Like == MusicLike.Best ? folderEnergisticBest : folderEnergistic;
						else if (file.Data.Mood == MusicMood.Calm)
							folder = file.Data.Like == MusicLike.Best ? folderCalmBest : folderCalm;
						else if (file.Data.Mood == MusicMood.Sleep)
							folder = file.Data.Like == MusicLike.Best ? folderSleepBest : folderSleep;

					var path = Path.Combine(folder, file.FName);
					if (Path.Exists(path))
						path = Path.Combine(folder, file.Name + $" ({file.RFolder.Replace(Path.DirectorySeparatorChar, '-')})" + file.Ext);
					var success = useHardLink && HardLink.Create(path, file.FPath);
					if (!success)
						File.Copy(file.FPath, path);
				}
				Utils.OpenExplorer(folderRoot);
				loadingDialog.Close();
			};
			loadingDialog.ShowDialog(this);
		}
	}
}

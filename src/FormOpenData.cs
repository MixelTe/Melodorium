using System.Text.RegularExpressions;

namespace Melodorium
{
	public partial class FormOpenData : Form
	{
		private List<string> _files = [];
		private FormLoading _formLoading = new();

		public FormOpenData()
		{
			InitializeComponent();
			Init();
		}

		private void Init()
		{
			LblFolder.Text = Program.Settings.RootFolder == "" ? "Select root folder" : Program.Settings.RootFolder;
			InpIgnore.Text = string.Join("\r\n", Program.MusicData.Ignore);
		}

		private void FormOpenData_Shown(object sender, EventArgs e)
		{
			if (!SelectFolder())
				Close();
		}

		private void LblFolder_Click(object sender, EventArgs e)
		{
			SelectFolder();
		}

		private bool SelectFolder()
		{
			if (Program.Settings.RootFolder != "")
				RootFolderDialog.SelectedPath = Program.Settings.RootFolder;
			if (RootFolderDialog.ShowDialog() != DialogResult.OK)
				return false;
			Program.Settings.RootFolder = RootFolderDialog.SelectedPath;
			Program.Settings.Save();
			MusicData.Load();
			Init();
			ScanFolder();
			return true;
		}

		private void ScanFolder()
		{
			if (Program.Settings.RootFolder == "") return;
			_files = [];

			foreach (var path in Directory.EnumerateFiles(Program.Settings.RootFolder, "*",
				new EnumerationOptions { RecurseSubdirectories = true }))
			{
				if (path == Program.Settings.DataFilePath) continue;
				var rpath = Path.GetRelativePath(Program.Settings.RootFolder, path);
				_files.Add(rpath);
			}
			UpdateList();
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			UpdateList(saveData: true);
			Close();
		}

		private void BtnFilter_Click(object sender, EventArgs e)
		{
			UpdateList();
		}

		private void UpdateList(bool saveData = false)
		{
			using var loadingDialog = new FormLoading();
			loadingDialog.Job = () =>
			{
				var ignores = InpIgnore.Text.Split("\n")
					.Select(v => v.Trim())
					.Where(v =>
					{
						if (v == "") return false;
						try { Regex.Match("", v); return true; }
						catch { return false; }
					})
					.ToArray();
				ListMusic.Items.Clear();
				ListMusicIgnore.Items.Clear();
				var exts = new HashSet<string>();
				if (saveData)
				{
					Program.MusicData.Ignore = ignores;
					Program.MusicData.FilesIgnored = [];
				}
				List<string> files = [];
				List<string> filesNew = [];
				List<string> filesDel = [];
				List<string> filesIgnore = [];
				List<string> filesIgnoreNew = [];
				List<string> filesIgnoreDel = [];
				foreach (var file in _files)
				{
					var ignore = false;
					foreach (var pattern in ignores)
					{
						if (Regex.Match(file, pattern).Success)
						{
							ignore = true;
							break;
						}
					}
					if (ignore)
					{
						if (saveData)
							Program.MusicData.FilesIgnored.Add(file);
						else
						{
							if (Program.MusicData.FilesIgnored.Contains(file))
								filesIgnore.Add(file);
							else
								filesIgnoreNew.Add(file);
						}
					}
					else
					{
						exts.Add(Path.GetExtension(file));
						if (Program.MusicData.Files.Find(v => v.Path == file) == null)
							filesNew.Add(file);
						else
							files.Add(file);
					}
				}
				InpExts.Text = string.Join("; ", exts);
				if (saveData)
				{
					Program.MusicData.Files = Program.MusicData.Files
												.Where(v => files.Contains(v.Path))
												.ToList();
					foreach (var file in filesNew)
						Program.MusicData.AddNewFile(file);
					Program.MusicData.Save();
				}
				else
				{
					foreach (var file in Program.MusicData.Files)
						if (!files.Contains(file.Path))
							filesDel.Add(file.Path);
					foreach (var file in Program.MusicData.FilesIgnored)
						if (!filesIgnore.Contains(file))
							filesIgnoreDel.Add(file);
					files.Sort();
					filesNew.Sort();
					filesDel.Sort();
					filesIgnore.Sort();
					filesIgnoreNew.Sort();
					filesIgnoreDel.Sort();
					foreach (var file in filesDel)
						ListMusic.Items.Add(new ListViewItem(file) { ForeColor = Color.Tomato });
					foreach (var file in filesNew)
						ListMusic.Items.Add(new ListViewItem(file) { ForeColor = Color.Green });
					foreach (var file in files)
						ListMusic.Items.Add(file);
					foreach (var file in filesIgnoreDel)
						ListMusicIgnore.Items.Add(new ListViewItem(file) { ForeColor = Color.Tomato });
					foreach (var file in filesIgnoreNew)
						ListMusicIgnore.Items.Add(new ListViewItem(file) { ForeColor = Color.Green });
					foreach (var file in filesIgnore)
						ListMusicIgnore.Items.Add(file);
				}
				loadingDialog.Close();
			};
			loadingDialog.ShowDialog(this);
		}

		private void ListMusic_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			var info = ListMusic.HitTest(e.X, e.Y);
			var item = info.Item;

			if (item == null) return;

			if (InpIgnore.Text != "")
				InpIgnore.Text += "\r\n";
			InpIgnore.Text += Regex.Escape(item.Text);
			ListMusic.Items.Remove(item);
			item.Selected = false;
			item.ForeColor = Color.Green;
			ListMusicIgnore.Items.Insert(0, item);
			ListMusic.Items.Insert(0, new ListViewItem(item.Text) { ForeColor = Color.Tomato });
		}
	}
}

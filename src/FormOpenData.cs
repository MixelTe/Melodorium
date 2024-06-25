using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Melodorium
{
	public partial class FormOpenData : Form
	{
		private List<string> _files = [];
		private readonly FormLoading _formLoading = new();

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
			_files.Sort();
			UpdateList();
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			UpdateIgnore();
			Program.MusicData.Save();
			Close();
		}

		private void BtnSelect_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BtnFilter_Click(object sender, EventArgs e)
		{
			UpdateList();
		}

		private void UpdateList()
		{
			using var loadingDialog = new FormLoading();
			loadingDialog.Job = () =>
			{
				UpdateIgnore();
				TreeMusic.Nodes.Clear();
				TreeMusicIgnore.Nodes.Clear();
				var exts = new HashSet<string>();
				var folders = new List<Tuple<string, TreeNodeCollection>>();
				var foldersIgnore = new List<Tuple<string, TreeNodeCollection>>();
				var rootFiles = new List<string>();
				var rootFilesIgnore = new List<string>();
				foreach (var file in _files)
				{
					var ignore = false;
					foreach (var pattern in Program.MusicData.Ignore)
					{
						if (Regex.Match(file, pattern).Success)
						{
							ignore = true;
							break;
						}
					}
					var path = file.Split(Path.DirectorySeparatorChar);
					if (path.Length == 1)
					{
						if (ignore)
						{
							rootFilesIgnore.Add(file);
						}
						else
						{
							rootFiles.Add(file);
							exts.Add(Path.GetExtension(file));
						}
					}
					else
					{
						if (!ignore)
							exts.Add(Path.GetExtension(file));

						var curFolder = ignore ? foldersIgnore : folders;
						while (curFolder.Count > path.Length - 1)
							curFolder.RemoveAt(curFolder.Count - 1);
						for (var i = 0; i < path.Length - 1; i++)
						{
							if (i < curFolder.Count && path[i] != curFolder[i].Item1)
								curFolder.RemoveRange(i, curFolder.Count - i);
							if (i >= curFolder.Count)
							{
								var node = new TreeNode(path[i]);
								if (i == 0)
									(ignore ? TreeMusicIgnore : TreeMusic).Nodes.Add(node);
								else
									curFolder[i - 1].Item2.Add(node);
								curFolder.Add(Tuple.Create(path[i], node.Nodes));
							}
						}
						curFolder.Last().Item2.Add(new TreeNode(path.Last()) { Tag = file });
					}
				}
				foreach (var file in rootFiles)
					TreeMusic.Nodes.Add(new TreeNode(file) { Tag = file });
				foreach (var file in rootFilesIgnore)
					TreeMusicIgnore.Nodes.Add(new TreeNode(file) { Tag = file });
				for (var i = 0; i < TreeMusicIgnore.Nodes.Count; i++)
				{
					var node = TreeMusicIgnore.Nodes[i];
					if (node.Nodes.Count == 1 && node.Nodes[0].Nodes.Count != 0)
					{
						var innerNode = node.Nodes[0];
						node.Text += "/" + innerNode.Text;
						node.Nodes.Clear();
						for (var j = 0; j < innerNode.Nodes.Count; j++)
							node.Nodes.Add(innerNode.Nodes[j]);
					}
				}

				InpExts.Text = string.Join("; ", exts);
				loadingDialog.Close();
			};
			loadingDialog.ShowDialog(this);
		}

		private void UpdateIgnore()
		{
			Program.MusicData.Ignore = InpIgnore.Text.Split("\n")
				.Select(v => v.Trim())
				.Where(v =>
				{
					if (v == "") return false;
					try { Regex.Match("", v); return true; }
					catch { return false; }
				})
				.ToArray();
		}

		private void TreeMusic_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			var node = e.Node;
			if (node.Tag is string file)
			{
				if (InpIgnore.Text != "")
					InpIgnore.Text += "\r\n";
				InpIgnore.Text += $"^{Regex.Escape(file)}$";
				TreeMusic.Nodes.Remove(node);
				node.ForeColor = Color.Green;
				node.Text = file;
				TreeMusicIgnore.Nodes.Insert(0, node);
			}
		}
	}
}

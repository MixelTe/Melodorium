using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Melodorium
{
	public class MusicDataVersion
	{
		public int Version { get; set; } = -1;
	}
	public partial class MusicData
	{
		public static int DataVersion = 1;
		public int Version { get; set; } = DataVersion;
		public string[] Ignore { get; set; } = [];
		public Dictionary<string, string> FolderAuthor { get; set; } = [];
		public string[] Playlist { get; set; } = [];

		public List<MusicFile> Files = [];
		public List<string> Tags = [];

		public void Save()
		{
			var filename = Program.Settings.DataFilePath;
			if (filename == "") return;
			var json = JsonSerializer.Serialize(this);
			//var json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
			File.WriteAllText(filename, json);
		}
		public static void Load()
		{
			var filename = Program.Settings.DataFilePath;
			if (filename == "") return;
			if (!File.Exists(filename)) return;
			var json = File.ReadAllText(filename);
			var version = JsonSerializer.Deserialize<MusicDataVersion>(json)!.Version;
			if (version != DataVersion)
				throw new Exception($"Unsuported version of data file: {version}");
			Program.MusicData = JsonSerializer.Deserialize<MusicData>(json)!;
		}
		public static void LoadFull(Action? onFileLoaded = null, bool loadData = true)
		{
			Load();
			Program.MusicData.LoadFiles(onFileLoaded, loadData);
		}

		public List<string> GetFileNames(bool fullpath = false, bool includeIgnore = false)
		{
			var files = new List<string>();
			if (Program.Settings.RootFolder == "") return files;
			if (!Path.Exists(Program.Settings.RootFolder)) return files;

			foreach (var path in Directory.EnumerateFiles(Program.Settings.RootFolder, "*",
				new EnumerationOptions { RecurseSubdirectories = true }))
			{
				if (path == Program.Settings.DataFilePath) continue;
				var rpath = Path.GetRelativePath(Program.Settings.RootFolder, path);
				if (includeIgnore || !IsFileInIgnore(rpath))
					files.Add(fullpath ? path : rpath);
			}
			files.Sort();
			return files;
		}
		public bool IsFileInIgnore(string relpath)
		{
			if (RegexM3U8().Match(relpath).Success)
				return true;
			if (RegexJSON().Match(relpath).Success)
				return true;
			foreach (var pattern in Ignore)
				if (Regex.Match(relpath, pattern).Success)
					return true;
			return false;
		}

		[GeneratedRegex(".*\\.m3u8")]
		private static partial Regex RegexM3U8();

		[GeneratedRegex(".*\\.json")]
		private static partial Regex RegexJSON();

		public void LoadFiles(Action? onFileLoaded = null, bool loadData = true)
		{
			var tags = new HashSet<string>();
			foreach (var path in GetFileNames(fullpath: true))
			{
				var data = new MusicFile(path);
				if (loadData)
					data.Load();
				if (data.Data.Tag != "")
					tags.Add(data.Data.Tag);
				Files.Add(data);
				onFileLoaded?.Invoke();
			}
			Tags = tags.Order().ToList();
		}

		public void UpdateTagsList()
		{
			var tags = new HashSet<string>();
			foreach (var file in Files)
				if (file.Data.Tag != "")
					tags.Add(file.Data.Tag);
			Tags = tags.Order().ToList();
		}

		public string ExportData()
		{
			var filename = Program.Settings.ExportFilePath;
			if (filename == "") return "";
			var json = JsonSerializer.Serialize(new MusicDataExport(this), new JsonSerializerOptions { IncludeFields = true });
			File.WriteAllText(filename, json);
			return filename;
		}
	}

	public class MusicDataExport(MusicData data)
	{
		public int Version = data.Version;
		public string[] Ignore = data.Ignore;
		public Dictionary<string, string> FolderAuthor = data.FolderAuthor;
		public List<MusicFileData> Files = data.Files.Select(v => v.Data).ToList();
	}

	public class MusicFile
	{
		private string _fPath = "";
		public string FPath
		{
			get => _fPath; private set
			{
				_fPath = value;
				RPath = Path.GetRelativePath(Program.Settings.RootFolder, _fPath);
				Data.RPath = RPath;
				Folder = Path.GetDirectoryName(_fPath) ?? "";
				RFolder = Path.GetDirectoryName(RPath) ?? "";
				Name = Path.GetFileNameWithoutExtension(_fPath);
				FName = Path.GetFileName(_fPath);
				Ext = Path.GetExtension(_fPath);
				Author = "";
				SName = Name;
				PlaylistName = Name.Replace("_", " ");
				if (Name.Contains("_-_"))
				{
					var parts = Name.Split("_-_");
					Author = parts[0];
					SName = parts[1];
					PlaylistName = Author.Replace("_", " ") + " - " + SName.Replace("_", " ");
				}
				NormilizedFullName = Utils.NormalizeName(Name);
				NormilizedName = SName != "" ? Utils.NormalizeName(SName) : NormilizedFullName;
			}
		}
		public string Tags
		{
			get
			{
				var tags = "";
				if (Data.IsLoaded)
				{
					tags += " [";
					tags += Data.Mood.ToString()[..2] + ";";
					tags += Data.Like.ToString()[..2] + ";";
					tags += Data.Lang.ToString()[..2] + "]";
				}
				return tags;
			}
		}
		public string RPath { get; private set; } = "";
		public string Folder { get; private set; } = "";
		public string RFolder { get; private set; } = "";
		public string Name { get; private set; } = "";
		public string FName { get; private set; } = "";
		public string Ext { get; private set; } = "";
		public string Author { get; private set; } = "";
		public string SName { get; private set; } = "";
		public string NormilizedName { get; private set; } = "";
		public string NormilizedFullName { get; private set; } = "";
		public string PlaylistName { get; private set; } = "";
		public MusicFileData Data { get; set; } = new();
		private bool _metaLoaded = false;
		public string Title = "";
		public string Album = "";
		public string[] Artists = [];
		public TagLib.IPicture? Picture;
		public TimeSpan Duration;

		public MusicFile(string path)
		{
			FPath = path;
		}

		public static bool DataAreEqual(string file1, string file2)
		{
			var json1 = AlternativeDataStream.ReadString(file1, Settings.AlternativeDataStreamName);
			var json2 = AlternativeDataStream.ReadString(file2, Settings.AlternativeDataStreamName);
			return json1 == json2;
		}

		public void Load()
		{
			try
			{
				var json = AlternativeDataStream.ReadString(FPath, Settings.AlternativeDataStreamName);
				if (json == null) return;
				Data = JsonSerializer.Deserialize<MusicFileData>(json)!;
				Data.RPath = RPath;
				Data.IsLoaded = true;
			}
			catch (Exception e)
			{
				MessageBox.Show($"Error while loading file:\n./{RPath}\n{e.Message}", "Load file error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}

		public void Save()
		{
			if (!File.Exists(FPath))
			{
				MessageBox.Show($"File does not exist:\n./{RPath}", "Disappeared file", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			Data.IsLoaded = true;
			var json = JsonSerializer.Serialize(Data);
			AlternativeDataStream.WriteString(FPath, Settings.AlternativeDataStreamName, json);
		}

		public void LoadMeta()
		{
			if (_metaLoaded) return;
			_metaLoaded = true;

			try
			{
				using var tfile = TagLib.File.Create(FPath);
				Title = tfile.Tag.Title ?? "";
				Album = tfile.Tag.Album ?? "";
				Artists = tfile.Tag.Performers ?? [];
				if (tfile.Tag.Pictures.Length > 0)
					Picture = tfile.Tag.Pictures[0];
				Duration = tfile.Properties.Duration;
				var artists = string.Join(", ", Artists);
				artists = artists != "" ? artists : Author.Replace("_", " ");
				PlaylistName = (artists != "" ? artists + " - " : "") + (Title != "" ? Title : SName.Replace("_", " "));
			}
			catch (TagLib.CorruptFileException)
			{
				_metaLoaded = false;
				MessageBox.Show($"Cant load metadata of file:\n./{RPath}", "Corrupted file", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (TagLib.UnsupportedFormatException)
			{
				_metaLoaded = false;
				MessageBox.Show($"Cant load metadata of file:\n./{RPath}", "Unsupported file format", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch
			{
				_metaLoaded = false;
				MessageBox.Show($"Cant load metadata of file:\n./{RPath}", "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void SaveMeta()
		{
			if (!_metaLoaded) return;
			if (!File.Exists(FPath))
			{
				MessageBox.Show($"File does not exist:\n./{RPath}", "Disappeared file", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			try
			{
				using var tfile = TagLib.File.Create(FPath);

				tfile.Tag.Title = Title;
				tfile.Tag.Album = Album;
				tfile.Tag.Performers = Artists;
				tfile.Tag.Pictures = Picture == null ? [] : [Picture];

				tfile.Save();
			}
			catch
			{
				MessageBox.Show($"Cant save metadata of file:\n./{RPath}", "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void Move(string fullDestFileName)
		{
			File.Move(FPath, fullDestFileName);
			FPath = fullDestFileName;
		}
	}

	public class MusicFileData()
	{
		public string RPath = "";
		public bool IsLoaded = false;
		[JsonConverter(typeof(JsonTolerantEnumConverter))]
		public MusicMood Mood { get; set; } = MusicMood.Energistic;
		[JsonConverter(typeof(JsonTolerantEnumConverter))]
		public MusicLike Like { get; set; } = MusicLike.Good;
		[JsonConverter(typeof(JsonTolerantEnumConverter))]
		public MusicLang Lang { get; set; } = MusicLang.An;
		public bool Hidden { get; set; } = false;
		public string Tag { get; set; } = "";
	}

	public enum MusicMood
	{
		Rock = 0,
		Energistic = 1,
		Cheerful = 2,
		Calm = 3,
		Sleep = 4,
	}
	public enum MusicLike
	{
        Best = 0,
        Like = 1,
        Good = 2,
	}
	public enum MusicLang
	{
		No = 0,
		Ru = 1,
		An = 2,
		En = 3,
		Fr = 4,
		Ge = 5,
		It = 6,
		As = 7,
	}
}

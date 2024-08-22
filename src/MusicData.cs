	using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Melodorium
{
	internal class MusicDataVersion
	{
		public int Version { get; set; } = -1;
	}
	internal class MusicData
	{
		public static int DataVersion = 1;
		public int Version { get; set; } = DataVersion;
		public string[] Ignore { get; set; } = [];
		public Dictionary<string, string> FolderAuthor { get; set; } = [];

		public List<MusicFile> Files = [];

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
		public static void LoadFull()
		{
			Load();
			Program.MusicData.LoadFiles();
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
			foreach (var pattern in Ignore)
				if (Regex.Match(relpath, pattern).Success)
					return true;
			return false;
		}

		public void LoadFiles()
		{
            foreach (var path in GetFileNames(fullpath: true))
			{
				var data = new MusicFile(path);
				data.Load();
				Files.Add(data);
			}
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

	internal class MusicDataExport(MusicData data)
	{
		public int Version = data.Version;
		public string[] Ignore = data.Ignore;
		public Dictionary<string, string> FolderAuthor = data.FolderAuthor;
		public List<MusicFileData> Files = data.Files.Select(v => v.Data).ToList();
	}

	internal class MusicFile
	{
		private string _fPath = "";
		public string FPath
		{
			get => _fPath; set
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
				SName = "";
				if (Name.Contains("_-_"))
				{
					var parts = Name.Split("_-_");
					Author = parts[0];
					SName = parts[1];
				}
				NormilizedFullName = Utils.NormalizeName(Name);
				NormilizedName = SName != "" ? Utils.NormalizeName(SName) : NormilizedFullName;
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
		public MusicFileData Data { get; set; } = new();

		public MusicFile(string path)
		{
			FPath = path;
		}

		public void Load()
		{
			var json = AlternativeDataStream.ReadString(FPath, Settings.AlternativeDataStreamName);
			if (json == null) return;
			Data = JsonSerializer.Deserialize<MusicFileData>(json)!;
			Data.RPath = RPath;
			Data.IsLoaded = true;
		}

		public void Save()
		{
			Data.IsLoaded = true;
			var json = JsonSerializer.Serialize(Data);
			AlternativeDataStream.WriteString(FPath, Settings.AlternativeDataStreamName, json);
		}

		public void Move(string fullDestFileName)
		{
			File.Move(FPath, fullDestFileName);
			FPath = fullDestFileName;
		}
	}

	internal class MusicFileData()
	{
		public string RPath = "";
		public bool IsLoaded = false;
		public MusicMood Mood { get; set; } = MusicMood.Energistic;
		public MusicLike Like { get; set; } = MusicLike.Good;
		public MusicLang Lang { get; set; } = MusicLang.An;
		public bool Hidden { get; set; } = false;
	}

	internal enum MusicMood
	{
		Rock = 0,
		Energistic = 1,
		Calm = 2,
		Sleep = 3,
	}
    internal enum MusicLike
    {
        Best = 0,
        Like = 1,
        Good = 2,
    }
    internal enum MusicLang
    {
		No = 0,
		Ru = 1,
		An = 2,
		En = 3,
		Fr = 4,
		It = 5,
    }
}

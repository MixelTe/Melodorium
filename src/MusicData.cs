	using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
		public void ExportData()
		{
			var filename = Program.Settings.ExportFilePath;
			if (filename == "") return;
			var json = JsonSerializer.Serialize(this, new JsonSerializerOptions { IncludeFields = true });
			File.WriteAllText(filename, json);
		}
	}

    internal class MusicFile(string path)
	{
		public string FPath { get; set; } = path;
		public string RPath { get => Path.GetRelativePath(Program.Settings.RootFolder, FPath); }
		public string Folder { get => Path.GetDirectoryName(FPath) ?? ""; }
		public string RFolder { get => Path.GetDirectoryName(RPath) ?? ""; }
		public string Name { get => Path.GetFileNameWithoutExtension(FPath); }
		public string FName { get => Path.GetFileName(FPath); }
		public string Ext { get => Path.GetExtension(FPath); }
		public string Author { get => Name.Contains("_-_") ? Name.Split("_-_")[0] : ""; }
		public string SName { get => Name.Contains("_-_") ? Name.Split("_-_")[1] : ""; }
		public MusicFileData Data { get; set; } = new();

		public void Load()
		{
			var json = AlternativeDataStream.ReadString(FPath, Settings.AlternativeDataStreamName);
			if (json == null) return;
			Data = JsonSerializer.Deserialize<MusicFileData>(json)!;
		}

		public void Save()
		{
			var json = JsonSerializer.Serialize(Data);
			AlternativeDataStream.WriteString(FPath, Settings.AlternativeDataStreamName, json);
		}
	}

	internal class MusicFileData()
	{
		public string Mood { get; set; } = "";
	}
}

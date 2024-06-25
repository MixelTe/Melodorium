using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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

		public List<MusicFileData> Files = [];

		public void Save()
		{
			var filename = Program.Settings.DataFilePath;
			if (filename == "") return;
			//var json = JsonSerializer.Serialize(this);
			var json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
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
	}

    internal class MusicFileData(string path)
	{
		public string Path { get; set; } = path;
	}
}

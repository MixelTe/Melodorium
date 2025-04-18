﻿namespace Melodorium
{
	internal class Settings
	{
		private static readonly string _dataFileName = "melodorium.json";
		public static string AlternativeDataStreamName { get => "melodorium"; }

		public string RootFolder = "";
		public string DataFilePath { 
			get => RootFolder == "" ? "" : GetFullPath(_dataFileName); 
		}
		public string ExportFilePath { 
			get => RootFolder == "" ? "" : GetFullPath($"melodorium_{DateTime.Now:yyyy_MM_dd}.json");
		}
		public float Volume = 0.5f;
		public string ExportFolder = "";
		public Rectangle PlayerRect = new(-1, -1, 308, 306);
		public bool AutoApply = false;
		public bool Autoplay = false;
		public bool LoopTrack = false;
		public bool HotkeyEnabled = false;
		public Keys HotkeyShow = Keys.SelectMedia;
		public Keys HotkeyPlay = Keys.MediaPlayPause;
		public Keys HotkeyStop = Keys.MediaStop;
		public Keys HotkeyNext = Keys.MediaNextTrack;
		public Keys HotkeyPrev = Keys.MediaPreviousTrack;

		public void Save()
		{
			RegSerializer.Save(Program.KeyName, this);
		}
		public void Load()
		{
			RegSerializer.Load(Program.KeyName, this);
		}

		public string GetFullPath(string path)
		{
			return Path.Combine(RootFolder, path);
		}
	}
}

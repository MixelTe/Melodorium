namespace Melodorium
{
	internal class Settings
	{
		private static readonly string _dataFileName = "melodorium.json";
		public static readonly string AlternativeDataStreamName = "melodorium";

		public string RootFolder = "";
		public string DataFilePath { 
			get => RootFolder == "" ? "" : Path.Combine(RootFolder, _dataFileName); 
		}
		public string ExportFilePath { 
			get => RootFolder == "" ? "" : Path.Combine(RootFolder, $"melodorium_{DateTime.Now:yyyy_MM_dd}.json"); 
		}

		public void Save()
		{
			RegSerializer.Save(Program.KeyName, this);
		}
		public void Load()
		{
			RegSerializer.Load(Program.KeyName, this);
		}
	}
}

namespace Melodorium
{
	internal class Settings
	{
		private static readonly string _dataFileName = "melodorium.json";

		public string RootFolder = "";
		public string DataFilePath { 
			get => RootFolder == "" ? "" : Path.Combine(RootFolder, _dataFileName); 
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

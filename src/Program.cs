namespace Melodorium
{
	internal static class Program
	{
		public static readonly string KeyName = @"HKEY_CURRENT_USER\Software\MixelTe\Melodorium";
		public static Settings Settings = new();
		public static MusicData MusicData = new();
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			Settings.Load();
			Application.Run(new FormMain());
		}
	}
}
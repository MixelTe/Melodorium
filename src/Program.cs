using System.Globalization;

namespace Melodorium
{
	internal static class Program
	{
		public static readonly string KeyName = @"HKEY_CURRENT_USER\Software\MixelTe\Melodorium";
		public static Settings Settings = new();
		public static MusicData MusicData = new();
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
		public static FormPlayer Player = null;
		public static FormMain Manager = null;
		public static Hotkeys Hotkeys = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
		public static Mutex? mutex;

		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			mutex = new Mutex(true, "Melodorium{27b4fde6-827f-41dd-b0da-c325bc820645}", out var isNewCreated);
			if (!isNewCreated)
			{
				MessageBox.Show("Already launched", "Melodorium");
				return;
			}
			ApplicationConfiguration.Initialize();
			Settings.Load();
			Hotkeys = new();
			Player = new();
			Manager = new();
			Hotkeys.Register();
			Application.Run(Manager);
		}
	}
}
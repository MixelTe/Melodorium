using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace Melodorium
{
	internal static class AlternativeDataStream
	{
		public static void WriteString(string fileName, string streamName, string data)
		{
			var fullStreamName = fileName + ":" + streamName;

			var access = FileAccess.Write;
			using var h = WinApi.CreateFile(fullStreamName, (int)access, FileShare.ReadWrite, nint.Zero, FileMode.OpenOrCreate, 0, nint.Zero);
			using var f = new FileStream(h, access);
			using var sw = new StreamWriter(f);
			sw.Write(data);
		}
		public static string? ReadString(string fileName, string streamName)
		{
			var fullStreamName = fileName + ":" + streamName;

			var access = FileAccess.Read;
			using var h = WinApi.CreateFile(fullStreamName, (int)access, FileShare.ReadWrite, nint.Zero, FileMode.Open, 0, nint.Zero);
			if (h.IsInvalid) return null;

			using var f = new FileStream(h, access);
			using var sr = new StreamReader(f);
			return sr.ReadToEnd();
		}
	}

	internal static class WinApi
	{
		[DllImport("kernel32.dll", BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern SafeFileHandle CreateFile(string lpFileName, int dwDesiredAccess, FileShare dwShareMode, nint securityAttrs, FileMode dwCreationDisposition, int dwFlagsAndAttributes, nint hTemplateFile);
	}
}

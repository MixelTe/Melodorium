using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Melodorium
{
	internal static class HardLink
	{
		[DllImport("Kernel32.dll", CharSet = CharSet.Unicode)]
		static extern bool CreateHardLink(string lpFileName, string lpExistingFileName, IntPtr lpSecurityAttributes);

		public static bool Create(string fileName, string sourceFileName)
		{
			return CreateHardLink(fileName, sourceFileName, IntPtr.Zero);
		}
	}
}

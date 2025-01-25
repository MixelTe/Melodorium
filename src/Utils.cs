using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Melodorium
{
	internal static class Utils
	{
		private static readonly Dictionary<char, string> _nameReplacement = new()
		{
			{' ', "_"},
			{',', ""},
			{'.', ""},
			{'?', ""},
			{'\'', ""},
			{'"', ""},
			{'(', ""},
			{')', ""},
			{'!', ""},
			{'а', "a"},
			{'б', "b"},
			{'в', "v"},
			{'г', "g"},
			{'д', "d"},
			{'е', "e"},
			{'ё', "yo"},
			{'ж', "zh"},
			{'з', "z"},
			{'и', "i"},
			{'й', "j"},
			{'к', "k"},
			{'л', "l"},
			{'м', "m"},
			{'н', "n"},
			{'о', "o"},
			{'п', "p"},
			{'р', "r"},
			{'с', "s"},
			{'т', "t"},
			{'у', "u"},
			{'ф', "f"},
			{'х', "h"},
			{'ц', "c"},
			{'ч', "ch"},
			{'ш', "sh"},
			{'щ', "sch"},
			{'ъ', "j"},
			{'ы', "i"},
			{'ь', "j"},
			{'э', "e"},
			{'ю', "yu"},
			{'я', "ya"},
			{'А', "A"},
			{'Б', "B"},
			{'В', "V"},
			{'Г', "G"},
			{'Д', "D"},
			{'Е', "E"},
			{'Ё', "Yo"},
			{'Ж', "Zh"},
			{'З', "Z"},
			{'И', "I"},
			{'Й', "J"},
			{'К', "K"},
			{'Л', "L"},
			{'М', "M"},
			{'Н', "N"},
			{'О', "O"},
			{'П', "P"},
			{'Р', "R"},
			{'С', "S"},
			{'Т', "T"},
			{'У', "U"},
			{'Ф', "F"},
			{'Х', "H"},
			{'Ц', "C"},
			{'Ч', "Ch"},
			{'Ш', "Sh"},
			{'Щ', "Sch"},
			{'Ъ', "J"},
			{'Ы', "I"},
			{'Ь', "J"},
			{'Э', "E"},
			{'Ю', "Yu"},
			{'Я', "Ya"}
		};
		private static readonly string _normilizedChars = "abcdefghijklmnopqrstuvwxyz0123456789";

		public static string CleanName(string source)
		{
			var result = new StringBuilder();
			foreach (var letter in source)
				result.Append(_nameReplacement.GetValueOrDefault(letter, letter.ToString()));
			return result.ToString();
		}

		public static string NormalizeName(string source)
		{
			source = source.ToLower();
			var result = new StringBuilder();
			foreach (var letter in source)
			{
				var ch = _nameReplacement.GetValueOrDefault(letter, "");
				if (ch == "_") continue;
				if (ch != "") 
					result.Append(ch);
				else if (_normilizedChars.Contains(letter))
					result.Append(letter);
			}
			return result.ToString();
		}

		public static string Capitalize(this string input)
		{
			return input switch
			{
				null => throw new ArgumentNullException(nameof(input)),
				"" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
				_ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
			};
		}

		private static List<Tuple<int, int>> SmithWatermanAlgorithm(string A, string B, int Match = 3, int Dismatch = 3, int Gap = 1)
		{
			var N = A.Length + 1;
			var M = B.Length + 1;

			var H1 = ArrayPool<int>.Shared.Rent(N * M);
			for (int i = 0; i < N; i++)
				H1[i * M] = 0;
			for (int j = 0; j < M; j++)
				H1[j] = 0;

			var Mv = -1;
			var Mi = -1;
			var Mj = -1;
			unsafe
			{
				fixed (char* ptrA = A)
				fixed (char* ptrB = B)
				fixed (int* ptrH = H1)
				for (int i = 1; i < N; i++)
				{
					var Ai1 = ptrA[i - 1];
					var iM = i * M;
					var i1M = iM - M;
					var pv = 0;
					for (int j = 1; j < M; j++)
					{
						//var v = H[i, j] = Max(
						//	H[i - 1, j - 1] + (A[i - 1] == B[j - 1] ? Match : -Dismatch),
						//	H[i - 1, j] - Gap,
						//	H[i, j - 1] - Gap,
						//	0
						//);

						var v1 = ptrH[j - 1 + i1M] + (Ai1 == ptrB[j - 1] ? Match : -Dismatch);
						var v2 = ptrH[j + i1M] - Gap;
						var v = pv - Gap;
						if (0 > v) v = 0;
						if (v1 > v) v = v1;
						if (v2 > v) v = v2;
						pv = ptrH[j + iM] = v;

						if (v > Mv)
						{
							Mv = v;
							Mi = i;
							Mj = j;
						}
					}
				}
			}

			List<Tuple<int, int>> p = [];
			while (H1[Mj + Mi * M] > 0)
			{
				p.Add(Tuple.Create(Mi, Mj));
				var v1 = H1[(Mj - 1) + (Mi - 1) * M];
				var v2 = H1[Mj + (Mi - 1) * M];
				var v3 = H1[(Mj - 1) + Mi * M];
				var max = Max(v1, v2, v3);
				if (v1 == max) { Mi--; Mj--; }
				else if (v2 == max) Mi--;
				else Mj--;
				Mv = max;
			}
			ArrayPool<int>.Shared.Return(H1);
			return p;
		}

		public static float StringSimilarityBySmithWatermanAlgorithm(string A, string B, int Match = 3, int Dismatch = 3, int Gap = 1)
		{
			if (A == "" || B == "")
				return A == B ? 1 : 0;
			var p = SmithWatermanAlgorithm(A, B, Match, Dismatch, Gap);

			var li = -1;
			var lj = -1;
			var m = 0;
			var n = 0f;
            for (int pi = p.Count - 1; pi >= 0; pi--)
            {
				var i = p[pi].Item1;
				var j = p[pi].Item2;
				if (li != i && lj != j)
					if (A[i - 1] == B[j - 1])
						m += 1;
					else
						n += 1;
				else
					n += 0.5f;
				li = i;
				lj = j;
			}

			return (m + n / 2) / Math.Max(A.Length, B.Length);
		}

		public static int Max(int x, int y, int z)
		{
			return Math.Max(x, Math.Max(y, z));
		}

		public static int Max(int w, int x, int y, int z)
		{
			return Math.Max(w, Math.Max(x, Math.Max(y, z)));
		}

		public static void OpenExplorer(string path, bool folder = false)
		{
			var select = folder ? "" : "/select, ";
			Process.Start(new ProcessStartInfo()
			{
				FileName = "explorer",
				Arguments = $"/e, {select}\"{path}\"",
			});
		}

		public static string GetFreeFileName(string name, string ext, bool relative = true)
		{
			var path = relative ? Program.Settings.GetFullPath(name + ext) : name + ext;
			var i = 1;
			while (File.Exists(path))
				path = relative ? Program.Settings.GetFullPath(name + $"_{i++}" + ext) : name + $"_{i++}" + ext;
			return path;
		}

		public static string GetFreeDirectoryName(string name, bool relative = true)
		{
			var path = relative ? Program.Settings.GetFullPath(name) : name;
			var i = 1;
			while (Directory.Exists(path))
				path = relative ? Program.Settings.GetFullPath(name + $"_{i++}") : name + $"_{i++}";
			return path;
		}

		public static string RemoveInvalidFileNameChars(string filename)
		{
			return string.Concat(filename.Split(Path.GetInvalidFileNameChars()));
		}

		public static bool IsPathInsideFolder(string path, string folder)
		{
			var di1 = new DirectoryInfo(folder);
			var di2 = new DirectoryInfo(path);
			if (di2.FullName == di1.FullName)
				return true;
			while (di2.Parent != null)
				if (di2.Parent.FullName == di1.FullName)
					return true;
				else 
					di2 = di2.Parent;
			return false;
		}

		public static bool IsDirectoryWritable(string dirPath)
		{
			try
			{
				using FileStream fs = File.Create(
					Path.Combine(dirPath, Path.GetRandomFileName()),
					1,
					FileOptions.DeleteOnClose);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static List<string> GetFileNames(string directory, bool relative = false, bool order = false)
		{
			var files = Directory.EnumerateFiles(directory, "*", new EnumerationOptions { RecurseSubdirectories = true });
			if (relative) files = files.Select(path => Path.GetRelativePath(directory, path));
			if (order) files = files.Order();
			return files.ToList();
		}

		public static bool FilesContentsAreEqual(string filename1, string filename2)
		{
			var fileInfo1 = new FileInfo(filename1);
			var fileInfo2 = new FileInfo(filename2);
			if (fileInfo1.Length != fileInfo2.Length)
				return false;
			using var file1 = fileInfo1.OpenRead();
			using var file2 = fileInfo2.OpenRead();
			return StreamsContentsAreEqual(file1, file2);
		}

		private static bool StreamsContentsAreEqual(Stream stream1, Stream stream2)
		{
			const int bufferSize = 1024 * sizeof(long);
			var buffer1 = new byte[bufferSize];
			var buffer2 = new byte[bufferSize];

			while (true)
			{
				int count1 = stream1.Read(buffer1, 0, bufferSize);
				int count2 = stream2.Read(buffer2, 0, bufferSize);

				if (count1 != count2)
					return false;

				if (count1 == 0)
					return true;

				int iterations = (int)Math.Ceiling((double)count1 / sizeof(long));
				for (int i = 0; i < iterations; i++)
					if (BitConverter.ToInt64(buffer1, i * sizeof(long)) != BitConverter.ToInt64(buffer2, i * sizeof(long)))
						return false;
			}
		}

		public static void Shuffle<T>(this IList<T> list)
		{
            for (int i = list.Count - 1; i > 1; i--)
            {
				int k = Random.Shared.Next(i + 1);
				(list[i], list[k]) = (list[k], list[i]);
			}
		}

		public static T RandomItem<T>(this IList<T> list)
		{
			return list[Random.Shared.Next(list.Count)];
		}

		public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> source)
		{
			foreach (var item in source)
			{
				if (item != null)
					yield return item;
			}
		}
	}
}


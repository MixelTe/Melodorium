using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
		public static long t1 = 0;
		public static long t2 = 0;
		public static long t3 = 0;
		public static long C = 0;

		private static List<Tuple<int, int>> SmithWatermanAlgorithm(string A, string B, int Match = 3, int Dismatch = 3, int Gap = 1)
		{
			var N = A.Length + 1;
			var M = B.Length + 1;

			C += 1;
			var watch = Stopwatch.StartNew();
			var H1 = ArrayPool<int>.Shared.Rent(N * M);
			//var H1 = GC.AllocateUninitializedArray<int>(N * M);
			for (int i = 0; i < N; i++)
				H1[i * M] = 0;
			for (int j = 0; j < M; j++)
				H1[j] = 0;
			//var H1 = new int[N * M];
			//var H = new int[N, M];
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

			watch.Stop();
			t1 += watch.ElapsedTicks;
			watch = Stopwatch.StartNew();
			List<Tuple<int, int>> p = [];
			while (H1[Mj + Mi * M] > 0)
			//while (H[Mi, Mj] > 0)
			{
				p.Add(Tuple.Create(Mi, Mj));
				var v1 = H1[(Mj - 1) + (Mi - 1) * M];
				var v2 = H1[Mj + (Mi - 1) * M];
				var v3 = H1[(Mj - 1) + Mi * M];
				//var v1 = H[Mi - 1, Mj - 1];
				//var v2 = H[Mi - 1, Mj];
				//var v3 = H[Mi, Mj - 1];
				var max = Max(v1, v2, v3);
				if (v1 == max) { Mi--; Mj--; }
				else if (v2 == max) Mi--;
				else Mj--;
				Mv = max;
			}
			ArrayPool<int>.Shared.Return(H1);
			watch.Stop();
			t2 += watch.ElapsedTicks;
			return p;
		}

		public static float StringSimilarityBySmithWatermanAlgorithm(string A, string B, int Match = 3, int Dismatch = 3, int Gap = 1)
		{
			if (A == "" || B == "")
				return A == B ? 1 : 0;
			var p = SmithWatermanAlgorithm(A, B, Match, Dismatch, Gap);

			var watch = Stopwatch.StartNew();
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
			watch.Stop();
			t3 += watch.ElapsedTicks;

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
	}
}

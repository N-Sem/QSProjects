﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace QS.Utilities.Text
{

	/// <summary>
	/// Класс сравнивает строки с учетом значений чисел, если в строке есть числа вперемешку с текстом, то числа он сравнивает как число. Например 
	/// следующие будет отсортировано в виде как привык человек.
	/// А1, А6 и А11 будет отсортировано таким образом что 6 будет стоять между 1 и 11, если использовать сортировку в виде строки то 6 будет после 11.
	/// </summary>
	public class NaturalStringComparer : IComparer<string>
	{
		#region Экземпляр IComparer

		public int Compare(string x, string y)
		{
			return CompareStrings(x, y);
		}

		#endregion

		#region Статические методы

		private static readonly Regex _re = new Regex(@"(?<=\D)(?=\d)|(?<=\d)(?=\D)", RegexOptions.Compiled);

		public static int CompareStrings(string x, string y)
		{
			x = x.ToLower();
			y = y.ToLower();
			var a = _re.Split(x);
			var b = _re.Split(y);
			int i = 0;
			while (i < a.Length && i < b.Length) {
				int r = PartCompare(a[i], b[i]);
				if (r != 0)
					return r;
				++i;
			}

			if (a.Length == b.Length)
				return 0;
			return a.Length < b.Length ? -1 : 1;
		}

		private static int PartCompare(string x, string y)
		{
			int a, b;
			if (int.TryParse(x, out a) && int.TryParse(y, out b))
				return a.CompareTo(b);
			return x.CompareTo(y);
		}

		#endregion
	}
}

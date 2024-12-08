using System;
using System.Text.RegularExpressions;

namespace Advent24
{
	internal class Day03
	{
		public static void Star1()
		{
			var pinput = File.ReadAllLines("input/Day03.txt");
			var input = string.Join("", pinput);

			var muls = Regex.Matches(input, @"(mul\([0-9]{1,3},[0-9]{1,3}\))");
			var sum = 0L;
			var DO = true;

			foreach (var mul in muls)
			{
				var str = mul.ToString();

				var commapos = str.IndexOf(",", StringComparison.Ordinal);
				var endpos = str.IndexOf(")", StringComparison.Ordinal);

				var first = str?.Substring(4, commapos - 4);
				var second = str?.Substring(str.IndexOf(",", StringComparison.Ordinal) + 1,
					endpos - commapos - 1);
				sum += long.Parse(first) * long.Parse(second);
			}

			// 170807108
			Console.WriteLine(sum);
		}

		public static void Star2()
		{
			var pinput = File.ReadAllLines("input/Day03.txt");
			var input = string.Join("", pinput);

			var muls = Regex.Matches(input, @"(mul\([0-9]{1,3},[0-9]{1,3}\))|(do\(\))|(don't\(\))");
			var sum = 0L;
			var DO = true;

			foreach (var mul in muls)
			{
				var str = mul.ToString();

				if (str == "do()")
					DO = true;
				else if (str == "don't()")
					DO = false;
				else
				{
					if (!DO)
						continue;

					var commapos = str.IndexOf(",", StringComparison.Ordinal);
					var endpos = str.IndexOf(")", StringComparison.Ordinal);

					var first = str?.Substring(4, commapos - 4);
					var second = str?.Substring(str.IndexOf(",", StringComparison.Ordinal) + 1,
						endpos - commapos - 1);
					sum += long.Parse(first) * long.Parse(second);
				}
			}

			// 74838033
			Console.WriteLine(sum);
		}
	}
}
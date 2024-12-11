namespace Advent24
{
	internal class Day11
	{
		public static void Star1()
		{
			var strinput = File.ReadAllLines("input/Day11.txt")[0];

			var stones = strinput.Split(' ').Select(long.Parse).ToList();

			var sum = 0;

			int Divide(long s, int n)
			{
				if (n == 0)
					return 1;

				var digits = Math.Floor(Math.Log10(s) + 1);
				// 1st rule
				if (s == 0)
					return Divide(1, n - 1);
				// 2nd rule
				if (digits % 2 == 0)
				{
					var stone1 = (long)(s / Math.Pow(10, digits / 2));
					var stone2 = (long)(s % Math.Pow(10, digits / 2));
					var res1 = Divide(stone1, n - 1);
					var res2 = Divide(stone2, n - 1);
					return res1 + res2;
				}
				// 3rd rule
				return Divide(s * 2024, n - 1);
			}


			foreach (var stone in stones)
			{
				var result = Divide(stone, 25);
				sum += result;
			}

			// 183620
			Console.WriteLine(sum);
		}

		public static void Star2()
		{
			var strinput = File.ReadAllLines("input/Day11.txt")[0];

			var stones = strinput.Split(' ').Select(long.Parse).ToList();

			var dict = new Dictionary<long, Dictionary<long, long>>();
			var sum = 0L;

			long Divide(long s, long n)
			{
				if (n == 0)
					return 1;

				var digits = Math.Floor(Math.Log10(s) + 1);
				// 1st rule
				if (s == 0)
					return Divide(1, n - 1);
				// memory
				if (dict.TryGetValue(s, out var dictOfS))
				{
					if (dictOfS.TryGetValue(n, out var divide))
						return divide;
				}
				// 2nd rule
				if (digits % 2 == 0)
				{
					var stone1 = (long)(s / Math.Pow(10, digits / 2));
					var stone2 = (long)(s % Math.Pow(10, digits / 2));
					var res1 = Divide(stone1, n - 1);
					if (!dict.ContainsKey(stone1))
					{
						var dictOfStone1 = new Dictionary<long, long> {{n - 1, res1}};
						dict.Add(stone1, dictOfStone1);
					}
					else
					{
						var dictOfStone1 = dict[stone1];
						if (!dictOfStone1.ContainsKey(n - 1))
							dictOfStone1.Add(n - 1, res1);
					}

					var res2 = Divide(stone2, n - 1);
					if (!dict.ContainsKey(stone2))
					{
						var dictOfStone2 = new Dictionary<long, long> {{n - 1, res2}};
						dict.Add(stone2, dictOfStone2);
					}
					else
					{
						var dictOfStone2 = dict[stone2];
						if (!dictOfStone2.ContainsKey(n - 1))
							dictOfStone2.Add(n - 1, res2);
					}
					return res1 + res2;
				}
				// 3rd rule
				return Divide(s * 2024, n - 1);
			}


			foreach (var stone in stones)
			{
				var result = Divide(stone, 75);
				sum += result;
			}

			// 220377651399268
			Console.WriteLine(sum);
		}

	}
}
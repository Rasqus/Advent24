using System;

namespace Advent24
{
	internal class Day05
	{
		public static void Star1()
		{
			var input = File.ReadAllLines("input/Day05.txt");

			var sumOfMiddles = 0;

			var rules = new Dictionary<int, List<int>>();

			foreach (var line in input)
			{
				if (line.Contains("|"))
				{
					var first = int.Parse(line.Split('|')[0]);
					var second = int.Parse(line.Split("|")[1]);

					if (!rules.ContainsKey(first))
						rules.Add(first, new List<int>() { second });
					else rules[first].Add(second);
				}
				else if (line.Contains(","))
				{
					var numbers = line.Split(",").Select(int.Parse).ToList();

					var isCorrect = true;
					for (var i = 0; i < numbers.Count; i++)
					{
						for (var j = i + 1; j < numbers.Count; j++)
						{
							if (rules.ContainsKey(numbers[j]) && rules[numbers[j]].Contains(numbers[i]))
							{
								isCorrect = false;
								break;
							}
						}

						if (!isCorrect)
							break;
					}

					if (isCorrect)
						sumOfMiddles += numbers[numbers.Count / 2];
				}
			}


			// 6041
			Console.WriteLine(sumOfMiddles);
		}

		public static void Star2()
		{
			var input = File.ReadAllLines("input/Day05.txt");

			var sumOfMiddles = 0;

			var rules = new Dictionary<int, List<int>>();
			var incorrectLines = new List<string>();

			foreach (var line in input)
			{
				if (line.Contains("|"))
				{
					var first = int.Parse(line.Split('|')[0]);
					var second = int.Parse(line.Split("|")[1]);

					if (!rules.ContainsKey(first))
						rules.Add(first, new List<int> { second });
					else rules[first].Add(second);
				}
				else if (line.Contains(","))
				{
					var numbers = line.Split(",").Select(int.Parse).ToList();

					var isCorrect = true;
					for (var i = 0; i < numbers.Count; i++)
					{
						for (var j = i + 1; j < numbers.Count; j++)
						{
							if (rules.ContainsKey(numbers[j]) && rules[numbers[j]].Contains(numbers[i]))
							{
								isCorrect = false;
								break;
							}
						}

						if (!isCorrect)
							break;
					}

					if (!isCorrect)
						incorrectLines.Add(line);
				}
			}

			foreach (var line in incorrectLines)
			{
				var numbers = line.Split(",").Select(int.Parse).ToList();
				var isCorrect = false;

				while (!isCorrect)
				{
					isCorrect = true;
					for (var i = 0; i < numbers.Count; i++)
					{
						for (var j = i + 1; j < numbers.Count; j++)
						{
							if (rules.ContainsKey(numbers[j]) && rules[numbers[j]].Contains(numbers[i]))
							{
								(numbers[j], numbers[i]) = (numbers[i], numbers[j]);
								isCorrect = false;
							}
						}

						if (!isCorrect)
							break;
					}
				}

				sumOfMiddles += numbers[numbers.Count / 2];
			}

			// 2524
			Console.WriteLine(sumOfMiddles);
		}

	}
}
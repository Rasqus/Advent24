using System;

namespace Advent24
{
	internal class Day02
	{
		public static void Star1()
		{
			var input = File.ReadAllLines("input/Day02.txt");

			var safeCounter = 0;

			foreach (var lineStr in input)
			{
				var isUnsafe = false;
				var line = lineStr.Split(' ', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse).ToList();

				var isIncreasing = line[1] - line[0] > 0;
				for (var index = 0; index < line.Count - 1; index++)
				{
					var difference = line[index + 1] - line[index];
					if ((isIncreasing && (difference < 1 || difference > 3)) ||
						(!isIncreasing && (difference < -3 || difference > -1)))
					{
						isUnsafe = true;
						break;
					}
				}

				if (isUnsafe)
					continue;

				safeCounter++;
			}

			// 383
			Console.WriteLine(safeCounter);
		}

		public static void Star2()
		{
			var input = File.ReadAllLines("input/Day02.txt");

			var safeCounter = 0;

			foreach (var lineStr in input)
			{
				var isUnsafe = 0;
				var line = lineStr.Split(' ', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse).ToList();

				var badElements = line.Select(c => false).ToList();

				var isIncreasingCount = 0;
				var isDecreasingCount = 0;
				var isSameCount = 0;
				for (var i = 0; i < line.Count - 1; i++)
				{
					if (line[i + 1] > line[i])
						isIncreasingCount++;
					else if (line[i +1 ] < line[i])
						isDecreasingCount++;
					else if (line[i + 1] == line[i])
						isSameCount++;
				}

				if ((isIncreasingCount >= 2 && isDecreasingCount >= 2) || isSameCount > 1)
					continue;
				var isIncreasing = isIncreasingCount > isDecreasingCount;

				for (var index = 0; index < line.Count - 1; index++)
				{
					var difference = line[index + 1] - line[index];
					if ((isIncreasing && (difference < 1 || difference > 3)) ||
					    (!isIncreasing && (difference < -3 || difference > -1)))
					{
						//is unsafe
						isUnsafe++;
						//check if it's good without this element
						if (!CheckIfLineIsSafe(line.Where((v, i) => i != index).ToList()))
						{
							if (!CheckIfLineIsSafe(line.Where((v, i) => i != index+1).ToList()))
								isUnsafe+=2;
						}

						if (isUnsafe > 2)
							break;
					}
				}

				if (isUnsafe > 2)
				{
					Console.WriteLine($"line {lineStr} unsafe");
					continue;
				}

				safeCounter++;
			}

			// 436
			Console.WriteLine(safeCounter);
		}

		private static bool CheckIfLineIsSafe(List<int> line)
		{
			var isUnsafe = false;
			var isIncreasing = line[1] - line[0] > 0;
			for (var index = 0; index < line.Count - 1; index++)
			{
				var difference = line[index + 1] - line[index];
				if ((isIncreasing && (difference < 1 || difference > 3)) ||
					(!isIncreasing && (difference < -3 || difference > -1)))
				{
					isUnsafe = true;
					break;
				}
			}
			return !isUnsafe;
		}
	}
}
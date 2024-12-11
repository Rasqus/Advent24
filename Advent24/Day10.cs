namespace Advent24
{
	internal class Day10
	{
		public static void Star1()
		{
			var strinput = File.ReadAllLines("input/Day10.txt");

			var matrix = new List<List<int>>();

			foreach (var line in strinput)
			{
				var row = line.Select(c => c - 48).ToList();
				matrix.Add(row);
			}

			var sum = 0;

			for (int i = 0; i < matrix.Count; i++)
			{
				for (int j = 0; j < matrix[i].Count; j++)
				{
					if (matrix[i][j] == 0)
					{
						var visited = strinput.Select(line => line.Select(c => false).ToList()).ToList();

						int FindScore(int x, int y)
						{
							if (x < 0 || y < 0 || x >= matrix.Count || y >= matrix.Count)
								return 0;

							if (matrix[x][y] == 9 && !visited[x][y])
							{
								visited[x][y] = true;
								return 1;
							}

							var score = 0;
							if (x - 1 >= 0 && matrix[x - 1][y] == matrix[x][y] + 1)
								score += FindScore(x - 1, y);
							if (y - 1 >= 0 && matrix[x][y - 1] == matrix[x][y] + 1)
								score += FindScore(x, y - 1);
							if (y + 1 < matrix.Count && matrix[x][y + 1] == matrix[x][y] + 1)
								score += FindScore(x, y + 1);
							if (x + 1 < matrix.Count && matrix[x + 1][y] == matrix[x][y] + 1)
								score += FindScore(x + 1, y);
							return score;
						}
						var x = FindScore(i, j);
						//Console.WriteLine($"{i} {j} -> {x}");
						sum += x;
					}
				}
			}

			// 798
			Console.WriteLine(sum);
		}


		public static void Star2()
		{
			var strinput = File.ReadAllLines("input/Day10.txt");

			var matrix = new List<List<int>>();

			foreach (var line in strinput)
			{
				var row = line.Select(c => c - 48).ToList();
				matrix.Add(row);
			}

			var sum = 0;

			for (int i = 0; i < matrix.Count; i++)
			{
				for (int j = 0; j < matrix[i].Count; j++)
				{
					if (matrix[i][j] == 0)
					{
						int FindScore(int x, int y)
						{
							if (x < 0 || y < 0 || x >= matrix.Count || y >= matrix.Count)
								return 0;

							// part 2 is literally the same thing but less complicated
							if (matrix[x][y] == 9)
								return 1;

							var score = 0;
							if (x - 1 >= 0 && matrix[x - 1][y] == matrix[x][y] + 1)
								score += FindScore(x - 1, y);
							if (y - 1 >= 0 && matrix[x][y - 1] == matrix[x][y] + 1)
								score += FindScore(x, y - 1);
							if (y + 1 < matrix.Count && matrix[x][y + 1] == matrix[x][y] + 1)
								score += FindScore(x, y + 1);
							if (x + 1 < matrix.Count && matrix[x + 1][y] == matrix[x][y] + 1)
								score += FindScore(x + 1, y);
							return score;
						}
						var x = FindScore(i, j);
						sum += x;
					}
				}
			}

			// 1816
			Console.WriteLine(sum);
		}
	}
}
using System;

namespace Advent24
{
	internal class Day04
	{
		public static void Star1()
		{
			var input = File.ReadAllLines("input/Day04.txt");

			var matrix = new List<List<char>>();
			var counter = 0;

			foreach (var line in input)
			{
				var row = line.ToList();

				matrix.Add(row);
			}

			for (int j = 0; j < matrix.Count; j++)
				for (int i = 0; i < matrix[j].Count; i++)
					counter += XmasCountForPoint(i, j, matrix);

			// 2524
			Console.WriteLine(counter/2);
		}

		private static int XmasCountForPoint(int posX, int posY, List<List<char>> matrix)
		{
			var counter = 0;
			foreach (var dir in directions)
			{
				if (posY + dir.V * 3 > matrix.Count - 1 ||
				    posY + dir.V * 3 < 0 ||
				    posX + dir.H * 3 > matrix.Count - 1 ||
				    posX + dir.H * 3 < 0)
					continue;

				var first = matrix[posY][posX];
				var second = matrix[posY + dir.V * 1][posX + dir.H * 1];
				var third = matrix[posY + dir.V * 2][posX + dir.H * 2];
				var fourth = matrix[posY + dir.V * 3][posX + dir.H * 3];
				if (first == 'X' && second == 'M' && third == 'A' && fourth == 'S')
					counter++;
				else if (first == 'S' && second == 'A' && third == 'M' && fourth == 'X') 
					counter++;
			}

			return counter;
		}


		public static void Star2()
		{
			var input = File.ReadAllLines("input/Day04.txt");

			var matrix = new List<List<char>>();
			var counter = 0;

			foreach (var line in input)
			{
				var row = line.ToList();

				matrix.Add(row);
			}

			for (int j = 1; j < matrix.Count -1; j++)
				for (int i = 1; i < matrix[j].Count - 1; i++)
					counter += MasCountForPoint(i, j, matrix);

			// 1873
			Console.WriteLine(counter);
		}

		private static int MasCountForPoint(int posX, int posY, List<List<char>> matrix)
		{
			int counter = 0;

			if (matrix[posY][posX] == 'A')
			{
				if (isMandS(matrix[posY + 1][posX + 1], matrix[posY - 1][posX - 1]) &&
				    isMandS(matrix[posY - 1][posX + 1], matrix[posY + 1][posX - 1]))
					counter++;

			}

			return counter;
		}

		private static bool isMandS(char first, char second)
		{
			return first == 'M' && second == 'S' || first == 'S' && second == 'M';
		}


		private static List<Direction> directions = new()
		{
			new Direction(0, 1),
			new Direction(0, -1),
			new Direction(1, 0),
			new Direction(-1, 0),
			new Direction(1, 1),
			new Direction(1, -1),
			new Direction(-1, 1),
			new Direction(-1, -1),
		};


		private class Direction(int horizontal, int vertical)
		{
			public int H { get; } = horizontal;
			public int V { get; } = vertical;
		}
	}
}
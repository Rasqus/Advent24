using System;

namespace Advent24
{
	internal class Day06
	{
		public static void Star1()
		{
			var input = File.ReadAllLines("input/Day06.txt");

			var sumOfDistinctPositions = 0;

			var map = new List<List<char>>();

			foreach (var line in input)
			{
				var lineofchars = line.ToList();
				map.Add(lineofchars);
			}

			var startY = map.ToList().FindIndex(c => c.Contains('^'));
			var startX = map[startY].IndexOf('^');

			var currentY = startY;
			var currentX = startX;
			var directionX = 0;
			var directionY = -1;

			while (currentY < input.Length && currentY >= 0 &&
			       currentX < input.Length && currentX >= 0 &&
			       map[currentY][currentX] != '#')
			{
				var nextY = currentY + directionY;
				var nextX = currentX + directionX;

				if ( nextY >= 0 && nextY < input.Length && nextX >= 0 && nextX < input.Length && map[nextY][nextX] == '#')
				{
					if (directionY == 0 && directionX == 1)
					{
						directionY = 1;
						directionX = 0;
					}
					else if (directionY == 1 && directionX == 0)
					{
						directionY = 0;
						directionX = -1;
					}
					else if (directionY == 0 && directionX == -1)
					{
						directionY = -1;
						directionX = 0;
					}
					else if (directionY == -1 && directionX == 0)
					{
						directionY = 0;
						directionX = 1;
					}

					continue;
				}

				if (directionY == 0 && directionX == 1)
				{
					map[currentY][currentX] = 'R';
				}
				else if (directionY == 1 && directionX == 0)
				{
					map[currentY][currentX] = 'B';
				}
				else if (directionY == 0 && directionX == -1)
				{
					map[currentY][currentX] = 'L';
				}
				else if (directionY == -1 && directionX == 0)
				{
					map[currentY][currentX] = 'T';
				}

				currentY = nextY;
				currentX = nextX;
			}

			foreach (var l in map)
			{
				Console.WriteLine(new string(l.ToArray()));
				foreach (var c in l)
				{
					if (c == 'X')
						sumOfDistinctPositions++;
				}
			}

			// 5199
			Console.WriteLine(sumOfDistinctPositions);
		}

		public static void Star2()
		{
			var time = DateTime.Now;

			var input = File.ReadAllLines("input/Day06.txt");

			var map = new List<List<char>>();
			var mapDir = new List<List<Point>>();
			var visited = new List<List<Point>>();

			foreach (var line in input)
			{
				var lineofchars = line.ToList();
				map.Add(lineofchars);
				mapDir.Add(lineofchars.Select(_ => new Point()).ToList());
				visited.Add(lineofchars.Select(_ => new Point()).ToList());
			}

			var startY = map.ToList().FindIndex(c => c.Contains('^'));
			var startX = map[startY].IndexOf('^');

			var currentY = startY;
			var currentX = startX;
			var directionX = 0;
			var directionY = -1;

			while (currentY < input.Length && currentY >= 0 &&
				   currentX < input.Length && currentX >= 0 &&
				   map[currentY][currentX] != '#')
			{
				var nextY = currentY + directionY;
				var nextX = currentX + directionX;

				if (nextY >= 0 && nextY < input.Length && nextX >= 0 && nextX < input.Length && map[nextY][nextX] == '#')
				{
					if (directionY == 0 && directionX == 1)
					{
						directionY = 1;
						directionX = 0;
						mapDir[currentY][currentX].RB = true;
					}
					else if (directionY == 1 && directionX == 0)
					{
						directionY = 0;
						directionX = -1;
						mapDir[currentY][currentX].BL = true;
					}
					else if (directionY == 0 && directionX == -1)
					{
						directionY = -1;
						directionX = 0;
						mapDir[currentY][currentX].LT = true;
					}
					else if (directionY == -1 && directionX == 0)
					{
						directionY = 0;
						directionX = 1;
						mapDir[currentY][currentX].TR = true;
					}
					continue;
				}

				if (directionY == 0 && directionX == 1)
				{
					map[currentY][currentX] = 'R';
					mapDir[currentY][currentX].R = true;
				}
				else if (directionY == 1 && directionX == 0)
				{
					map[currentY][currentX] = 'B';
					mapDir[currentY][currentX].B = true;
				}
				else if (directionY == 0 && directionX == -1)
				{
					map[currentY][currentX] = 'L';
					mapDir[currentY][currentX].L = true;
				}
				else if (directionY == -1 && directionX == 0)
				{
					map[currentY][currentX] = 'T';
					mapDir[currentY][currentX].T = true;
				}

				currentY = nextY;
				currentX = nextX;
			}

			foreach (var l in map)
			{
				Console.WriteLine(new string(l.ToArray()));
			}

			for (int i = startY; i < input.Length - 1; i++)
			{
				if (map[i + 1][startX] == '#')
					break;
				mapDir[i][startX].T = true;
			}

			var points = 0;

			for (int i = 0; i < input.Length; i++)
			{
				for (int j = 0; j < input.Length; j++)
				{
					if (map[i][j] == '#')
						continue;

					foreach (var l in visited)
					{
						for (int x = 0; x < l.Count; x++)
							l[x] = new Point();
					}

					currentY = startY;
					currentX = startX;
					directionX = 0;
					directionY = -1;

					while (currentY < input.Length && currentY >= 0 &&
					       currentX < input.Length && currentX >= 0 &&
					       map[currentY][currentX] != '#')
					{
						var nextY = currentY + directionY;
						var nextX = currentX + directionX;

						if (nextY >= 0 && nextY < input.Length && nextX >= 0 && nextX < input.Length &&
						    (map[nextY][nextX] == '#' || (nextY == i && nextX == j)))
						{
							if (directionY == 0 && directionX == 1)
							{
								directionY = 1;
								directionX = 0;
							}
							else if (directionY == 1 && directionX == 0)
							{
								directionY = 0;
								directionX = -1;
							}
							else if (directionY == 0 && directionX == -1)
							{
								directionY = -1;
								directionX = 0;
							}
							else if (directionY == -1 && directionX == 0)
							{
								directionY = 0;
								directionX = 1;
							}
							continue;
						}

						if (directionX == 0 && directionY == -1)
						{
							if (visited[currentY][currentX].B)
							{
								points++;
								break;
							}

							visited[currentY][currentX].B = true;
						}
						else if (directionX == 0 && directionY == 1)
						{
							if (visited[currentY][currentX].T)
							{
								points++;
								break;
							}

							visited[currentY][currentX].T = true;
						}
						else if (directionX == 1 && directionY == 0)
						{
							if (visited[currentY][currentX].R)
							{
								points++;
								break;
							}

							visited[currentY][currentX].R = true;
						}
						else if (directionX == -1 && directionY == 0)
						{
							if (visited[currentY][currentX].L)
							{
								points++;
								break;
							}

							visited[currentY][currentX].L = true;
						}

						currentY = nextY;
						currentX = nextX;
					}
				}
			}

			foreach (var l in map)
			{
				Console.WriteLine(new string(l.ToArray()));
			}

			// 1915
			Console.WriteLine(points);

			var total = (DateTime.Now - time).TotalMilliseconds;
			Console.WriteLine(total);
		}


		private class Point
		{
			public bool L { get; set; }
			public bool T { get; set; }
			public bool R { get; set; }
			public bool B { get; set; }

			public bool LT { get; set; }
			public bool TR { get; set; }
			public bool RB { get; set; }
			public bool BL { get; set; }
		}
	}
}
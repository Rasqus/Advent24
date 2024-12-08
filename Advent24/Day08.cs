using System;
using System.Text;

namespace Advent24
{
	internal class Day08
	{
		public static void Star1()
		{
			var input = File.ReadAllLines("input/Day08.txt");

			int sum = 0;
			var antinodes = new List<List<bool>>();
			var map = new List<List<char>>();
			var dict = new Dictionary<char, List<Point>>();

			foreach (var lineStr in input)
			{
				var line = lineStr.Select(c => c).ToList();
				map.Add(line);
				antinodes.Add(line.Select(c => false).ToList());
			}

			for (var i = 0; i < map.Count; i++)
			{
				var line = map[i];
				for (var j = 0; j < line.Count; j++)
				{
					var c = line[j];
					if (c == '.')
						continue;

					if (!dict.ContainsKey(c))
					{
						dict.Add(c, new List<Point>{ new Point(i, j)});
					}
					else
					{
						dict[c].Add(new Point(i, j));
					}
				}
			}

			foreach (var k in dict.Keys)
			{
				var positions = dict[k];
				for (int i = 0; i < positions.Count; i++)
				{
					for (int j = i + 1; j < positions.Count; j++)
					{
						var point1 = positions[i];
						var point2 = positions[j];

						var antenna1X = point1.X - point2.X > 0
							? point1.X + Math.Abs(point1.X - point2.X)
							: point1.X - Math.Abs(point1.X - point2.X);
						var antenna2X = point1.X - point2.X > 0
							? point2.X - Math.Abs(point1.X - point2.X)
							: point2.X + Math.Abs(point1.X - point2.X);
						var antenna1Y = point1.Y - point2.Y > 0
							? point1.Y + Math.Abs(point1.Y - point2.Y)
							: point1.Y - Math.Abs(point1.Y - point2.Y);
						var antenna2Y = point1.Y - point2.Y > 0
							? point2.Y - Math.Abs(point1.Y - point2.Y)
							: point2.Y + Math.Abs(point1.Y - point2.Y);

						if (antenna1X >= 0 && antenna1Y >= 0 && antenna1X < map.Count && antenna1Y < map.Count)
						{
							antinodes[antenna1X][antenna1Y] = true;
						}
						if (antenna2X >= 0 && antenna2Y >= 0 && antenna2X < map.Count && antenna2Y < map.Count)
						{
							antinodes[antenna2X][antenna2Y] = true;
						}
					}
				}
			}

			foreach (var line in antinodes)
			{
				sum += line.Count(c => c);
				var lineStr = new StringBuilder();
				foreach (var c in line)
				{
					lineStr.Append(c ? "1" : "0");
				}

				Console.WriteLine(lineStr);
			}

			// 529 - too high
			Console.WriteLine(sum);
		}

		public static void Star2()
		{
			var input = File.ReadAllLines("input/Day08.txt");

			int sum = 0;
			var antinodes = new List<List<bool>>();
			var map = new List<List<char>>();
			var dict = new Dictionary<char, List<Point>>();

			foreach (var lineStr in input)
			{
				var line = lineStr.Select(c => c).ToList();
				map.Add(line);
				antinodes.Add(line.Select(c => false).ToList());
			}

			for (var i = 0; i < map.Count; i++)
			{
				var line = map[i];
				for (var j = 0; j < line.Count; j++)
				{
					var c = line[j];
					if (c == '.')
						continue;

					if (!dict.ContainsKey(c))
					{
						dict.Add(c, new List<Point> { new Point(i, j) });
					}
					else
					{
						dict[c].Add(new Point(i, j));
					}
				}
			}

			foreach (var k in dict.Keys)
			{
				var positions = dict[k];
				for (int i = 0; i < positions.Count; i++)
				{
					for (int j = i + 1; j < positions.Count; j++)
					{
						var point1 = positions[i];
						var point2 = positions[j];

						antinodes[point1.X][point1.Y] = true;
						antinodes[point2.X][point2.Y] = true;

						var antenna1X = point1.X - point2.X > 0
							? point1.X + Math.Abs(point1.X - point2.X)
							: point1.X - Math.Abs(point1.X - point2.X);
						var antenna1Y = point1.Y - point2.Y > 0
							? point1.Y + Math.Abs(point1.Y - point2.Y)
							: point1.Y - Math.Abs(point1.Y - point2.Y);

						while (antenna1X >= 0 && antenna1Y >= 0 && antenna1X < map.Count && antenna1Y < map.Count)
						{
							antinodes[antenna1X][antenna1Y] = true;

							if (point1.X - point2.X > 0)
							{
								antenna1X += Math.Abs(point1.X - point2.X);
							}
							else
							{
								antenna1X -= Math.Abs(point1.X - point2.X);
							}
							if (point1.Y - point2.Y > 0)
							{
								antenna1Y += Math.Abs(point1.Y - point2.Y);
							}
							else
							{
								antenna1Y -= Math.Abs(point1.Y - point2.Y);
							}
						}

						var antenna2X = point1.X - point2.X > 0
							? point2.X - Math.Abs(point1.X - point2.X)
							: point2.X + Math.Abs(point1.X - point2.X);
						var antenna2Y = point1.Y - point2.Y > 0
							? point2.Y - Math.Abs(point1.Y - point2.Y)
							: point2.Y + Math.Abs(point1.Y - point2.Y);


						while (antenna2X >= 0 && antenna2Y >= 0 && antenna2X < map.Count && antenna2Y < map.Count)
						{
							antinodes[antenna2X][antenna2Y] = true;

							if (point1.X - point2.X > 0)
								antenna2X -= Math.Abs(point1.X - point2.X);
							else
								antenna2X += Math.Abs(point1.X - point2.X);

							if (point1.Y - point2.Y > 0)
								antenna2Y -= Math.Abs(point1.Y - point2.Y);
							else antenna2Y += Math.Abs(point1.Y - point2.Y);

						}
					}
				}
			}

			foreach (var line in antinodes)
			{
				sum += line.Count(c => c);
				var lineStr = new StringBuilder();
				foreach (var c in line)
				{
					lineStr.Append(c ? "1" : "0");
				}

				Console.WriteLine(lineStr);
			}

			// 1280
			Console.WriteLine(sum);
		}


		private class Point()
		{
			public Point(int x, int y) : this()
			{
				X = x;
				Y = y;
			}
			public int X { get; }
			public int Y { get; }

			public override string ToString()
			{
				return $"X = {X}, Y = {Y}";
			}
		}
	}
}
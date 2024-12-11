namespace Advent24
{
	internal class Day09
	{
		public static void Star1()
		{
			var strinput = File.ReadAllLines("input/Day09.txt")[0];
			var input = new List<int>();

			var space = false;
			int num = 0;
			foreach (var c in strinput)
			{
				if (space)
				{
					for (int k = 0; k < c - 48; k++) 
						input.Add(-1);
				}
				else
				{
					for (int k = 0; k < c - 48; k++) 
						input.Add(num);

					num++;
				}

				space = !space;
			}

			ulong sum = 0;
			int i = 0;
			int x = input.Count - 1;
			while (i <= x)
			{
				if (input[i] == -1)
				{
					if (input[x] == -1)
					{
						x--;
						continue;
					}

					sum += (ulong)(input[x] * i);
					x--;
					i++;
				}
				else
				{
					sum += (ulong)(input[i] * i);
					i++;
				}
			}

			// 6334655979668
			Console.WriteLine(sum);
		}

		public static void Star2()
		{
			var strinput = File.ReadAllLines("input/Day09.txt")[0];
			var input = new List<int>();

			var space = false;
			int num = 0;
			foreach (var c in strinput)
			{
				if (space)
				{
					for (int k = 0; k < c - 48; k++)
						input.Add(-1);
				}
				else
				{
					for (int k = 0; k < c - 48; k++)
						input.Add(num);

					num++;
				}

				space = !space;
			}

			var moved = input.Select(x => false).ToList();

			int x = input.Count - 1;

			while (x > 0)
			{
				if (input[x] == -1)
				{
					x--;
				}
				else if (!moved[x])
				{
					var length = x - input.IndexOf(input[x]) + 1;
					for (int k = 0; k < x; k++)
					{
						if (input[k] != -1)
						{
							continue;
						}

						// first big enough empty space
						if (input.FindIndex(k, c => c != -1) - k < length)
							continue;

						for (int j = k; j < k + length; j++)
						{
							input[j] = input[x];
							moved[j] = true;
						}

						for (int j = x; j > x - length; j--)
							input[j] = -1;

						break;
					}

					x -= length;
				}
				else
				{
					x--;
				}
			}


			ulong sum = 0;
			int i = 0;
			while (i <= input.Count - 1)
			{
				if (input[i] == -1)
				{
					i++;
				}
				else
				{
					sum += (ulong)(input[i] * i);
					i++;
				}
			}

			// 6349492251099
			Console.WriteLine(sum);
		}
	}
}
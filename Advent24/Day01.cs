namespace Advent24
{
	internal class Day01
	{
		public static void Star1()
		{
			var input = File.ReadAllLines("input/Day01.txt");

			var list1 = new List<int>();
			var list2 = new List<int>();

			foreach (var item in input)
			{
				var numbers = item.Split(' ', StringSplitOptions.RemoveEmptyEntries);
				list1.Add(int.Parse(numbers[0]));
				list2.Add(int.Parse(numbers[1]));
			}

			list1.Sort();
			list2.Sort();

			var sum = list1.Select((t, i) => Math.Abs(t - list2[i])).Sum();

			// sum = 2580760
			Console.WriteLine(sum);
		}

		public static void Star2()
		{
			var input = File.ReadAllLines("input/Day01.txt");

			var list1 = new List<int>();
			var dict = new Dictionary<int, int>();

			foreach (var item in input)
			{
				var numbers = item.Split(' ', StringSplitOptions.RemoveEmptyEntries);
				list1.Add(int.Parse(numbers[0]));
				
				var num2 = int.Parse(numbers[1]);
				if (!dict.ContainsKey(num2))
					dict[num2] = 1;
				else
					dict[num2]++;
			}

			var score = list1.Where(t => dict.ContainsKey(t)).Sum(t => t * dict[t]);

			Console.WriteLine(score);
		}
	}
}

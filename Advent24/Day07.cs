using System;

namespace Advent24
{
	internal class Day07
	{
		public static void Star1()
		{
			var input = File.ReadAllLines("input/Day07.txt");

			ulong sum = 0;

			foreach (var line in input)
			{
				string valueStr = line.Split(":")[0];
				ulong value = ulong.Parse(line.Split(": ")[0]);
				string numbersStr = line.Split(":")[1];
				var values = numbersStr.Split(" ", StringSplitOptions.RemoveEmptyEntries)
					.Select(ulong.Parse).ToList();

				List<ulong> results = new List<ulong>();
				Check1(values, 0, 0, results);

				if (results.Contains(value)) 
					sum += value;
			}

			// 1611660863222 - correct 1
			Console.WriteLine(sum);
		}

		private static void Check1(List<ulong> values, int pos, ulong current, List<ulong> results)
		{
			if (pos == values.Count)
				return;

			Check1(values, pos + 1, current + values[pos], results);
			if (pos == values.Count - 1)
				results.Add((ulong)((ulong)current + (ulong)values[pos]));

			Check1(values, pos + 1, current * values[pos], results);
			if (pos == values.Count - 1)
				results.Add((ulong) ((ulong)current * (ulong)values[pos]));
		}


		public static void Star2()
		{
			var input = File.ReadAllLines("input/Day07.txt");

			ulong sum = 0;

			foreach (var line in input)
			{
				string valueStr = line.Split(":")[0];
				ulong value = ulong.Parse(line.Split(": ")[0]);
				string numbersStr = line.Split(":")[1];
				var values = numbersStr.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.Select(ulong.Parse).ToList();

				List<ulong> results = new List<ulong>();
				Check2(values, 0, 0, results);

				if (results.Contains(value))
					sum += value;
			}

			// 945341732469724
			Console.WriteLine(sum);
		}

		private static void Check2(List<ulong> values, int pos, ulong current, List<ulong> results)
		{
			if (pos == values.Count)
				return;

			Check2(values, pos + 1, current + values[pos], results);
			if (pos == values.Count - 1)
				results.Add((ulong)((ulong)current + (ulong)values[pos]));

			Check2(values, pos + 1, current * values[pos], results);
			if (pos == values.Count - 1)
				results.Add((ulong)((ulong)current * (ulong)values[pos]));

			var str = current.ToString() + values[pos].ToString();
			Check2(values, pos + 1, ulong.Parse(str), results);
			if (pos == values.Count - 1)
				results.Add(ulong.Parse(str));

			// possible optimization - check only last digit and if ok check next digits to left and so on
		}
	}
}
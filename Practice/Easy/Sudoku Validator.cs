using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
		List<HashSet<int>> columns = Enumerable.Range(1, 9).Select(x => new HashSet<int>()).ToList();
		
		List<List<HashSet<int>>> subgrids = Enumerable
			.Range(1, 3)
			.Select(x => Enumerable.Range(1, 3).Select(y => new HashSet<int>()).ToList())
			.ToList();

        for (int i = 0; i < 9; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            var row = new HashSet<int>();

            for (int j = 0; j < 9; j++)
            {
                int digit = int.Parse(inputs[j]);

                if 
                (
                    !row.Add(digit)
                    || !columns[j].Add(digit)
                    || !subgrids[i / 3][j / 3].Add(digit)
                )
                {
                    Console.WriteLine("false");

                    return;
                }
            }
        }

        Console.WriteLine("true");
    }
}
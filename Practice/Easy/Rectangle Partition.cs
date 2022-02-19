using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        List<int> widths = new List<int> {0};
        List<int> heights = new List<int> {0};
        string[] line1 = Console.ReadLine().Split(' ');
        int totalWidth = int.Parse(line1[0]);
        int totalHeight = int.Parse(line1[1]);
        widths.AddRange(Console.ReadLine().Split(' ').Select(x => int.Parse(x)));
        heights.AddRange(Console.ReadLine().Split(' ').Select(x => int.Parse(x)));
        widths.Add(totalWidth);
        heights.Add(totalHeight);
		Dictionary<int, int> possibleWidths = GetDifferences(widths);
		Dictionary<int, int> possibleHeights = GetDifferences(heights);
        int numberOfSquares = 0;
		
		foreach(int possibleWidth in possibleWidths.Keys)
		{
			if (possibleHeights.ContainsKey(possibleWidth))
			{
				numberOfSquares += possibleWidths[possibleWidth] * possibleHeights[possibleWidth];
			}
		}

        Console.WriteLine(numberOfSquares);
    }
	
	private static Dictionary<int, int> GetDifferences(List<int> ints)
	{
		Dictionary<int, int> differences = new Dictionary<int, int>();
		
		for (int int1 = 1; int1 < ints.Count; int1++)
        {
            for (int int2 = 0; int2 < int1; int2++)
			{
				int difference = ints[int1] - ints[int2];
				
				if (!differences.ContainsKey(difference))
				{
					differences.Add(difference, 1);
				}
				else
				{
					differences[difference] = differences[difference] + 1;
				}
			}
		}

        return differences;
	}
}
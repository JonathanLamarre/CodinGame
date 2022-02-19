using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        List<string> theObject = Enumerable
            .Repeat(0, int.Parse(Console.ReadLine().Split(' ')[0]))
            .Select(_ => Console.ReadLine())
            .ToList();

        int objectHeight = theObject.Count;
        int objectWidth = theObject[0].Length;

        List<string> grid = Enumerable
            .Repeat(0, int.Parse(Console.ReadLine().Split(' ')[0]))
            .Select(_ => Console.ReadLine())
            .ToList();

        int gridHeight = grid.Count;
        int gridWidth = grid[0].Length;
        int numberOfSolutions = 0;
        int indexOfHeightOfLastSolution = 0;
        int indexOfWidthOfLastSolution = 0;

        for (int i = 0; i < gridHeight - (objectHeight - 1); i++)
        {
            for (int j = 0; j < gridWidth - (objectWidth - 1); j++)
            {
                bool DoesObjectFit()
                {
                    for (int m = 0; m < objectHeight; m++)
                    {
                        for (int n = 0; n < objectWidth; n++)
                        {
                            if (grid[i + m][j + n] == '#' && theObject[m][n] == '*') return false;
                        }
                    }

                    return true;
                }

                if (DoesObjectFit())
                {
                    numberOfSolutions++;
                    indexOfHeightOfLastSolution = i;
                    indexOfWidthOfLastSolution = j;
                }
            }
        }

        Console.WriteLine(numberOfSolutions);

        if (numberOfSolutions != 1) return;

        for (int i = 0; i < objectHeight; i++)
        {
            var line = new StringBuilder(grid[indexOfHeightOfLastSolution + i]);

            for (int j = 0; j < objectWidth; j++)
            {
                if (theObject[i][j] == '*')
                {
                    line[indexOfWidthOfLastSolution + j] = '*';
                }
            }

            grid[indexOfHeightOfLastSolution + i] = line.ToString();
        }

        grid.ForEach(x => Console.WriteLine(x));
    }
}
using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        (int h, int w, int n) = (int.Parse(inputs[0]), int.Parse(inputs[1]), int.Parse(inputs[2]));
        string alive = Console.ReadLine();
        string dead = Console.ReadLine();
        var grid = new List<List<char>>();

        for (int i = 0; i < h; i++)
        {
            string line = Console.ReadLine();
            grid.Add(line.ToList());
        }

        for (int turnNumber = 0; turnNumber < n; turnNumber++)
        {
            List<List<char>> gridCopy = grid.Select(x => x.ToList()).ToList();

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    int numberOAlivefNeighbours =
                        (i == 0 || j == 0 || grid[i - 1][j - 1] == '.' ? 0 : 1)
                        + (i == 0 || grid[i - 1][j] == '.' ? 0 : 1)
                        + (i == 0 || j == w - 1 || grid[i - 1][j + 1] == '.' ? 0 : 1)
                        + (j == 0 || grid[i][j - 1] == '.' ? 0 : 1)
                        + (j == w - 1 || grid[i][j + 1] == '.' ? 0 : 1)
                        + (i == h - 1 || j == 0 || grid[i + 1][j - 1] == '.' ? 0 : 1)
                        + (i == h - 1 || grid[i + 1][j] == '.' ? 0 : 1)
                        + (i == h - 1 || j == w - 1 || grid[i + 1][j + 1] == '.' ? 0 : 1);

                    if (grid[i][j] == 'O')
                    {
                        if (alive[numberOAlivefNeighbours] == '0')
                        {
                            gridCopy[i][j] = '.';
                        }
                    }
                    else
                    {
                        if (dead[numberOAlivefNeighbours] == '1')
                        {
                            gridCopy[i][j] = 'O';
                        }
                    }
                }
            }

            grid = gridCopy;
        }

        foreach(string line in grid.Select(x => new string(x.ToArray())))
        {
            Console.WriteLine(line);
        }
    }
}
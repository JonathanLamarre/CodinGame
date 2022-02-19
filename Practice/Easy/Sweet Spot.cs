using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        char[][] grid = Enumerable
            .Repeat(0, int.Parse(Console.ReadLine()))
            .Select(_ => Console.ReadLine().ToArray())
            .ToArray();

        var explodedBBombs = new HashSet<(int,int)>();

        void ExplodeBBomb(int i, int j)
        {
            if (grid[i][j] != 'B' || explodedBBombs.Contains((i, j))) return;

            explodedBBombs.Add((i, j));

            for (int x = Math.Max(0, i - 3); x <= Math.Min(grid.Length - 1, i + 3); x++)
            {
                ExplodeBBomb(x, j);
                grid[x][j] = (char)Math.Max(grid[x][j], '4' - Math.Abs(i - x));
            }

            for (int y = Math.Max(0, j - 3); y <= Math.Min(grid.Length - 1, j + 3); y++)
            {
                ExplodeBBomb(i, y);
                grid[i][y] = (char)Math.Max(grid[i][y], '4' - Math.Abs(j - y));
            }
        }

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid.Length; j++)
            {
                if (grid[i][j] == 'A')
                {
                    for (int x = Math.Max(0, i - 3); x <= Math.Min(grid.Length - 1, i + 3); x++)
                    {
                        for (int y = Math.Max(0, j - 3); y <= Math.Min(grid.Length - 1, j + 3); y++)
                        {
                            ExplodeBBomb(x, y);
                            grid[x][y] = (char)Math.Max(grid[x][y], ('4' - Math.Max(Math.Abs(i - x), Math.Abs(j - y))));
                        }
                    }
                }
                else if (grid[i][j] == 'H')
                {
                    for (int x = Math.Max(0, i - 3); x <= Math.Min(grid.Length - 1, i + 3); x++)
                    {
                        for (int y = Math.Max(0, j - 3); y <= Math.Min(grid.Length - 1, j + 3); y++)
                        {                            
                            ExplodeBBomb(x, y);
                            grid[x][y] = (char)Math.Max(grid[x][y], '5');
                        }
                    }
                }
            }
        }

        grid.ToList().ForEach(x => Console.WriteLine(new string(x)));
    }
}
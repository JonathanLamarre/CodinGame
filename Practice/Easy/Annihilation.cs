using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        (int H, int W) = (int.Parse(inputs[0]), int.Parse(inputs[1]));
        char[][] grid = Enumerable.Range(0, H).Select(x => Console.ReadLine().ToArray()).ToArray();
        char[][] GetEmptyGrid() => Enumerable.Range(0, H).Select(x => Enumerable.Repeat('.', W).ToArray()).ToArray();
        bool IsArrow(char c) => c == '<' || c == '^' || c == '>' || c == 'v';
        int numberOfArrows = grid.Select(x => x.Count(IsArrow)).Sum();
        HashSet<(int, int)> collisions = new HashSet<(int, int)>();
        int numberOfSteps = 0;

        while(numberOfArrows > 0)
        {
            char[][] workingGrid = GetEmptyGrid();

            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    int i2 = (i + (grid[i][j] == '^' ? -1 : grid[i][j] == 'v' ? 1 : 0) + H) % H;
                    int j2 = (j + (grid[i][j] == '<' ? -1 : grid[i][j] == '>' ? 1 : 0) + W) % W;

                    if (!IsArrow(grid[i][j])) continue;
                    
                    if (IsArrow(workingGrid[i2][j2]))
                        {
                            (int, int) collision = (i2, j2);
                            numberOfArrows -= collisions.Contains(collision) ? 1 : 2;
                            collisions.Add(collision);
                        }
                        
                        workingGrid[i2][j2] = grid[i][j];
                }
            }

            foreach((int, int) collision in collisions)
            {
                workingGrid[collision.Item1][collision.Item2] = '.';
            }

            collisions.Clear();
            grid = workingGrid;
            numberOfSteps++;
        }

        Console.WriteLine(numberOfSteps);
    }
}
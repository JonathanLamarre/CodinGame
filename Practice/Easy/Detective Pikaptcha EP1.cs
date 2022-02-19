using System;

namespace Player
{
    public class Player
    {
        public static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine()?.Split(' ') ?? throw new InvalidOperationException();
            int width = int.Parse(inputs[0]);
            int height = int.Parse(inputs[1]);
            int[,] grid = new int[height, width];

            for (int i = 0; i < height; i++)
            {
                string line = Console.ReadLine() ?? throw new InvalidOperationException();

                for (int j = 0; j < line.Length; j++)
                {
                    grid[i, j] = line[j] == '#' ? -1 : 0;
                }
            }

            for (int i = 0; i < height; i++)
            {
                string line = string.Empty;

                for (int j = 0; j < width; j++)
                {
                    if (grid[i, j] == -1)
                    {
                        line += "#";

                        continue;
                    }

                    int adjacentPassages = i == 0 || grid[i - 1, j] == -1 ? 0 : 1;
                    adjacentPassages += i == height - 1 || grid[i + 1, j] == -1 ? 0 : 1;
                    adjacentPassages += j == 0 || grid[i, j - 1] == -1 ? 0 : 1;
                    adjacentPassages += j == width -1 || grid[i, j + 1] == -1 ? 0 : 1;
                    line += adjacentPassages.ToString();
                }

                Console.WriteLine(line);
            }
        }
    }
}
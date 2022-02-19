using System;
using System.Collections.Generic;

namespace Solution
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine()?.Split(' ') ?? throw new ArgumentException();
            int width = int.Parse(inputs[0]);
            int height = int.Parse(inputs[1]);        
            bool[,] graph = new bool[height - 2, width / 3];            
            var starts = new List<char>();
            var targets = new List<char>();

            for (int i = 0; i < height; i++)
            {
                string line = Console.ReadLine() ?? throw new ArgumentException();

                if (i == 0)
                {
                    for (int j = 0; j < width; j += 3)
                    {
                        starts.Add(line[j]);
                    }

                    continue;
                }

                if (i == height - 1)
                {
                    for (int j = 0; j < width; j += 3)
                    {
                        targets.Add(line[j]);
                    }
                    
                    continue;
                }

                for (int j = 1; j < width; j += 3)
                {                    
                    graph[i - 1, j / 3] = line[j] == '-';
                }
            }

            for (int i = 0; i < height - 2; i++)
            {
                List<string> bools = new List<string>();

                for (int j = 0; j < width / 3; j++)
                {
                    bools.Add(graph[i, j].ToString());
                }
            }

            for (int i = 0; i < starts.Count; i++)
            {
                int actualWidthPosition = i;

                for (int j = 0; j < height - 2; j++)
                {                    
                    if (actualWidthPosition > 0 && graph[j, actualWidthPosition - 1])
                    {
                        actualWidthPosition--;
                    }
                    else if (actualWidthPosition < starts.Count - 1 && graph[j, actualWidthPosition])
                    {
                        actualWidthPosition++;
                    }
                }

                Console.WriteLine(starts[i].ToString() + targets[actualWidthPosition]);
            }
        }
    }
}

// Write an action using Console.WriteLine()
// To debug: Console.Error.WriteLine("Debug messages...");
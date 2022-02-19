using System;

namespace Solution
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            int W = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            int H = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            int[,] map = new int[H, W];

            for (int i = 0; i < H; i++)
            {
                string[] inputs = (Console.ReadLine() ?? throw new InvalidOperationException()).Split(' ') ;

                for (int j = 0; j < W; j++)
                {
                    map[i, j] = int.Parse(inputs[j]);
                }
            }

            int maxY = H - 1;
            int maxX = W - 1;

            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    if (map[i, j] != 0) continue;

                    //Left up corner
                    if (i == 0 && j == 0)
                    {
                        if (map[i + 1, j] == 1 && map[i, j + 1] == 1 && map[i + 1, j + 1] == 1)
                        {
                            Console.WriteLine(j + " " + i);

                            return;
                        }
                    }

                    //Right up corner
                    else if (i == 0 && j == maxX)
                    {
                        if (map[i + 1, j] == 1 && map[i, j - 1] == 1 && map[i + 1, j - 1] == 1)
                        {
                            Console.WriteLine(j + " " + i);

                            return;
                        }
                    }

                    //Left bottom corner
                    else if (i == maxY && j == 0)
                    {
                        if (map[i - 1, j] == 1 && map[i, j + 1] == 1 && map[i - 1, j + 1] == 1)
                        {
                            Console.WriteLine(j + " " + i);

                            return;
                        }
                    }

                    //Right bottom corner 
                    else if (i == maxY && j == maxX)
                    {
                        if (map[i - 1, j] == 1 && map[i, j - 1] == 1 && map[i - 1, j - 1] == 1)
                        {
                            Console.WriteLine(j + " " + i);

                            return;
                        }
                    }

                    //Top line
                    else if (i == 0)
                    {
                        if (map[i, j - 1] == 1 && map[i + 1, j - 1] == 1 && map[i + 1, j] == 1 && map[i + 1, j + 1] == 1 && map[i, j + 1] == 1)
                        {
                            Console.WriteLine(j + " " + i);

                            return;
                        }
                    }

                    //Bottom line
                    else if (i == maxY)
                    {
                        if (map[i, j - 1] == 1 && map[i - 1, j - 1] == 1 && map[i - 1, j] == 1 && map[i - 1, j + 1] == 1 && map[i, j + 1] == 1)
                        {
                            Console.WriteLine(j + " " + i);

                            return;
                        }
                    }

                    //Left line
                    else if (j == 0)
                    {
                        if (map[i - 1, j] == 1 && map[i - 1, j + 1] == 1 && map[i, j + 1] == 1 && map[i + 1, j + 1] == 1 && map[i + 1, j] == 1)
                        {
                            Console.WriteLine(j + " " + i);

                            return;
                        }
                    }

                    //Right line
                    else if (j == maxX)
                    {
                        if (map[i - 1, j] == 1 && map[i - 1, j - 1] == 1 && map[i, j - 1] == 1 && map[i + 1, j - 1] == 1 && map[i + 1, j] == 1)
                        {
                            Console.WriteLine(j + " " + i);

                            return;
                        }
                    }

                    //Everything else
                    else if
                    (
                        map[i - 1, j] == 1
                        && map[i - 1, j - 1] == 1
                        && map[i, j - 1] == 1
                        && map[i + 1, j - 1] == 1
                        && map[i + 1, j] == 1
                        && map[i + 1, j + 1] == 1
                        && map[i, j + 1] == 1
                        && map[i - 1, j + 1] == 1
                    )
                    {
                        Console.WriteLine(j + " " + i);

                        return;
                    }
                }
            }
        }
    }
}
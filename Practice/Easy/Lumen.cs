using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Solution
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            int L = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            bool[,] grid = new bool[N, N];
            int rangeFromCandle = L - 1;

            for (int i = 0; i < N; i++)
            {
                string line = Console.ReadLine() ?? throw new InvalidOperationException();
                line = Regex.Replace(line, @"\s+", "");

                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] != 'C') continue;

                    for (int a = i - rangeFromCandle; a <= i + rangeFromCandle; a++)
                    {
                        for (int b = j - rangeFromCandle; b <= j + rangeFromCandle; b++)
                        {
                            if (a < 0 || a >= N || b < 0 || b >= N) continue;

                            grid[a, b] = true;
                        }
                    }
                }

            }

            Console.WriteLine(grid.Cast<bool>().Sum(cell => cell ? 0 : 1));
        }
    }
}
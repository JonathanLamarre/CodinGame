using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());
        int numberOfAntiClockwiseRotations = int.Parse(Console.ReadLine()) % 360 / 45;
        string[] bloc = Enumerable.Repeat(0, size).Select(_ => Console.ReadLine().Replace(" ", string.Empty)).ToArray();
        int diamondHeight = 2 * size - 1;
        string[] diamond = new string[diamondHeight];

        for (int i = numberOfAntiClockwiseRotations; i > 0; i--)
        {
            if (i % 2 == 1)
            {
                var indices = new List<(int, int)>() {(0, size - 1)};

                for (int j = 0; j < diamondHeight; j++)
                {
                    diamond[j] = indices.Aggregate(string.Empty, (x, y) => x += bloc[y.Item1][y.Item2]);

                    if (indices.First().Item2 != 0)
                    {
                        indices.Add((indices.Last().Item1 + 1, size));
                    }
                    else
                    {
                        indices.RemoveAt(0);
                    }

                    Enumerable.Range(0, indices.Count).ToList().ForEach(x => indices[x] = (indices[x].Item1, indices[x].Item2 -1));
                }
            }
            else
            {
                for (int j = 0; j < size; j++)
                {
                    bloc[j] = Enumerable
                        .Range(0, size)
                        .Select(x => diamond[j + x][j + x < size ? x : (size - j - 1)])
                        .Aggregate(string.Empty, (x, y) => x += y);
                }
            }
        }
        
        diamond
            .Select(x => string.Join(" ", x.ToCharArray()))
            .Select(x => (new string(' ', (2 * size - x.Length) / 2), x))
            .Select(x => x.Item1 + x.Item2 + x.Item1)
            .ToList()
            .ForEach(x => Console.WriteLine(x));        
    }
}
using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        (int r, int c) = (int.Parse(inputs[0]), int.Parse(inputs[1]));
        int[,] matrix = new int[r, c];

        for (int i = 0; i < r; i++)
        {
            inputs = Console.ReadLine().Split(' ');

            for (int j = 0; j < c; j++)
            {
                matrix[i, j] = int.Parse(inputs[j]);
            }
        }

        inputs = Console.ReadLine().Split(' ');
        (int m, int n) = (int.Parse(inputs[0]), int.Parse(inputs[1]));
        int[,] kernel = new int[m, n];

        for (int i = 0; i < m; i++)
        {
            inputs = Console.ReadLine().Split(' ');

            for (int j = 0; j < n; j++)
            {
                kernel[i, j] = int.Parse(inputs[j]);
            }
        }

        List<List<int>> answer = Enumerable
            .Range(0, r - m + 1)
            .Select(_ =>  Enumerable.Repeat(0, c - n + 1).ToList())
            .ToList();

        for (int i = 0; i < r - m + 1; i++)
        {
            for (int j = 0; j < c - n + 1; j++)
            {
                for (int a = 0; a < m; a++)
                {
                    for (int b = 0; b < n; b++)
                    {
                        answer[i][j] += matrix[i + a, j + b] * kernel[a, b];
                    }
                }
            }
        }
        
        answer.ForEach(x => Console.WriteLine(string.Join(" ", x.Select(y => y.ToString()))));
    }
};
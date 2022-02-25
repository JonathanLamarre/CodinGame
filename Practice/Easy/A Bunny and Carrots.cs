using System;
using System.Linq;

public class Solution
{
    public static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        (int M, int N) = (int.Parse(inputs[0]), int.Parse(inputs[1]));
        bool[,] garden = new bool[M,N];
        _ = Console.ReadLine();
        inputs = Console.ReadLine().Split(' ');
        int fences = 2 * (M + N);

        foreach(string input in inputs)
        {
            int column = int.Parse(input) - 1;
            int line = Enumerable.Range(0, M).Reverse().First(x => !garden[x, column]);
            garden[line, column] = true;

            fences = fences
                + (line - 1 < 0 || garden[line - 1, column] ? -1 : 1)
                + (line + 1 == M || garden[line + 1, column] ? -1 : 1)
                + (column - 1 < 0 || garden[line, column - 1] ? -1 : 1)
                + (column + 1 == N || garden[line, column + 1] ? -1 : 1);
            
            Console.WriteLine(fences);
        }
    }
}
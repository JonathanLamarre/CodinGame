using System;
using System.Linq;

public class Solution
{
    public static void Main(string[] args)
    {
        int[][] lines = Enumerable
            .Range(0, int.Parse(Console.ReadLine()))
            .Select(_ => Console.ReadLine().Split(" ").Select(int.Parse).ToArray())
            .ToArray();

        if (lines.Select(x => x.Sum()).GroupBy(x => x).Count() != 1)
        {
            Console.WriteLine("INVALID");

            return;
        }

        foreach (int[] line in lines)
        {
            char c = '.';

            foreach(int i in line)
            {
                Console.Write(new string(c, i));
                c = c == 'O' ? '.' : 'O';
            }

            Console.Write(Environment.NewLine);
        }
    }
}
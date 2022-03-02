using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        (long min, long max) = (long.Parse(inputs[0]), long.Parse(inputs[1]));
        inputs = Console.ReadLine().Split(' ');
        (long o1, long o2) = (long.Parse(inputs[0]), long.Parse(inputs[1]));
        long volume = o1 * o1 * o1 + o2 * o2 * o2;
        max = Math.Min(max, (long)Math.Pow(volume, 1d / 3));
        var funSolutions = new List<(long o1, long o2)>();
        bool hasValidSolution = false;

        for (long i = min; i <= max && i <= max; i++)
        {
            for (long j = max; j >= i; j--)
            {
                if (i * i * i + j * j * j != volume) continue;

                if (i == o1 && j == o2)
                {
                    hasValidSolution = true;
                }
                else
                {
                    funSolutions.Add((i, j));
                }
                
            }
        }

        if (funSolutions.Count == 0)
        {
            Console.WriteLine(hasValidSolution ? "VALID" : "NONE");
        }
        else
        {
            funSolutions = funSolutions.OrderByDescending(x => x.o2 * x.o2 - x.o1 * x.o1).ToList();
            Console.WriteLine($"{funSolutions.First().o1} {funSolutions.First().o2}");
        }
    }
}
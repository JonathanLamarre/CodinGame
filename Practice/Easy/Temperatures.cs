using System;
using System.Linq;

public class Solution
{
    public static void Main(string[] args)
    {
        Console.ReadLine();
        string line = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(line))
        {
            Console.WriteLine(0);
        }
        else
        {
            int result = line
                .Split(' ')
                .Select(x => int.Parse(x))
                .Aggregate(int.MaxValue, (x, y) => Math.Abs(y) < Math.Abs(x) ? y : Math.Abs(y) == Math.Abs(x) && y > x ? y : x);

            Console.WriteLine(result);
        }
    }
}
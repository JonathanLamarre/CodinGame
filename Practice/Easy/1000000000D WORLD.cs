using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        //Reversed lists to remove elements from end in O(1) instead of the beginning, which is O(n)
        List<long> a = Console.ReadLine().Split(" ").Select(long.Parse).Reverse().ToList();
        List<long> b = Console.ReadLine().Split(" ").Select(long.Parse).Reverse().ToList();
        long dotProduct = 0;

        while(a.Count > 0)
        {
            long elementsToCalculate = Math.Min(a[^1], b[^1]);
            dotProduct += a[^2] * b[^2] * elementsToCalculate;
            a[^1] -= elementsToCalculate;
            b[^1] -= elementsToCalculate;
            
            if (a[^1] == 0)
            {
                a.RemoveRange(a.Count - 2, 2);
            }

            if (b[^1] == 0)
            {
                b.RemoveRange(b.Count - 2, 2);
            }
        }

        Console.WriteLine(dotProduct);
    }
}
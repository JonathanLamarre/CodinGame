using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int X = int.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());
        List<int> weights = Console.ReadLine().Split(' ').Select(int.Parse).OrderByDescending(x => x).ToList();
        Console.WriteLine(Enumerable.Range(0, (N / X) + (N % X == 0 ? 0 : 1)).Select(x => x * 0.65m * weights.Skip(x * X).Take(X).Sum()).Sum().ToString("0.000"));
    }
}
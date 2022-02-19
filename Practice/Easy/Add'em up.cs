using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        List<int> healths = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        int cost = 0;

        while(healths.Count > 1)
        {
            healths.Sort((x, y) => y.CompareTo(x));
            int newHealth = healths[healths.Count - 1] + healths[healths.Count - 2];
            cost += newHealth;
            healths.RemoveAt(healths.Count - 1);
            healths.RemoveAt(healths.Count - 1);
            healths.Add(newHealth);
        }

        Console.WriteLine(cost);
    }
}
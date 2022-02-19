using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int numberOfRows = int.Parse(Console.ReadLine());
        var encoding = new Dictionary<char, string>();

        for (int i = 0; i < numberOfRows; i++)
        {
            string[] symbols = Console.ReadLine().Split(" ");

            for (int j = 0; j < symbols.Count(); j++)
            {
                encoding.Add(symbols[j][0], i.ToString() + j.ToString());
            }
        }

        Console.WriteLine(Console.ReadLine().Aggregate(string.Empty, (x, y) => x += encoding[y]));
    }
}
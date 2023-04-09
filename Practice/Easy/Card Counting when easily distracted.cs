using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    private static void Main(string[] args)
    {
        Dictionary<char, (int Value, int Count)> cardToValueAndCount = new()
        {
            {'A', (1, 4)}, {'2', (2, 4)}, {'3', (3, 4)}, {'4', (4, 4)}, {'5', (5, 4)}, {'6', (6, 4)}, {'7', (7, 4)},
            {'8', (8, 4)}, {'9', (9, 4)}, {'T', (10, 4)}, {'J', (10, 4)}, {'Q', (10, 4)}, {'K', (10, 4)}
        };

        Console
            .ReadLine()
            .Split(".")
            .Where(x => x.All(y => cardToValueAndCount.ContainsKey(y)))
            .SelectMany(x => x.Select(y => y))
            .ToList()
            .ForEach(x => cardToValueAndCount[x] = (cardToValueAndCount[x].Value, cardToValueAndCount[x].Count - 1));

        int bustThreshold = int.Parse(Console.ReadLine());
        int numberOfCardsBelowThreshold = cardToValueAndCount.Where(x => x.Value.Value < bustThreshold).Sum(x => x.Value.Count);
        int numberOfCardsLeft = cardToValueAndCount.Sum(x => x.Value.Count);
        int percentageChance = (int)Math.Round((decimal)numberOfCardsBelowThreshold / (decimal)numberOfCardsLeft * 100);
        Console.WriteLine($"{percentageChance}%");
    }
}
using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        string sequence = Console.ReadLine();
        double depth = 0;
        var weights = new Dictionary<char, double>();

        for(int i = 0; i < sequence.Length; i++)
        {
            if (sequence[i] == '-')
            {
                weights[sequence[++i]] = (weights.ContainsKey(sequence[i]) ? weights[sequence[i]] : 0) + (1 / depth--);
            }
            else
            {
                depth++;
            }
        }

        Console.WriteLine(weights.Aggregate((x, y) => x.Value > y.Value ? x : y).Key);
    }
}
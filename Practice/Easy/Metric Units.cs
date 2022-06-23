using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class Solution
{
    private static Dictionary<string, uint> s_unitToUms = new Dictionary<string, uint>()
    {
        {"um", 1},
        {"mm", 1000},
        {"cm", 10000},
        {"dm", 100000},
        {"m", 1000000},
        {"km", 1000000000}
    };

    public static void Main(string[] args)
    {
        Match match = Regex.Match( Console.ReadLine(), @"((?:[0-9]+[.])?[0-9]+)(\w+) \+ ((?:[0-9]+[.])?[0-9]+)(\w+)");
        decimal unit1Quantity = decimal.Parse(match.Groups[1].ToString());
        string unit1 = match.Groups[2].ToString();
        decimal unit2Quantity = decimal.Parse(match.Groups[3].ToString());
        string unit2 = match.Groups[4].ToString();
        string smallestUnit = s_unitToUms[unit1] < s_unitToUms[unit2] ? unit1 : unit2;
        decimal resultQuantity = (s_unitToUms[unit1] * unit1Quantity + s_unitToUms[unit2] * unit2Quantity) / s_unitToUms[smallestUnit];
        Console.WriteLine($"{resultQuantity.ToString("0.#############################")}{smallestUnit}");        
    }
}
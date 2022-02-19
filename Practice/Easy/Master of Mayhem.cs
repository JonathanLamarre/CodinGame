using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Solution
{
    private static readonly Regex regex = new Regex("(\\S+)'s (\\S+) is (?:a )?\"?([^\"]+)");

    private static (string, string, string) GetReport(string input)
    {
        Match match = regex.Match(input);

        return (match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value);
    }

    public static void Main(string[] args)
    {
        HashSet<string> possiblesMayhem = Enumerable
            .Range(0, int.Parse(Console.ReadLine()))
            .Select(_ => Console.ReadLine())
            .ToHashSet();

        Dictionary<string, string> mayhemReports = Enumerable
            .Range(0, int.Parse(Console.ReadLine()))
            .Select(_ => Console.ReadLine())
            .Select(GetReport)
            .Select(x => x.Item2 == "word" ? (x.Item1, "catchphrase", x.Item3) : x)
            .ToDictionary(x => x.Item2, x => x.Item3);

        IEnumerable<(string, string, string)> cyborgReports = Enumerable
            .Range(0, int.Parse(Console.ReadLine()))
            .Select(_ => Console.ReadLine())
            .Select(GetReport)
            .Where(x => mayhemReports.ContainsKey(x.Item2));

        foreach((string cyborg, string condition, string value) in cyborgReports)
        {
            if
            (
                possiblesMayhem.Contains(cyborg)
                && mayhemReports.ContainsKey(condition)
                && !value.Contains(mayhemReports[condition])
            )
            {
                possiblesMayhem.Remove(cyborg);
            }
        }

        string result = possiblesMayhem.Count == 1
            ? possiblesMayhem.Single()
            : (possiblesMayhem.Count == 0 ? "MISSING" : "INDETERMINATE");

        Console.WriteLine(result);
    }
}
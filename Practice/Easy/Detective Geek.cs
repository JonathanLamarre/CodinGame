using System;
using System.Linq;
using System.Collections.Generic;

public static class Solution
{
    private static readonly Dictionary<string, int> s_monthToIndex = new Dictionary<string, int>()
    {
        {"jan", 0},
        {"feb", 1},
        {"mar", 2},
        {"apr", 3},
        {"may", 4},
        {"jun", 5},
        {"jul", 6},
        {"aug", 7},
        {"sep", 8},
        {"oct", 9},
        {"nov", 10},
        {"dec", 11}
    };

    public static void Main(string[] args)
    {
        string time = Convert
            .ToInt32(Console.ReadLine().Replace('#', '1').Replace('*', '0'), 2)
            .ToString("0000");

        Console.WriteLine(time.Insert(time.Length - 2, ":"));

        List<string> SplitBy3(string s)
        {
            var result = new List<string>();

            for (int start = 0; start < s.Length; start += 3)
            {
                result.Add(s.Substring(start, 3));
            }

            return result;
        }

        char ConvertToLetter(List<string> months)
        {
            int base10Number = 0;
            int base12Multiplier = 1;

            for (int i = months.Count - 1; i >= 0; i--)
            {
                base10Number += s_monthToIndex[months[i]] * base12Multiplier;
                base12Multiplier *= 12;
            }

            return (char)base10Number;
        }

        char[] address = Console
            .ReadLine()
            .Split(" ")
            .Select(SplitBy3)
            .Select(ConvertToLetter)
            .ToArray();

        Console.WriteLine(new string(address));
    }
}
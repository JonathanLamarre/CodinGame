using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    private static readonly Dictionary<string, string> asciiArtToNumber = new Dictionary<string, string>
    {
        {" _ | ||_|", "0"},
        {"     |  |", "1"},
        {" _  _||_ ", "2"},
        {" _  _| _|", "3"},
        {"   |_|  |", "4"},
        {" _ |_  _|", "5"},
        {" _ |_ |_|", "6"},
        {" _   |  |", "7"},
        {" _ |_||_|", "8"},
        {" _ |_| _|", "9"}
    };

    public static void Main(string[] args)
    {
        List<string> line1 = SplitBy3(Console.ReadLine()).ToList();
        List<string> line2 = SplitBy3(Console.ReadLine()).ToList();
        List<string> line3 = SplitBy3(Console.ReadLine()).ToList();
        List<string> asciiArts = line1.Zip(line2.Zip(line3, (x, y) => x + y), (x, y) => x + y).ToList();
        List<string> numbers = asciiArts.Select(x => asciiArtToNumber[x]).ToList();
        Console.WriteLine(string.Join(string.Empty, numbers));
    }

    public static IEnumerable<string> SplitBy3(string stringToSplit)
    {
        for (int index = 0; index < stringToSplit.Length; index += 3)
        {
            yield return stringToSplit.Substring(index, 3);
        }
    }
}
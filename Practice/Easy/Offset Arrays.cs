using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int numberOfArrays = int.Parse(Console.ReadLine());
        var idToStartIndexAndElements = new Dictionary<string, (int, List<int>)>();

        for (int i = 0; i < numberOfArrays; i++)
        {
            string line = Console.ReadLine();
            string[] input = line.Split(new[] { '[' }, 2);
            string id = input[0];
            input = input[1].Split("..", 2);
            int startIndex = int.Parse(input[0]);
            input = input[1].Split("=", 2);
            List<int> elements = input[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            idToStartIndexAndElements.Add(id, (startIndex, elements));
        }

        string[] parsedString = Console.ReadLine().Split(new[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
        int index = int.Parse(parsedString.Last());

        for (int i = parsedString.Length - 2; i >= 0; i--)
        {
            (int startIndex, List<int> elements) = idToStartIndexAndElements[parsedString[i]];
            index = elements[index - startIndex];
        }

        Console.WriteLine(index);
    }
}
using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        List<string> words = Enumerable
            .Range(0, int.Parse(Console.ReadLine()))
            .Select(_ => Console.ReadLine())
            .ToList();

        foreach (string word in words)
        {
            string prefix = string.Empty;

            foreach (char c in word)
            {
                prefix += c;

                if (words.Where(x => x != word).All(x => !x.StartsWith(prefix))) break;
            }

            Console.WriteLine(prefix);
        }
    }
}
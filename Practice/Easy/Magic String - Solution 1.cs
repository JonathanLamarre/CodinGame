using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Solution
{
    public static void Main(string[] args)
    {
        int numberOfNames = int.Parse(Console.ReadLine());
        List<string> names = Enumerable.Repeat(0, numberOfNames).Select(_ => Console.ReadLine()).OrderBy(x => x).ToList();
        string name1 = names[numberOfNames / 2 - 1];
        string name2 = names[numberOfNames / 2];
        string possibleMagicString = ((char)(name1[0])).ToString();

        while (name1.CompareTo(possibleMagicString) == 1)
        {
            possibleMagicString = Regex.Match(name2, $"^{possibleMagicString}").Success
                ? possibleMagicString + "A"
                : $"{possibleMagicString.Remove(possibleMagicString.Length - 1)}{(char)(possibleMagicString[possibleMagicString.Length - 1] + 1)}";
        }

        Console.WriteLine(name2.CompareTo(possibleMagicString) == 1 ? possibleMagicString : name1);
    }
}
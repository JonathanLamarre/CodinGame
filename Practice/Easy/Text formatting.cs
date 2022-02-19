using System;
using System.Text.RegularExpressions;

public class Solution
{
    public static void Main(string[] args)
    {
        string text = Console.ReadLine().ToLower();
        text = Regex.Replace(text, " {2,}", " ");
        text = Regex.Replace(text, " ([^a-zA-Z0-9 ])", x => x.Groups[1].Value);
        text = Regex.Replace(text, "([^a-zA-Z0-9 ])([a-zA-Z])", x => x.Groups[1].Value + " " + x.Groups[2].Value);
        text = Regex.Replace(text, "(?:^|(\\. ))([a-z])", x => x.Groups[1].Value + x.Groups[2].Value.ToUpper());
        text = Regex.Replace(text, "([^a-zA-Z0-9 ])\\1+", x => x.Groups[1].Value);
        Console.WriteLine(text);
    }
}
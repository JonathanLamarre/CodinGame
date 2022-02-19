using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Solution
{
    public static void Main(string[] args)
    {
        IEnumerable<string> disjoinedEmail = Enumerable.Range(0, int.Parse(Console.ReadLine())).Select(_ => Console.ReadLine());
        string email = string.Join(Environment.NewLine, disjoinedEmail);
        var regex = new Regex("\\(([^\\)]*)\\)", RegexOptions.Singleline);
        string expandedEmail = email;
        MatchCollection matches = regex.Matches(email);
        
        for (int i = 0; i < matches.Count; i++)
        {
            string textToExpand = matches[i].Groups[1].Value;
            string[] choices = textToExpand.Split("|");
            string choice = choices[i % choices.Count()];
            int indexOfMatchInExpandedEmail = expandedEmail.IndexOf(matches[i].Value);

            expandedEmail = expandedEmail.Substring(0, indexOfMatchInExpandedEmail)
                + choice
                + expandedEmail[(indexOfMatchInExpandedEmail + matches[i].Value.Length)..];
        }

        Console.Write(expandedEmail);
    }
}
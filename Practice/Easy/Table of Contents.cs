using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    private static void Main(string[] args)
    {
        int lengthOfLine = int.Parse(Console.ReadLine());
        IEnumerable<string[]> entries = Enumerable.Repeat(0, int.Parse(Console.ReadLine())).Select(_ => Console.ReadLine().Split(' '));
        int actualIndentationLevel = -1;
        Stack<int> numbering = new();

        foreach(string[] entry in entries)
        {
            int indentationLevel = entry[0].Select((x, i) => (x, i)).Where(x => x.x != '>').Select(x => x.i).First();

            if (indentationLevel > actualIndentationLevel)
            {
                actualIndentationLevel++;
                numbering.Push(1);
            }
            else if (indentationLevel < actualIndentationLevel)
            {
                int indentationDifference = actualIndentationLevel - indentationLevel;
                actualIndentationLevel -= indentationDifference;
                Enumerable.Repeat(0, indentationDifference).ToList().ForEach(_ => numbering.Pop());
                numbering.Push(numbering.Pop() + 1);
            }
            else
            {
                numbering.Push(numbering.Pop() + 1);
            }

            string spaces = new string(' ', 4 * indentationLevel);
            string numberingString = numbering.Peek().ToString();
            string title = entry[0].Substring(indentationLevel);
            string dots = new string('.', lengthOfLine - spaces.Length - numberingString.Length - title.Length - entry[1].Length - 1);
            Console.WriteLine($"{spaces}{numberingString} {title}{dots}{entry[1]}");
        }
    }
}
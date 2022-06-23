using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    static void Main(string[] args)
    {
        string typedKeys = Console.ReadLine();
        (Stack<char> leftOfCursor, Stack<char> rightOfCursor) = (new Stack<char>(), new Stack<char>());

        foreach (char c in typedKeys)
        {
            if (c == '-')
            {
                if (leftOfCursor.Count == 0) continue;

                leftOfCursor.Pop();
            }
            else if (c == '<')
            {
                if (leftOfCursor.Count == 0) continue;

                rightOfCursor.Push(leftOfCursor.Pop());
            }
            else if (c == '>')
            {
                if (rightOfCursor.Count == 0) continue;

                leftOfCursor.Push(rightOfCursor.Pop());
            }
            else
            {
                leftOfCursor.Push(c);
            }
        }
        
        Console.WriteLine(new string(leftOfCursor.ToArray().Reverse().ToArray()) + new string(rightOfCursor.ToArray()));
    }
}
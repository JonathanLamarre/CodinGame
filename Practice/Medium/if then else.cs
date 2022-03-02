using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int numberOfLines = int.Parse(Console.ReadLine());
        var paths = new Stack<long>();
        paths.Push(1);

        for (int i = 0; i < numberOfLines; i++)
        {
            string line = Console.ReadLine();

            if (line == "if" || line == "else")
            {
                paths.Push(1);
            }
            else if (line == "endif")
            {
                paths.Push((paths.Pop() + paths.Pop()) * paths.Pop());
            }
        }

        Console.WriteLine(paths.Pop());
    }
}
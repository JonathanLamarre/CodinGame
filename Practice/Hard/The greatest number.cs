using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        Console.ReadLine();
        List<string> inputs = Console.ReadLine().Split(' ').ToList();
        inputs.Sort();

        if (!inputs.Contains("-"))
        {
            inputs.Reverse();
        }

        if (inputs.Contains("."))
        {
            inputs.Remove(".");
            inputs.Insert(inputs.Contains("-") ? 2 : inputs.Count - 1, ".");
        }

        Console.WriteLine(double.Parse(String.Join(null, inputs)));
    }
}
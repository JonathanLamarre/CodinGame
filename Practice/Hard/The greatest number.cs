using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    private static void Main(string[] args)
    {
        Console.ReadLine();
        List<string> inputs = Console.ReadLine().Split(' ').ToList();
        inputs.Sort();

        if (!inputs.Contains("-"))
        {
            inputs.Reverse();
        }

        if (inputs.Remove("."))
        {
            inputs.Insert(inputs.Contains("-") ? 2 : inputs.Count - 1, ".");
        }

        double result = double.Parse(String.Join(null, inputs));

        //Cover the case -0
        result = result == 0 ? 0 : result;
        Console.WriteLine(result);
    }
}
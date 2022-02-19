using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int numberOfTestCases = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfTestCases; i++)
        {
            var stacks = new List<char>();

            foreach(char c in Console.ReadLine())
            {
                int indexOfOptimalStack = -1;
                int distance = int.MaxValue;

                for (int j = 0; j < stacks.Count; j++)
                {
                    if (c <= stacks[j] && stacks[j] - c < distance)
                    {
                        indexOfOptimalStack = j;
                        distance = stacks[j] - c;
                    }
                }

                if (indexOfOptimalStack == -1)
                {
                    stacks.Add(c);
                }
                else
                {
                    stacks[indexOfOptimalStack] = c;
                }
            }

            Console.WriteLine(stacks.Count);
        }
    }
}
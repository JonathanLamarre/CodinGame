using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var greaterToSmallers = new Dictionary<string, List<string>>();

        bool CheckForLoop(string flagForLoop, string valueToCheck)
        {
            if (valueToCheck == flagForLoop) return true;

            if (!greaterToSmallers.TryGetValue(valueToCheck, out List<string> smallers)) return false;

            foreach(string smaller in smallers)
            {
                if (CheckForLoop(flagForLoop, smaller)) return true;
            }

            return false;
        }

        for (int i = 0; i < n; i++)
        {
            string[] inputs = Console.ReadLine().Split(" ");

            if (!greaterToSmallers.TryGetValue(inputs[0], out List<string> smallers))
            {
                greaterToSmallers[inputs[0]] = smallers = new List<string>();
            }

            smallers.Add(inputs[2]);
            string originalGreater = inputs[0];
            string greater = inputs[2];

            if (CheckForLoop(inputs[0], inputs[2]))
            {
                Console.WriteLine("contradiction");

                return;
            }
        }

        Console.WriteLine("consistent");
    }
}
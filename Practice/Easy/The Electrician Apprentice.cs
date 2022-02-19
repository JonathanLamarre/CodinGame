using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int numberOfCircuits = int.Parse(Console.ReadLine());
        var circuitAndParallelsAndSerials = new List<(string, HashSet<string>, HashSet<string>)>();
        var allParallels = new HashSet<string>();
        var allSerials = new HashSet<string>();

        for (int i = 0; i < numberOfCircuits; i++)
        {
            string[] inputs = Console.ReadLine().Split(" ");
            string circuit = inputs[0];
            HashSet<string> parallels = new HashSet<string>();
            HashSet<string> serials = new HashSet<string>();
            string readingMode = string.Empty;

            for (int j = 1; j < inputs.Length; j++)
            {
                if (inputs[j] == "=" || inputs[j] == "-")
                {
                    readingMode = inputs[j];
                }
                else if (readingMode == "=")
                {
                    parallels.Add(inputs[j]);
                }
                else if (readingMode == "-")
                {
                    serials.Add(inputs[j]);
                }
            }

            allParallels.UnionWith(parallels);
            allSerials.UnionWith(serials);
            circuitAndParallelsAndSerials.Add((inputs[0], parallels, serials));
        }

        var onlineParallels = new HashSet<string>();
        var onlineSerials = new HashSet<string>();
        int numberOfFlipSwitch = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfFlipSwitch; i++)
        {
            string switchFlipped = Console.ReadLine();

            if (allParallels.Contains(switchFlipped) )
            {
                if (onlineParallels.Contains(switchFlipped))
                {
                    onlineParallels.Remove(switchFlipped);
                }
                else
                {
                    onlineParallels.Add(switchFlipped);
                }
            }

            if (allSerials.Contains(switchFlipped))
            {
                if (onlineSerials.Contains(switchFlipped))
                {
                    onlineSerials.Remove(switchFlipped);
                }
                else
                {
                    onlineSerials.Add(switchFlipped);
                }
            }
        }

        foreach((string, HashSet<string>, HashSet<string>) tuple in circuitAndParallelsAndSerials)
        {
            (string circuit, HashSet<string> parallels, HashSet<string> serials) = tuple;

            string state = (parallels.Count == 0 || onlineParallels.Overlaps(parallels)) && (serials.Count == 0 || serials.IsSubsetOf(onlineSerials))
                ? "ON"
                : "OFF";

            Console.WriteLine(circuit + " is " + state);
        }
    }
}
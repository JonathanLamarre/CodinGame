using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int numberOfRods = int.Parse(Console.ReadLine());

        Dictionary<int, HashSet<int>> padToConnections = Enumerable
            .Range(0, numberOfRods + 1)
            .ToDictionary(x => x, x => new HashSet<int>());

        for (int i = 0; i < numberOfRods; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int pad1 = int.Parse(inputs[0]);
            int pad2 = int.Parse(inputs[1]);
            padToConnections[pad1].Add(pad2);
            padToConnections[pad2].Add(pad1);
        }

        int numberOfNightsToContamination = 0;
        HashSet<int> leafPads = padToConnections.Where(x => x.Value.Count == 1).Select(x => x.Key).ToHashSet();

        while(padToConnections.Count > 2)
        {
            numberOfNightsToContamination++;
            var possibleLeafPads = new HashSet<int>();
            Console.Error.WriteLine("Count:" + padToConnections.Count);

            foreach(int pad in leafPads)
            {
                int parentPad = padToConnections[pad].First();
                padToConnections.Remove(pad);
                padToConnections[parentPad].Remove(pad);
                possibleLeafPads.Add(parentPad);
            }

            leafPads = possibleLeafPads.Where(x => padToConnections[x].Count == 1).ToHashSet();
        }

        if (padToConnections.Count == 2)
        {
            numberOfNightsToContamination++;
        }

        Console.WriteLine(numberOfNightsToContamination);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Solution
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            int capacity = int.Parse((Console.ReadLine()?.Split(' ') ?? throw new InvalidOperationException())[2]);
            List<int> deviceConsumptions = (Console.ReadLine()?.Split(' ') ?? throw new InvalidOperationException()).Select(int.Parse).ToList();
            List<bool> deviceStates = Enumerable.Repeat(false, deviceConsumptions.Count).ToList();
            int actualConsommation = 0;
            int maxConsommation = 0;

            foreach (int i in (Console.ReadLine()?.Split(' ') ?? throw new InvalidOperationException()).Select(int.Parse).Select(x => x - 1))
            {
                actualConsommation += (deviceStates[i] = !deviceStates[i]) ? deviceConsumptions[i] : -deviceConsumptions[i];

                if (actualConsommation > capacity)
                {
                    Console.WriteLine("Fuse was blown.");

                    return;
                }

                maxConsommation = actualConsommation > maxConsommation ? actualConsommation : maxConsommation;
            }

            Console.WriteLine("Fuse was not blown.");
            Console.WriteLine("Maximal consumed current was " + maxConsommation + " A.");
        }
    }
}
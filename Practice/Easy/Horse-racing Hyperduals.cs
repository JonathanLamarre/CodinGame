using System;
using System.Collections.Generic;

namespace Solution
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            List<int> velocities = new List<int>();
            List<int> elegances = new List<int>();
            int minDistance = int.MaxValue;

            for (int i = 0; i < N; i++)
            {
                string[] inputs = Console.ReadLine()?.Split(' ') ?? throw new InvalidOperationException();
                velocities.Add(int.Parse(inputs[0]));
                elegances.Add(int.Parse(inputs[1]));

                for (int j = 0; j < i; j++)
                {
                    int distance = Math.Abs(velocities[i] - velocities[j]) + Math.Abs(elegances[i] - elegances[j]);

                    if (distance < minDistance)
                    {
                        minDistance = distance;
                    }
                }
            }

            Console.WriteLine(minDistance);
        }
    }
}
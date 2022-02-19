using System;
using System.Collections.Generic;
using System.Linq;

namespace Solution
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            int numberOfRobbers = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            int numberOfVaults = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            List<long> timeByVault = new List<long>();
            long totalTime = 0;

            for (int i = 0; i < numberOfVaults; i++)
            {
                string[] inputs = Console.ReadLine()?.Split(' ') ?? throw new InvalidOperationException();
                int C = int.Parse(inputs[0]);
                int N = int.Parse(inputs[1]);
                timeByVault.Add(Power(10, N) * Power(5, C - N));
            }

            do
            {
                List<long> workedVault = timeByVault.Take(numberOfRobbers).ToList();
                long smallestTimeForAVault = workedVault.Min();
                totalTime += smallestTimeForAVault;

                for (int i = 0; i < workedVault.Count; i++)
                {
                    timeByVault[i] = timeByVault[i] - smallestTimeForAVault;
                }

                timeByVault = timeByVault.Where(x => x != 0).ToList();
            } while (timeByVault.Count > 0);
            
            Console.WriteLine(totalTime);
        }

        private static long Power(long x, long pow)
        {
            long result = 1;

            while (pow != 0)
            {
                if ((pow & 1) == 1)
                {
                    result *= x;
                }

                x *= x;
                pow >>= 1;
            }

            return result;
        }
    }
}
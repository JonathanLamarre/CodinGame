using System;
using System.Collections.Generic;
using System.Linq;

namespace Solution
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            long r1 = long.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            long r2 = long.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            HashSet<long> results = new HashSet<long> { r1, r2 };

            do
            {
                long result;

                if (r1 < r2)
                {
                    result = r1 = Next(r1);
                }
                else
                {
                    result = r2 = Next(r2);
                }

                if (results.Contains(result))
                {
                    Console.WriteLine(result);

                    break;
                }

                results.Add(result);
            } while (true);
        }

        public static long Next(long r)
        {
            return r + r.ToString().Aggregate(0, (x, y) => x - '0' + y);
        }
    }
}
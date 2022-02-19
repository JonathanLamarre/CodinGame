using System;
using System.Linq;

namespace Solution
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            long r1 = long.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            long smallestDifference = 9;

            for (long i = r1 / 10; i > 0; i /= 10)
            {
                smallestDifference += 9;
            }

            for (long i = Math.Max(1, r1 - smallestDifference); i < r1; i++)
            {
                long rp = i;

                do
                {
                    rp = Next(rp);

                    if (rp != r1) continue;

                    Console.WriteLine("YES");

                    return;
                } while (rp < r1);
            }

            Console.WriteLine("NO");
        }

        public static long Next(long r)
        {
            return r + r.ToString().Aggregate(0, (x, y) => x - '0' + y);
        }
    }
}
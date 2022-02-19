using System;

public class Solution
{
    public static void Main(string[] args)
    {
        long n = long.Parse(Console.ReadLine());
        long nSquared = n * n;

        for (long i = 1; i <= n; i++)
        {
            if (nSquared % i == 0)
            {
                long x = n + (nSquared / i);
                long y = n + (nSquared / (nSquared / i));
                Console.WriteLine("1/" + n + " = 1/" + x + " + 1/" + y);
            }
        }
    }
}
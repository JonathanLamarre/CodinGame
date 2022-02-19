using System;
using System.Text.RegularExpressions;
using System.Numerics;

public class Solution
{
    public static void Main(string[] args)
    {
        MatchCollection matches = Regex.Matches(Console.ReadLine(), "(-?\\d+(:?\\.\\d+)?)");
        var c = new Complex(double.Parse(matches[0].Value), double.Parse(matches[1].Value));
        int m = int.Parse(Console.ReadLine());
        Complex f = 0;
 
        for (int i = 1; i <= m; i++)
        {
            f = f * f + c;

            if (f.Magnitude > 2)
            {
                Console.WriteLine(i);

                return;
            }
        }

        Console.WriteLine(m);
    }
}
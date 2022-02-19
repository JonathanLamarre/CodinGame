using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    private static readonly List<double> s_acceptableMinimum = new List<double>{0.201, 0.076, 0.025, 0, 0, 0, 0, 0, 0};
    private static readonly List<double> s_acceptableMaximum = new List<double>{0.401, 0.276, 0.225, 0.197, 0.179, 0.167, 0.158, 0.151, 0.146};

    public static void Main(string[] args)
    {
        int numberOfTransactions = int.Parse(Console.ReadLine());
        int[] frequencies = new int[9];

        for (int i = 0; i < numberOfTransactions; i++)
        {
            frequencies[Console.ReadLine().First(c => c >= '1' && c <= '9') - '1']++;
        }

        for (int i = 0; i < 9; i++)
        {
            double frequency = (double)frequencies[i] / numberOfTransactions;
            
            if (frequency < s_acceptableMinimum[i] || frequency > s_acceptableMaximum[i])
            {
                Console.WriteLine("true");

                return;
            }
        }

        Console.WriteLine("false");
    }
}
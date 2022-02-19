using System;
using System.Linq;

public class Solution
{
    public static void Main(string[] args)
    {
        Enumerable
            .Range(0, int.Parse(Console.ReadLine()))
            .Select(_ => long.Parse(Console.ReadLine()))
            .ToList()
            .ForEach(x => Console.WriteLine(IsWinning(x) ? "VICTORY" :  "DEFEAT"));
    }

    private static bool IsWinning(long number)
    {
        while(number != 1)
        {
            if (number % 2 == 0) number/= 2;
            else if (number % 3 == 0) number/= 3;
            else if (number % 5 == 0) number/= 5;
            else return false;
        }

        return true;
    }
}
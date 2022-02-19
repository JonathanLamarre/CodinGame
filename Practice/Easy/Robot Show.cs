using System;
using System.Linq;

public class Solution
{
    public static void Main(string[] args)
    {
        int lenghtOfDuct = int.Parse(Console.ReadLine());
        Console.ReadLine();
        int smallestPosition = int.MaxValue;
        int greatestPosition = int.MinValue;

        foreach(int value in Console.ReadLine().Split(' ').Select(x => int.Parse(x)))
        {
            if (value < smallestPosition)
            {
                smallestPosition = value;
            }

            if (value > greatestPosition)
            {
                greatestPosition = value;
            }
        }

        int maxTimeFromSmallest = lenghtOfDuct - smallestPosition;
        Console.WriteLine(maxTimeFromSmallest > greatestPosition ? maxTimeFromSmallest : greatestPosition);
    }
}
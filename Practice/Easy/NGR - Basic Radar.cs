using System;
using System.Linq;

public class Solution
{
    public static void Main(string[] args)
    {
        Enumerable
            .Range(0, int.Parse(Console.ReadLine()))
            .Select(_ => Console.ReadLine().Split(" "))
            .Select(x => (Plate: x[0], TimeStamp: long.Parse(x[2])))
            .GroupBy(x => x.Plate)
            .Select(x => x.OrderBy(y => y.TimeStamp).ToList())
            .Select(x => (x[0].Plate, Speed: 46800000d / (x[1].TimeStamp - x[0].TimeStamp)))
            .Where(x => x.Speed > 130)
            .OrderBy(x => x.Plate)
            .ThenBy(x => x.Speed)
            .ToList()
            .ForEach(x => Console.WriteLine($"{x.Plate} {(int)x.Speed}"));
    }
}
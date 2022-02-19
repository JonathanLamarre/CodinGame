using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;

public class Solution
{
    public static void Main(string[] args)
    {
        List<List<double>> measurements = Enumerable
            .Range(0, int.Parse(Console.ReadLine()))
            .Select(_ => Console.ReadLine().Split(" ").Select(double.Parse).ToList())
            .ToList();

        double N60Average = measurements
            .Select(x => x.Sum())
            .Select(N60 => 10 + (N60 -40) / 7)
            .Average();

        Console.WriteLine(Math.Round(N60Average, 1).ToString("0.0"));

        if (N60Average >= 5 && N60Average < 30)
        {
            double N8Average = measurements
                .SelectMany(x => x)
                .Aggregate((ImmutableList<double>.Empty, 0.0, 0), Aggregate, x => x.Item1.Average());

            Console.WriteLine(Math.Round(N8Average, 1).ToString("0.0"));
        }
    }

    private static (ImmutableList<double> results, double previousMeasurement, int index) Aggregate
    (
        (ImmutableList<double> results, double previousMeasurement, int index) tuple,
        double measurement
    )
    {
        (ImmutableList<double> results, double previousMeasurement, int index) = tuple;

        return index % 2 == 1
            ? (results.Add(previousMeasurement + measurement + 5), 0, ++index)
            : (results, measurement, ++index);
    }
}
using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        List<Planet> Planets = Enumerable
            .Repeat(0, int.Parse(Console.ReadLine()))
            .Select(_ => Console.ReadLine().Split(' '))
            .Select(x => new Planet(x[0], x[1], x[2], x[3]))
            .OrderBy(x => x.DistanceFromAlice)
            .ToList();

        Planet Alice = Planets.First();

        bool WillNotDisintegrate(Planet planet)
        {
            double rocheLimit = Alice.Radius * Math.Pow(2 * Alice.Density / planet.Density, 1d / 3d);

            return planet.DistanceFromAlice >= rocheLimit;
        }

        Console.WriteLine(Planets.Skip(1).First(WillNotDisintegrate).Name);
    }

    private class Planet
    {
        public string Name { get; }

        public double Radius { get; }

        public double Density { get; }

        public double DistanceFromAlice { get; }

        public Planet(string name, string radius, string mass, string distanceFromAlice)
        {
            Name = name;
            Radius = double.Parse(radius);
            DistanceFromAlice = double.Parse(distanceFromAlice);
            double volume = 4d / 3d * Math.PI * Math.Pow(Radius, 3);
            Density = double.Parse(mass) / volume;
        }
    }
}
using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        string[] gymnasts = Console.ReadLine().Split(',');
        string[] categories = Console.ReadLine().Split(',');

        static List<Record> ToRecords(IEnumerable<string[]> values) => values
            .Select(x => new Record(x[1], x[2], x[3]))
            .ToList();

        Dictionary<string, List<Record>> gymnastToRecords = Enumerable
            .Repeat(0, int.Parse(Console.ReadLine()))
            .Select(_ => Console.ReadLine().Split(','))
            .GroupBy(x => x[0])
            .ToDictionary(x => x.Key, ToRecords);

        foreach(string gymnast in gymnasts)
        {
            string GetPersonalBest(string category) => category switch
            {
                "bars" => gymnastToRecords[gymnast].OrderByDescending(x => x.BarsScore).First().Bars,
                "beam" => gymnastToRecords[gymnast].OrderByDescending(x => x.BeamScore).First().Beam,
                "floor" => gymnastToRecords[gymnast].OrderByDescending(x => x.FloorScore).First().Floor,
                _ => throw new ArgumentOutOfRangeException()
            };

            Console.WriteLine(string.Join(',', categories.Select(GetPersonalBest)));
        }
    }

    private class Record
    {
        public string Bars { get; }

        public float BarsScore { get; }

        public string Beam { get; }

        public float BeamScore { get; }

        public string Floor { get; }

        public float FloorScore { get; }

        public Record(string bars, string beams, string floor)
        {
            Bars = bars;
            BarsScore = float.Parse(bars);
            Beam = beams;
            BeamScore = float.Parse(beams);
            Floor = floor;
            FloorScore = float.Parse(floor);
        }
    }
}
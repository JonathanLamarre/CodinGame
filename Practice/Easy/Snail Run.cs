using System;
using System.Linq;

public class Solution
{
    public static void Main(string[] args)
    {
        int[] speeds= Enumerable.Range(0, int.Parse(Console.ReadLine())).Select(_ => int.Parse(Console.ReadLine())).ToArray();
        (int mapHeight, int mapWidth) = (int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
        string[] map = Enumerable.Range(0, mapHeight).Select(_ => Console.ReadLine()).ToArray();
        (int, int)[] exits = map.Select((x, i) => (i, x.IndexOf('#'))).Where(x => x.Item2 != -1).ToArray();

        int winner = map
            .SelectMany((x, i) => x.Select((y, j) => (j, y - '0')).Where(y => y.Item2 >= 1 && y.Item2 <= 6).Select(y => (i, y.Item1, y.Item2)))
            .Select(x => (x.Item3, exits.Select(y => Math.Abs(x.Item1 - y.Item1) + Math.Abs(x.Item2 - y.Item2)).Min()))
            .OrderBy(x => x.Item2 / speeds[x.Item1 - 1])
            .ThenBy(x => x.Item2 % speeds[x.Item1 - 1])
            .First()
            .Item1;

        Console.WriteLine(winner);
    }
}
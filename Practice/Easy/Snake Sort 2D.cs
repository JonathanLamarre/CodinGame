using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    private static void Main(string[] args)
    {
        IEnumerable<string> sortedApples = Enumerable
            .Repeat(0, int.Parse(Console.ReadLine()))
            .Select(_ => Console.ReadLine().Split(' '))
            .Select(x => new {Name = x[0], Row = int.Parse(x[1]), Column = int.Parse(x[2])})
            .GroupBy(x => x.Row)
            .OrderBy(x => x.Key)
            .Select((x, i) => new {Row = i, Group = x})
            .SelectMany(x => x.Row % 2 == 0 ? x.Group.OrderBy(y => y.Column) : x.Group.OrderByDescending(y => y.Column))
            .Select(x => x.Name);

        Console.WriteLine(string.Join(',', sortedApples));
    }
}
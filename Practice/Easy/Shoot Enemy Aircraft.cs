using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    private static void Main(string[] args)
    {
        int numberOfLines = int.Parse(Console.ReadLine());

        IEnumerable<(int Y, int X)> ExtractPosition((int LineNumber, string Line) LineNumberAndPosition) => LineNumberAndPosition
            .Line
            .Select((x, i) => (numberOfLines - LineNumberAndPosition.LineNumber - 1, i, x))
            .Where(x => x.x == '<' || x.x == '>')
            .Select(x => (x.Item1, x.i));

        List<(int Y, int X)> planes = Enumerable
            .Range(0, numberOfLines - 1)
            .Select(x => (x, Console.ReadLine()))
            .SelectMany(ExtractPosition)
            .ToList();

        int positionOfShooter = Console.ReadLine().Select((x, i) => (x, i)).First(x => x.x == '^').i;
        HashSet<int> turnsToShoot = planes.Select(x => Math.Abs(x.X - positionOfShooter) - x.Y - 1).ToHashSet();

        foreach(int turn in Enumerable.Range(0, 40))
        {
            if (turnsToShoot.Contains(turn))
            {
                Console.WriteLine("SHOOT");
                turnsToShoot.Remove(turn);

                if (turnsToShoot.Count == 0) break;
            }
            else
            {
                Console.WriteLine("WAIT");
            }
        }        
    }
}
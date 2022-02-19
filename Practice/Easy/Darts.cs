using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int squareSize = int.Parse(Console.ReadLine());
        int radius = squareSize / 2;
        int numberOfCompetitors = int.Parse(Console.ReadLine());
        var competitors = new Dictionary<string, Competitor>();

        for (int i = 0; i < numberOfCompetitors; i++)
        {
            competitors.Add(Console.ReadLine(), new Competitor(i));
        }

        var diamondTop = new Point(0, radius);
        var diamondLeft = new Point(-radius, 0);
        var diamondBottom = new Point(0, -radius);
        var diamondRight = new Point(radius, 0);

        Func<Point, bool> IsInDiamond = point => IsLeftOrOnOfLine(diamondTop, diamondLeft, point)
            && IsLeftOrOnOfLine(diamondLeft, diamondBottom, point)
            && IsLeftOrOnOfLine(diamondBottom, diamondRight, point)
            && IsLeftOrOnOfLine(diamondRight, diamondTop, point);

        int circleRadiusSquared = radius * radius;

        Func<Point, bool> IsInCircle = point => (point.X * point.X) + (point.Y * point.Y) <= circleRadiusSquared;

        Func<Point, bool> IsInSquare = point => Math.Abs(point.X) <= radius && Math.Abs(point.Y) <= radius;

        int numberOfThrows = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfThrows; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            string throwName = inputs[0];
            var throwPoint = new Point(int.Parse(inputs[1]), int.Parse(inputs[2]));
            
            if (IsInDiamond(throwPoint))
            {
                competitors[throwName].Score += 15;
            }
            else if (IsInCircle(throwPoint))
            {
                competitors[throwName].Score += 10;
            }
            else if (IsInSquare(throwPoint))
            {
                competitors[throwName].Score += 5;
            }
        }

        foreach(var kv in competitors.OrderByDescending(x => x.Value.Score).ThenBy(x => x.Value.InitialIndex))
        {
            Console.WriteLine(kv.Key + " " + kv.Value.Score);
        }        
    }

    private class Competitor
    {
        public int InitialIndex { get; }

        public int Score { get; set; }

        public Competitor(int initialIndex)
        {
            InitialIndex = initialIndex;
        }
    }

    private static bool IsLeftOrOnOfLine(Point point1, Point point2, Point pointToTest)
    {
        int A = -(point2.Y - point1.Y);
        int B = point2.X - point1.X;
        int C = -((A * point1.X) + (B * point1.Y));
        
        return (A * pointToTest.X) + (B * pointToTest.Y) + C >= 0;
    }

    private class Point
    {
        public int X { get; }

        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
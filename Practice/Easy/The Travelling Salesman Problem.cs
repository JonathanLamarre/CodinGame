using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        var points = new List<Point>();
        string[] inputs = Console.ReadLine().Split(' ');
        Point firstPoint = new Point(int.Parse(inputs[0]), int.Parse(inputs[1]));

        for (int i = 1; i < N; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            points.Add(new Point(int.Parse(inputs[0]), int.Parse(inputs[1])));
        }

        Point actualPoint = firstPoint;
        double totalDistance = 0;

        while(points.Count != 0)
        {
            double minDistance = double.MaxValue;
            int indexOfMinDistancePoint = -1;

            for (int i = 0; i < points.Count; i++)
            {
                double distance = actualPoint.Distance(points[i]);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    indexOfMinDistancePoint = i;
                }                
            }

            totalDistance += minDistance;
            actualPoint = points[indexOfMinDistancePoint];
            points.RemoveAt(indexOfMinDistancePoint);
        }

        totalDistance += actualPoint.Distance(firstPoint);
        Console.WriteLine(Math.Round(totalDistance));
    }

    private struct Point
    {
        public int X { get; }

        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public double Distance(Point point)
        {
            int deltaX = X - point.X;
            int deltaY = Y - point.Y;
            var result =  Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));

            return result;
        }
    }
}
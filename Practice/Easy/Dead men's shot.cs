using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        string[] inputs;
        int N = int.Parse(Console.ReadLine());
        var points = new List<Point>();

        for (int i = 0; i < N; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int x = int.Parse(inputs[0]);
            int y = int.Parse(inputs[1]);
            points.Add(new Point(x, y));
        }

        points.Add(points[0]);

        int M = int.Parse(Console.ReadLine());

        for (int i = 0; i < M; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int x = int.Parse(inputs[0]);
            int y = int.Parse(inputs[1]);
            var pointToTest = new Point(x, y);
            string result = "hit";

            for(int j = 0; j < N; j++)
            {
                if (!IsLeftOrOnOfLine(points[j], points[j + 1], pointToTest))
                {
                    result = "miss";

                    break;
                }
            }

            Console.WriteLine(result);
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
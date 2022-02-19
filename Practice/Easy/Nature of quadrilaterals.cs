using System;

public class Solution
{
    public static void Main(string[] args)
    {
        int numberOfQuadrilaterals = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfQuadrilaterals; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            string answer = inputs[0] + inputs[3] + inputs[6] + inputs[9] + " is a ";
            Point point1 = new Point(int.Parse(inputs[1]), int.Parse(inputs[2]));
            Point point2 = new Point(int.Parse(inputs[4]), int.Parse(inputs[5]));
            Point point3 = new Point(int.Parse(inputs[7]), int.Parse(inputs[8]));
            Point point4 = new Point(int.Parse(inputs[10]), int.Parse(inputs[11]));
            bool isRectangle = PointsDefineRectangleIfInOrder(point1, point2, point3, point4);
            bool isRhombus = PointsDefineRhombusIfInOrder(point1, point2, point3, point4);

            if (isRectangle && isRhombus)
            {
                answer += "square";
            }
            else if (isRectangle)
            {
                answer += "rectangle";
            }
            else if (isRhombus)
            {
                 answer += "rhombus";
            }
            else if (PointsDefineParallelogramIfInOrder(point1, point2, point3, point4))
            {
                answer += "parallelogram";
            }
            else
            {
                answer += "quadrilateral";
            }

            Console.WriteLine(answer + ".");
        }
    }

    private static bool AreOrthogonal(Point point1, Point point2, Point point3) =>
        ((point2.X - point1.X) * (point2.X - point3.X)) + ((point2.Y - point1.Y) * (point2.Y - point3.Y)) == 0;

    private static bool PointsDefineRectangleIfInOrder(Point point1, Point point2, Point point3, Point point4) => AreOrthogonal(point1, point2, point3)
        && AreOrthogonal(point2, point3, point4)
        && AreOrthogonal(point3, point4, point1);

    private static double Distance(Point point1, Point point2) => Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));

    private static bool PointsDefineRhombusIfInOrder(Point point1, Point point2, Point point3, Point point4)
    {
        double distance1 = Distance(point1, point2);
        double distance2 = Distance(point2, point3);
        double distance3 = Distance(point3, point4);
        double distance4 = Distance(point4, point1);

        return distance1 == distance2 && distance2 == distance3 && distance3 == distance4 && distance4 == distance1;
    }
        
    private static bool PointsDefineParallelogramIfInOrder(Point point1, Point point2, Point point3, Point point4)
    {
        double distance1 = Distance(point1, point2);
        double distance2 = Distance(point2, point3);
        double distance3 = Distance(point3, point4);
        double distance4 = Distance(point4, point1);

        return distance1 == distance3 && distance2 == distance4;
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
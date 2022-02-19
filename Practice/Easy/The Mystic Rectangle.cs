using System;

public class Solution
{
    public static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        (int x, int y) = (int.Parse(inputs[0]), int.Parse(inputs[1]));
        inputs = Console.ReadLine().Split(' ');
        (int u, int v) = (int.Parse(inputs[0]), int.Parse(inputs[1]));
        int xDistance = Math.Abs(x - u);
        int xShortest = Math.Min(xDistance, 200 - xDistance);
        int yDistance = Math.Abs(y - v);
        int yShortest = Math.Min(yDistance, 150 - yDistance);
        int diagonalDistance = Math.Min(xShortest, yShortest);
        double timeToTheGoal = diagonalDistance * 0.5 + (xShortest - diagonalDistance) * 0.3  + (yShortest - diagonalDistance) * 0.4;
        Console.WriteLine("{0:0.0}", timeToTheGoal);
    }
}
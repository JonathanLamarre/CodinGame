using System;

public class Solution
{
    public static void Main(string[] args)
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        (int X, int Y) coordinates = (0, 0);
        int numberOfSteps = 0;
        int D = 0;

        do
        {
            numberOfSteps++;

            coordinates = ((D = (a * D + b) % m) % 4) switch
            {
                0 => (coordinates.X, coordinates.Y + 1),
                1 => (coordinates.X, coordinates.Y - 1),
                2 => (coordinates.X - 1, coordinates.Y),
                3 => (coordinates.X + 1, coordinates.Y)
            };
        } while(coordinates != (0, 0));

        Console.WriteLine(numberOfSteps);
    }
}
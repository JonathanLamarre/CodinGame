using System;
using System.Text;

public class Solution
{
    private static void Main(string[] args)
    {
        bool[,] field = new bool[19, 25];
        string[] instructions = Console.ReadLine().Split(' ');

        foreach(string instruction in instructions)
        {
            bool isPlantMow = instruction.StartsWith("PLANTMOW");
            bool isPlant = !isPlantMow && instruction.StartsWith("PLANT");
            string parsedInstruction = instruction.Substring(isPlant ? 5 : isPlantMow ? 8 : 0);
            int centerX = parsedInstruction[0] - 'a';
            int centerY = parsedInstruction[1] - 'a';
            double radius = int.Parse(parsedInstruction.Substring(2)) / 2d;

            //Not optimized, but good enough
            for (int x = 0; x < 19; x++)
            {
                for (int y = 0; y < 25; y++)
                {
                    double deltaX = Math.Abs(centerX - x);
                    double deltaY = Math.Abs(centerY - y);

                    if (Math.Sqrt(deltaX * deltaX + deltaY * deltaY) <= radius)
                    {
                        field[x, y] = isPlant ? false : isPlantMow ? !field[x, y] : true;
                    }
                } 
            }
        }

        for (int y = 0; y < 25; y++)
        {
            StringBuilder stringBuilder = new();

            for (int x = 0; x < 19; x++)
            {
                stringBuilder.Append(field[x, y] ? "  " : "{}");
            }

            Console.WriteLine(stringBuilder);
        }
    }
}
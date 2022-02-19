using System;
using System.Linq;
using System.Collections.Generic;

//This solution is more optimal memory wise than precalculating all
//the string in memory and takes the same time
public class Solution
{
    public static void Main(string[] args)
    {
        int width = int.Parse(Console.ReadLine());
        int height = int.Parse(Console.ReadLine());
        List<int> pixels = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        char fillingChar = '*';
        int pixelIndex = 0;

        for (int i = 0; i < height; i++)
        {
            string line = string.Empty;
            int remainingCharsToFill = width;

            while(line.Length < width)
            {
                int numberOfFillingChars = Math.Min(pixels[pixelIndex], remainingCharsToFill);
                line += new string(fillingChar, numberOfFillingChars);
                remainingCharsToFill -= numberOfFillingChars;
                pixels[pixelIndex] -= numberOfFillingChars;

                if (pixels[pixelIndex] == 0)
                {
                    pixelIndex++;
                    fillingChar = fillingChar == '*' ? ' ' : '*';
                }
            }

            Console.WriteLine($"|{line}|");
        }
    }
}
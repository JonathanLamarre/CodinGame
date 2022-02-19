using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        _ = Console.ReadLine();
        List<int> mountainHeights = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        int zeroHeightCorrector = Math.Abs(Math.Min(0, mountainHeights.Min() - 1));
        mountainHeights = mountainHeights.Select(x => x + zeroHeightCorrector).ToList();
        List<List<string>> answer = Enumerable.Range(0, mountainHeights.Max()).Select(_ => new List<string>()).ToList();
        int actualWidth = 0;
        int actualHeight = zeroHeightCorrector;

        void ExtendLineToDesiredWidth(List<string> line)
        {
            while (line.Count < actualWidth + 1)
            {
                line.Add(" ");
            }
        }

        foreach(int mountainHeight in mountainHeights)
        {
            while (actualHeight >= mountainHeight)
            {
                actualHeight--;
                ExtendLineToDesiredWidth(answer[actualHeight]);
                answer[actualHeight][actualWidth] = "\\";
                actualWidth++;
            }

            while (actualHeight < mountainHeight)
            {
                ExtendLineToDesiredWidth(answer[actualHeight]);
                answer[actualHeight][actualWidth] = "/";
                actualHeight++;
                actualWidth++;
            }

            actualHeight--;
            ExtendLineToDesiredWidth(answer[actualHeight]);
            answer[actualHeight][actualWidth] = "\\";
            actualWidth++;
        }

        while (actualHeight > zeroHeightCorrector)
        {
            actualHeight--;
            ExtendLineToDesiredWidth(answer[actualHeight]);
            answer[actualHeight][actualWidth] = "\\";
            actualWidth++;
        }

        while (actualHeight < zeroHeightCorrector)
        {
            ExtendLineToDesiredWidth(answer[actualHeight]);
            answer[actualHeight][actualWidth] = "/";
            actualHeight++;
            actualWidth++;
        }

        answer.Reverse();
        answer.ForEach(x => Console.WriteLine(string.Join(string.Empty, x)));
    }
}
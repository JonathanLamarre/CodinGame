using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int numberOfMountains = int.Parse(Console.ReadLine());
        List<int> mountainHeights = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        int totalWidth = 2 * mountainHeights.Sum();
        int maxHeight = mountainHeights.Max();
        List<List<string>> answer = Enumerable.Range(0, maxHeight).Select(_ => Enumerable.Repeat(" ", totalWidth).ToList()).ToList();
        int width = 0;

        foreach(int mountainHeight in mountainHeights)
        {
            int mountainWidth = 2 * mountainHeight;

            for (int i = 0; i < mountainHeight; i++)
            {
                int height = maxHeight - 1 - i;
                answer[height][width + i] = "/";
                answer[height][mountainWidth - i - 1 + width] = "\\";
            }

            width += mountainWidth;
        }

        answer.ForEach(x => Console.WriteLine(string.Join(string.Empty, x).TrimEnd()));
    }
}
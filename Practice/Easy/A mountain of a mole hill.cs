using System;
using System.Collections.Generic;

public class Solution
{
    private static readonly List<string> s_lines = new List<string>();
    private static readonly HashSet<Point> s_molesInGarden = new HashSet<Point>();
    private static readonly HashSet<Point> s_molesNotInGarden = new HashSet<Point>();

    public static void Main(string[] args)
    {
        for (int i = 0; i < 16; i++)
        {
            s_lines.Add(Console.ReadLine());
        }

        for (int i = 0; i < s_lines.Count; i++)
        {
            for (int j = 0; j < s_lines[i].Length; j++)
            {
                if (s_lines[i][j] != 'o') continue;

                if ((bool)IsInGarden(i, j))
                {
                    s_molesInGarden.Add(new Point(i, j));
                }
                else
                {
                    s_molesNotInGarden.Add(new Point(i, j));
                }
            }
        }

        Console.WriteLine(s_molesInGarden.Count);
    }

    private static bool? IsInGarden(int i, int j)
    {
        if (i < 0 || j < 0 || s_lines[i][j] == '.' || s_molesNotInGarden.Contains(new Point(i, j))) return false;

        if (s_lines[i][j] == ' ' || s_molesInGarden.Contains(new Point(i, j))) return true;

        if (s_lines[i][j] == '|') return !IsInGarden(i, j - 1);

        if (s_lines[i][j] == '-') return !IsInGarden(i - 1, j);

        if (s_lines[i][j] == '+') return null;

        bool? result = IsInGarden(i, j - 1);

        if (result != null) return result;

        result = IsInGarden(i - 1, j);

        if (result != null) return result;

        return !IsInGarden(i - 2, j - 2);
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
    }
}
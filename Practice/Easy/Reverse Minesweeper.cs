using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        (int w, int h) = (int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
        var grid = new List<string>();

        for (int i = 0; i < h; i++)
        {
            grid.Add(Console.ReadLine());
        }
        
        for (int i = 0; i < h; i++)
        {
            string answerLine = string.Empty;

            for (int j = 0; j < w; j++)
            {
                int numberNeighbourMines = grid[i][j] == 'x' ? 0 :
                    (i == 0 || j == 0 || grid[i - 1][j - 1] == '.' ? 0 : 1)
                    + (i == 0 || grid[i - 1][j] == '.' ? 0 : 1)
                    + (i == 0 || j == w - 1 || grid[i - 1][j + 1] == '.' ? 0 : 1)
                    + (j == 0 || grid[i][j - 1] == '.' ? 0 : 1)
                    + (j == w - 1 || grid[i][j + 1] == '.' ? 0 : 1)
                    + (i == h - 1 || j == 0 || grid[i + 1][j - 1] == '.' ? 0 : 1)
                    + (i == h - 1 || grid[i + 1][j] == '.' ? 0 : 1)
                    + (i == h - 1 || j == w - 1 || grid[i + 1][j + 1] == '.' ? 0 : 1);
                
                answerLine += numberNeighbourMines == 0 ? "." : numberNeighbourMines.ToString();
            }

            Console.WriteLine(answerLine);
        }
    }
}
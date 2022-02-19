using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        List<int> previousLine = null;
        List<int> lineToTest = null;
        List<int> actualLine = new List<int>();

        for (int i = 0; i < N; i++)
        {
            previousLine = lineToTest;
            lineToTest = actualLine;
            actualLine = new List<int>();
            string line = Console.ReadLine();
            int lineBlocks = line.Length / 3;

            for (int j = 0; j < lineBlocks; j++)
            {
                if (line[j * 3] == 'C')
                {
                    actualLine.Add(4 - int.Parse(line[(j * 3) + 2].ToString()));
                }
                else if (line[j * 3] == '(')
                {
                    actualLine.Add(-int.Parse(line[(j * 3) + 1].ToString()));
                }
                else
                {
                    actualLine.Add(5);
                }
            }

            if (previousLine != null)
                {
                    if (!IsValidLine(previousLine, lineToTest, actualLine))
                    {
                        Console.WriteLine("INVALID");
                        Environment.Exit(0);
                    }
                }
        }

        if (!IsValidLine(lineToTest, actualLine, new List<int>()))
        {
            Console.WriteLine("INVALID");
        }
        else
        {
            Console.WriteLine("VALID");
        }
    }

    private static bool IsValidLine(List<int> previousLine, List<int> lineToTest, List<int> nextLine)
    {
        for(int i = 0; i < lineToTest.Count; i++)
        {
            if (lineToTest[i] == 5 || lineToTest[i] < 0) continue;

            int summationOfNeighbours = lineToTest[i]
                + (i == 0 || lineToTest[i - 1] == 5 ? 0 : lineToTest[i - 1])
                + (i == lineToTest.Count - 1 || lineToTest[i + 1] == 5 ? 0 : lineToTest[i + 1])
                + (i >= previousLine.Count || previousLine[i] == 5 ? 0 : previousLine[i])
                + (i >= nextLine.Count || nextLine[i] == 5 ? 0 : nextLine[i]);

            if (summationOfNeighbours != 0) return false;
        }

        return true;
    }
}
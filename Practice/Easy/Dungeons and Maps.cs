using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int width = int.Parse(inputs[0]);
        int height = int.Parse(inputs[1]);
        inputs = Console.ReadLine().Split(' ');
        int startRow = int.Parse(inputs[0]);
        int startColumn = int.Parse(inputs[1]);
        int numberOfMaps = int.Parse(Console.ReadLine());
        var numberOfMovesToTreasureForEachMap = Enumerable.Repeat(int.MaxValue, numberOfMaps).ToList();

        for (int mapNumber = 0; mapNumber < numberOfMaps; mapNumber++)
        {
            var map = new List<string>();

            for (int j = 0; j < height; j++)
            {
                map.Add(Console.ReadLine());
            }

            int actualRow = startRow;
            int actualColumn = startColumn;
            int numberOfMovesToTreasure = 0;
            var visitedPositions = new HashSet<(int, int)>();

            while(true)
            {
                numberOfMovesToTreasure++;
                char symbol = map[actualRow][actualColumn];
                (int, int) visitedPosition = (actualRow, actualColumn);

                if (visitedPositions.Contains(visitedPosition)) break;

                visitedPositions.Add(visitedPosition);
                
                if (symbol == '<')
                {
                    if (actualColumn == 0) break;

                    actualColumn--;

                    continue;
                }

                if (symbol == '^')
                {
                    if (actualRow == 0) break;

                    actualRow--;

                    continue;
                }

                if (symbol == '>')
                {
                    if (actualColumn == width - 1) break;

                    actualColumn++;

                    continue;
                }

                if (symbol == 'v')
                {
                    if (actualRow == height - 1) break;

                    actualRow++;

                    continue;
                }

                if (symbol == 'T')
                {
                    numberOfMovesToTreasureForEachMap[mapNumber] = numberOfMovesToTreasure;

                    break;
                }

                break;
            }
        }

        if (numberOfMovesToTreasureForEachMap.All(x => x == int.MaxValue))
        {
            Console.WriteLine("TRAP");
        }
        else
        {
            Console.WriteLine(numberOfMovesToTreasureForEachMap.IndexOf(numberOfMovesToTreasureForEachMap.Min()));
        }        
    }
}
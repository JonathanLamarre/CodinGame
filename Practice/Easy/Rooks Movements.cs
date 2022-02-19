using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        string rookPosition = Console.ReadLine();
        
        Dictionary<string, string> piecePositionToPieceColor = Enumerable
            .Range(0, int.Parse(Console.ReadLine()))
            .Select(_ => Console.ReadLine().Split(' '))
            .ToDictionary(x => x[1], x => x[0]);

        var possibleMoves = new List<string>();

        bool AddPositionIfValid(char column, char row)
        {
            string position = new string(new char[] {column, row});

            if (piecePositionToPieceColor.TryGetValue(position, out string color))
            {
                if (color == "1")
                {
                    possibleMoves.Add($"R{rookPosition}x{position}");
                }
                
                return false;
            }

            possibleMoves.Add($"R{rookPosition}-{position}");

            return true;
        }

        for (char c = (char)(rookPosition[0] - 1); c >= 'a'; c = (char)(c - 1))
        {
            if (!AddPositionIfValid(c, rookPosition[1])) break;
        }

        for (char c = (char)(rookPosition[0] + 1); c <= 'h'; c = (char)(c + 1))
        {
            if (!AddPositionIfValid(c, rookPosition[1])) break;
        }

        for (char c = (char)(rookPosition[1] - 1); c >= '1'; c = (char)(c - 1))
        {
            if (!AddPositionIfValid(rookPosition[0], c)) break;
        }

        for (char c = (char)(rookPosition[1] + 1); c <= '8'; c = (char)(c + 1))
        {
            if (!AddPositionIfValid(rookPosition[0], c)) break;
        }

        possibleMoves.Sort();        
        possibleMoves.ForEach(x => Console.WriteLine(x));
    }
}
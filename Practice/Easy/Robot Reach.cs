using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        (int R, int C, int T) = (int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
        HashSet<(int, int)> visitedCells = new HashSet<(int, int)>();
        Stack<(int, int)> cellsToVisit = new Stack<(int, int)>();
        cellsToVisit.Push((0, 0));
        int SumOfDigits(int number) => number.ToString().Aggregate(0, (x, y) => x + y - '0');
        bool RespectsThreshold((int x, int y) cell) => SumOfDigits(cell.x) + SumOfDigits(cell.y) <= T;

        do
        {
            (int x, int y) actualCell = cellsToVisit.Pop();
            visitedCells.Add(actualCell);

            var potentialCellsToVisit = new List<(int, int)>
            {
                (actualCell.x - 1, actualCell.y),
                (actualCell.x + 1, actualCell.y),
                (actualCell.x, actualCell.y - 1),
                (actualCell.x, actualCell.y + 1)
            };

            foreach((int x, int y) potentialCellToVisit in potentialCellsToVisit)
            {
                if
                (
                    potentialCellToVisit.x < 0
                    || potentialCellToVisit.x >= R
                    || potentialCellToVisit.y < 0
                    || potentialCellToVisit.y >= C
                    || visitedCells.Contains(potentialCellToVisit)
                    || !RespectsThreshold(potentialCellToVisit)
                )
                {
                    continue;
                }

                cellsToVisit.Push(potentialCellToVisit);
            }
        } while(cellsToVisit.Count > 0);


        Console.WriteLine(visitedCells.Count);
    }
}
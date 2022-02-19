using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;

public class Solution
{
    public static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        (int height, int width) = (int.Parse(inputs[0]), int.Parse(inputs[1]));
        var pathsToExplore = new Stack<Path>();
        var completedPaths = new HashSet<Path>();
        List<string> map = Enumerable.Repeat(0, height).Select(_ => Console.ReadLine()).ToList();
        
        for (int i = 0; pathsToExplore.Count == 0; i++)
        {
            for (int j = 0; pathsToExplore.Count == 0 && j < width; j++)
            {
                if (map[i][j] == 'X')
                {
                    pathsToExplore.Push(new Path((i, j)));
                }
            }
        }

        while(pathsToExplore.Count > 0)
        {
            Path pathToExplore = pathsToExplore.Pop();
            bool pathContinues = false;

            void CheckCell(int x, int y)
            {
                if
                (
                    x < 0
                    || x == height
                    || y < 0
                    || y == width
                    || pathToExplore.ExploredCells.Contains((x, y))
                    || map[x][y] == '#'
                )
                {
                    return;
                }

                pathContinues = true;

                if (map[x][y] == ' ')
                {
                    pathsToExplore.Push(pathToExplore.SetActualCell((x, y), 0));

                    return;
                }

                pathsToExplore.Push(pathToExplore.SetActualCell((x, y), map[x][y] - '0'));
            }

            CheckCell(pathToExplore.ActualCell.X - 1, pathToExplore.ActualCell.Y);
            CheckCell(pathToExplore.ActualCell.X + 1, pathToExplore.ActualCell.Y);
            CheckCell(pathToExplore.ActualCell.X, pathToExplore.ActualCell.Y - 1);
            CheckCell(pathToExplore.ActualCell.X, pathToExplore.ActualCell.Y + 1);

            if (!pathContinues)
            {
                completedPaths.Add(pathToExplore);
            }
        }

        Console.WriteLine(completedPaths.Select(x => x.TotalGold).Max());
    }

    private class Path
    {
        public (int X, int Y) ActualCell { get; }

        public ImmutableHashSet<(int, int)> ExploredCells { get; }

        public int TotalGold { get; }

        private Path
        (
            (int, int) actualCell,
            ImmutableHashSet<(int, int)> exploredCells,
            int totalGold
        )
        {
            ActualCell = actualCell;
            ExploredCells = exploredCells;
            TotalGold = totalGold;
        }

        public Path((int, int) firstCell) : this
        (
            firstCell,
            ImmutableHashSet<(int, int)>.Empty,
            0
        )
        {}

        public Path SetActualCell((int, int) actualCell, int gold) => new Path
        (
            actualCell,
            ExploredCells.Add(ActualCell),
            TotalGold + gold
        );
    }
}
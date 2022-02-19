using System;
using System.Collections.Generic;

namespace Solution
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine()?.Split(' ') ?? throw new InvalidOperationException();
            int width = int.Parse(inputs[0]);
            int height = int.Parse(inputs[1]);
            long totalNumberOfMoves = long.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            char[,] grid = new char[height, width];
            int yPosition = 0;
            int xPosition = 0;
            char orientation = '^';

            for (int i = 0; i < height; i++)
            {
                string line = Console.ReadLine() ?? throw new InvalidOperationException();

                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == 'O')
                    {
                        yPosition = i;
                        xPosition = j;
                        grid[i, j] = '.';
                    }
                    else
                    {
                        grid[i, j] = line[j];
                    }
                }
            }

            orientation = Orient(grid, yPosition, xPosition, orientation);

            Dictionary<Tuple<int, int, char>, int> positions = new Dictionary<Tuple<int, int, char>, int>();
            positions[new Tuple<int, int, char>(yPosition, xPosition, orientation)] = 0;

            for (long moveNumber = 1; moveNumber <= totalNumberOfMoves; moveNumber++)
            {
                if (orientation == '^')
                {
                    yPosition--;
                }
                else if (orientation == '>')
                {
                    xPosition++;
                }
                else if (orientation == 'v')
                {
                    yPosition++;
                }
                else
                {
                    xPosition--;
                }

                orientation = Orient(grid, yPosition, xPosition, orientation);
                var actualPosition = new Tuple<int, int, char>(yPosition, xPosition, orientation);

                if (!positions.ContainsKey(actualPosition)) continue;

                long numberOfMovesLeft = totalNumberOfMoves - moveNumber;
                long lengthOfCycle = moveNumber - positions[actualPosition];
                moveNumber += numberOfMovesLeft / lengthOfCycle * lengthOfCycle;
            }

            Console.WriteLine(xPosition + " " + yPosition);
        }

        private static char Orient(char[,] grid, int yPosition, int xPosition, char orientation)
        {
            while (!IsNextStepFree(grid, yPosition, xPosition, orientation))
            {
                if (orientation == '^')
                {
                    orientation = '>';
                }
                else if (orientation == '>')
                {
                    orientation = 'v';
                }
                else if (orientation == 'v')
                {
                    orientation = '<';
                }
                else
                {
                    orientation = '^';
                }
            }

            return orientation;
        }

        private static bool IsNextStepFree(char[,] grid, int yPosition, int xPosition, char orientation)
        {
            return orientation == '^' && grid[yPosition - 1, xPosition] == '.'
                || orientation == '>' && grid[yPosition, xPosition + 1] == '.'
                || orientation == 'v' && grid[yPosition + 1, xPosition] == '.'
                || orientation == '<' && grid[yPosition, xPosition - 1] == '.';
        }
    }
}
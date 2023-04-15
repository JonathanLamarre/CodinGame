using System;
using System.Linq;

public class Solution
{
    private static void Main(string[] args)
    {
        int gridHeight = int.Parse(Console.ReadLine().Split(' ')[1]);
        string[] inputs = Console.ReadLine().Split(' ');
        (int, int) start = (int.Parse(inputs[0]), int.Parse(inputs[1]));
        (int x, int y) = start;
        char[][] grid = Enumerable.Repeat(0, gridHeight).Select(_ => Console.ReadLine().ToArray()).ToArray();
        int rotations = 0;
        
        do
        {
            rotations++;
            grid[y][x] = grid[y][x] == '^' ? '>' : grid[y][x] == '>' ? 'v' : grid[y][x] == 'v' ? '<' : '^';
            int newX = grid[y][x] == '<' ? x - 1 : grid[y][x] == '>' ? x + 1 : x;
            int newY = grid[y][x] == '^' ? y - 1 : grid[y][x] == 'v' ? y + 1 : y;
            (x, y) = (newX, newY);
        } while((x, y) != start && x >=0 && x < grid[0].Length && y >= 0 && y < grid.Length);

        Console.WriteLine(rotations);
    }
}
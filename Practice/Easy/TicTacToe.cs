using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        var board = new List<List<char>>();

        for (int i = 0; i < 3; i++)
        {
            string line = Console.ReadLine();
            board.Add(new List<char>());

            foreach(char c in line)
            {
                board[i].Add(c);
            }
        }

        //Lines
        for (int i = 0; i < 3; i++)
        {
            if (IsWinning(board[i], out int index))
            {
                board[i][index] = 'O';
                PrintBoardAndExit(board);
            }
        }
        
        //Columns
        for (int i = 0; i < 3; i++)
        {
            if (IsWinning(new List<char> {board[0][i], board[1][i], board[2][i]}, out int index))
            {
                board[index][i] = 'O';
                PrintBoardAndExit(board);
            }
        }
        
        //Diagonal 1
        if (IsWinning(new List<char> {board[0][0], board[1][1], board[2][2]}, out int index1))
        {
            board[index1][index1] = 'O';
            PrintBoardAndExit(board);
        }

        //Diagonal 2
        if (IsWinning(new List<char> {board[2][0], board[1][1], board[0][2]}, out int index2))
        {
            board[2 - index2][index2] = 'O';
            PrintBoardAndExit(board);
        }

        Console.WriteLine("false");
    }

    private static bool IsWinning(List<char> line, out int index)
    {
        var charToFrequency = line.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

        if
        (
            charToFrequency.ContainsKey('O')
            && charToFrequency['O'] == 2
            && charToFrequency.ContainsKey('.')
            && charToFrequency['.'] == 1
        )
        {
            index = line.IndexOf('.');

            return true;
        }
        else
        {
            index = -1;

            return false;
        }
    }

    private static void PrintBoardAndExit(List<List<char>> board)
    {
        foreach(List<char> line in board)
        {
            Console.WriteLine(new string(line.ToArray()));
        }

        Environment.Exit(0);
    }
}
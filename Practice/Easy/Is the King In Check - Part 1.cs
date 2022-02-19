using System;
using System.Linq;

public class Solution
{
    public static void Main(string[] args)
    {
        int kingx = -1;
        int kingy = -1;
        int piecex = -1;
        int piecey = -1;
        char piece = default;

        for (int i = 0; i < 8; i++)
        {
            string chessRow = Console.ReadLine().Replace(" ", string.Empty);

            foreach(int indexOfPiece in Enumerable.Range(0, 8).Where(x => chessRow[x] != '_'))
            {
                if (chessRow[indexOfPiece] == 'K')
                {
                    kingx = indexOfPiece;
                    kingy = i;
                }
                else
                {
                    piecex = indexOfPiece;
                    piecey = i;
                    piece = chessRow[indexOfPiece];
                }
            }
            
            if (kingx != -1 && piecex != -1) break;
        }

        bool IsRookCheck() => kingx == piecex || kingy == piecey;

        bool IsBishopCheck() => Math.Abs(kingx - piecex) == Math.Abs(kingy - piecey);

        bool IsKnightCheck() => Math.Abs(kingx - piecex) == 1 && Math.Abs(kingy - piecey) == 2
            || Math.Abs(kingx - piecex) == 2 && Math.Abs(kingy - piecey) == 1;

        bool isCheck = piece == 'Q' && (IsRookCheck() || IsBishopCheck())
            || piece == 'R' && IsRookCheck()
            || piece == 'B' && IsBishopCheck()
            || piece == 'N' && IsKnightCheck();

        Console.WriteLine(isCheck ? "Check" : "No Check");
    }    
}
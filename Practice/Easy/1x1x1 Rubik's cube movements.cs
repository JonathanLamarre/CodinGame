using System;
using System.Linq;

public class Solution
{
    public static (string, string, string, string, string, string) Rotate
    (
        (string L, string U, string R, string D, string F, string B) dice,
        string direction
    )
    {
        (string L, string U, string R, string D, string F, string B) = dice;

        if (direction == "x") return (L, F, R, B, D, U);
        else if (direction == "x'") return (L, B, R, F, U, D);
        else if (direction == "y") return (F, U, B, D, R, L);
        else if (direction == "y'") return (B, U, F, D, L, R);
        else if (direction == "z") return (D, L, U, R, F, B);
        else return (U, R, D, L, F, B);
    }

    public static void Main(string[] args)
    {
        (string L, string U, string R, string D, string F, string B) = Console.ReadLine().Split().Aggregate(("L", "U", "R", "D", "F", "B"), Rotate);

        void PrintResult(string face)
        {
            if (L == face) Console.WriteLine("L");
            else if (U == face) Console.WriteLine("U");
            else if (R == face) Console.WriteLine("R");
            else if (D == face) Console.WriteLine("D");
            else if (F == face) Console.WriteLine("F");
            else Console.WriteLine("B");
        }

        PrintResult(Console.ReadLine());
        PrintResult(Console.ReadLine());
    }
}
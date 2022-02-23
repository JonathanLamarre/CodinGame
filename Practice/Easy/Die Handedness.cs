using System;

public class Solution
{
    public static void Main(string[] args)
    {
        string dice = Console.ReadLine()[1] + Console.ReadLine() + Console.ReadLine()[1];
        static bool DoesFacesSumEqual7(char face1, char face2) => face1 + face2 - '0' == 7;

        if
        (
            !DoesFacesSumEqual7(dice[0], dice[5])
            || !DoesFacesSumEqual7(dice[1], dice[3])
            || !DoesFacesSumEqual7(dice[2], dice[4])
        )
        {
            Console.WriteLine("degenerate");

            return;
        }

        dice = dice[0] == '1' ? dice
            : dice[1] == '1' ? $"1{dice[5]}{dice[2]}{dice[0]}{dice[4]}{dice[3]}"
            : dice[2] == '1' ? $"1{dice[1]}{dice[5]}{dice[3]}{dice[0]}{dice[4]}"
            : dice[3] == '1' ? $"1{dice[0]}{dice[2]}{dice[5]}{dice[4]}{dice[1]}"
            : dice[4] == '1' ? $"1{dice[1]}{dice[0]}{dice[3]}{dice[5]}{dice[2]}"
            : $"1{dice[1]}{dice[4]}{dice[3]}{dice[2]}{dice[0]}";

        string diceWithout1And6 = dice.Substring(1, 4);
        Console.WriteLine(diceWithout1And6[(diceWithout1And6.IndexOf('2') + 1) % 4] == '3' ? "right-handed" : "left-handed");
    }
}
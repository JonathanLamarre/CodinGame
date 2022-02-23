using System;

public class Solution
{
    public static void Main(string[] args)
    {
        string dice = Console.ReadLine()[1] + Console.ReadLine() + Console.ReadLine()[1];
        
        foreach(char command in Console.ReadLine())
        {
            dice = command == 'U' ? $"{dice[4]}{dice[1]}{dice[0]}{dice[3]}{dice[5]}{dice[2]}"
                : command == 'L' ? $"{dice[4]}{dice[5]}{dice[1]}{dice[0]}{dice[3]}{dice[2]}"
                : command == 'D' ? $"{dice[4]}{dice[3]}{dice[5]}{dice[1]}{dice[0]}{dice[2]}"
                : $"{dice[4]}{dice[0]}{dice[3]}{dice[5]}{dice[1]}{dice[2]}";
        }

        Console.WriteLine(dice[2]);
    }
}
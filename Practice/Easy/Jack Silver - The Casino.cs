using System;

public class Solution
{
    public static void Main(string[] args)
    {
        int numberOfRounds = int.Parse(Console.ReadLine());
        int cash = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfRounds; i++)
        {
            int bet = (int)Math.Ceiling(cash / 4d);
            string[] inputs = Console.ReadLine().Split(" ");
            int ball = int.Parse(inputs[0]);

            if (inputs[1] == "EVEN" && ball != 0 && ball % 2 == 0 || inputs[1] == "ODD" && ball % 2 == 1)
            {
                cash += bet;
            }
            else if (inputs[1] == "PLAIN" && ball == int.Parse(inputs[2]))
            {
                cash += 35 * bet;
            }
            else
            {
                cash -= bet;
            }
        }

        Console.WriteLine(cash);
    }
}
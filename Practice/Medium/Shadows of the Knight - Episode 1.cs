using System;

public class Player
{
    public static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int maxXSearch = int.Parse(inputs[0]) - 1;
        int maxYSearch = int.Parse(inputs[1]) - 1;
        int maxTurns = int.Parse(Console.ReadLine());
        inputs = Console.ReadLine().Split(' ');
        int xBatman = int.Parse(inputs[0]);
        int yBatman = int.Parse(inputs[1]);
        int minXSearch = 0;
        int minYSearch = 0;

        while (true)
        {
            string bombDirection = Console.ReadLine();
            
            if (bombDirection.Contains("L"))
            {
                maxXSearch = xBatman;
                xBatman = minXSearch + (maxXSearch - minXSearch) / 2;
            }
            else if (bombDirection.Contains("R"))
            {
                minXSearch = xBatman;
                xBatman = minXSearch + (maxXSearch - minXSearch + 1) / 2;
            }
            
            if (bombDirection.Contains("U"))
            {
                maxYSearch = yBatman;
                yBatman = minYSearch + (maxYSearch - minYSearch) / 2;
            }
            else if (bombDirection.Contains("D"))
            {
                minYSearch = yBatman;
                yBatman = minYSearch + (maxYSearch - minYSearch + 1) / 2;
            }

            Console.WriteLine(xBatman + " " + yBatman);
        }
    }
}
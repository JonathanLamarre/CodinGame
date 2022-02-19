using System;

public class Player
{
    public static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        int lightX = int.Parse(inputs[0]);
        int lightY = int.Parse(inputs[1]);
        int thorX = int.Parse(inputs[2]);
        int thorY = int.Parse(inputs[3]);

        while (true)
        {
            int remainingTurns = int.Parse(Console.ReadLine());
            string direction = "";
                
            if (thorY > lightY)
            {
                direction += "N";
                --thorY;
            }
            else if (thorY < lightY)
            {
                direction += "S";
                ++thorY;
            }
            
            if (thorX > lightX)
            {
                direction += "W";
                --thorX;
            }
            else if (thorX < lightX)
            {
                direction += "E";
                ++thorX;
            }
                
            Console.WriteLine(direction);
        }
    }
}
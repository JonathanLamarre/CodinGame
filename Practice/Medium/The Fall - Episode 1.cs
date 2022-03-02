using System;

public class Player
{
    public static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int width = int.Parse(inputs[0]);
        int height = int.Parse(inputs[1]);
        int[,] grid = new int[width, height];
        
        for (int j = 0; j < height; j++)
        {
            inputs = Console.ReadLine().Split(' ');
			
            for (int i = 0; i < width; i++)
            {
                grid[i,j] = int.Parse(inputs[i]);
            }
        }
        
        int exitX = int.Parse(Console.ReadLine()); 

        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int x = int.Parse(inputs[0]);
            int y = int.Parse(inputs[1]);
            string entrance = inputs[2];
            string result;
            int t = grid[x,y];

            if (((t == 2 || t == 6) && entrance == "RIGHT") || (t == 4 && entrance == "TOP") || t == 10)
            {
                Console.WriteLine((x - 1) + " " + y);
            }
            else if (((t == 2 || t == 6) && entrance == "LEFT") || (t == 5 && entrance == "TOP") || t == 11)
            {
                Console.WriteLine((x + 1) + " " + y);
            }
            else
            {
                Console.WriteLine(x + " " + (y + 1));
            }
        }
    }
}
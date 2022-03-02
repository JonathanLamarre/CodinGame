using System;

public class Player
{
    public static void Main(string[] args)
    {
        int width = int.Parse(Console.ReadLine());
        int height = int.Parse(Console.ReadLine());
        bool[,] grid = new bool[width,height];
        
        for (int j = 0; j < height; j++)
        {
            string line = Console.ReadLine();
            
            for (int i = 0; i < width; i++)
            {
                grid[i,j] = line[i] == '0';
            }
        }
        
        for (int i = 0; i < width; i++)
        {            
            for (int j = 0; j < height; j++)
            {
                if (grid[i,j])
                {
                    string rightNeighbour = "-1 -1";
                     
                    for (int k = i + 1; k < width; k++)
                    {
                        if (grid[k,j])
                        {
                            rightNeighbour = k + " " + j;

                            break;
                        }
                    }
                    
                    string bottomNeighbour = "-1 -1";
                     
                    for (int k = j + 1; k < height; k++)
                    {
                        if (grid[i,k])
                        {
                            bottomNeighbour = i + " " + k;
                            
                            break;
                        }
                    }
                    
                    Console.WriteLine(i + " " + j + " " + rightNeighbour + " " + bottomNeighbour);
                }                
            }
        }
    }
}
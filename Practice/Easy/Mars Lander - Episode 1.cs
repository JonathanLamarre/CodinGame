using System;

public class Player
{
    private const double GRAVITY = -3.711;
    private const int CRASH_SPEED_LIMIT = -40;
    
    public static void Main(string[] args)
    {        
        for (int i = 0; true; i++)
        {
            Console.WriteLine("0 " + (i < 12 ? 0 : 4));
        }
    
    }
}
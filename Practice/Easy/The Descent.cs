using System;

public class Player
{
    private static void Main(string[] args)
    {
        while (true)
        {
            int maxMountain = 0;
            int indexMaxMountain = int.MinValue;

            for (int i = 0; i < 8; i++)
            {
                int heightMountain = int.Parse(Console.ReadLine());

                if (heightMountain > maxMountain)
                {
                    maxMountain = heightMountain;
                    indexMaxMountain = i;
                }
            }

            Console.WriteLine(indexMaxMountain);
        }
    }
}
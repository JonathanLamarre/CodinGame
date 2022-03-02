using System;

public class Solution
{
    public static void Main(string[] args)
    {
        string[] GetPicture()
        {
            string[] picture = new string[int.Parse(Console.ReadLine().Split(' ')[1])]; 

            for (int i = 0; i < picture.Length; i++)
            {
                picture[i] = Console.ReadLine();
            }

            return picture;
        }

        string[] wallyPicture = GetPicture();
        string[] picture = GetPicture();

        for (int i = 0; i < picture.Length - wallyPicture.Length + 1; i++)
        {
            for (int j = 0; j < picture[0].Length - wallyPicture[0].Length + 1; j++)
            {
                bool foundWally = true;

                for (int m = 0; m < wallyPicture.Length && foundWally; m++)
                {
                    for (int n = 0; n < wallyPicture[0].Length && foundWally; n++)
                    {
                        foundWally = wallyPicture[m][n] == ' ' || wallyPicture[m][n] == picture[i + m][j + n];
                    }
                }

                if (foundWally)
                {
                    Console.WriteLine($"{j} {i}");

                    return;
                }
            }
        }
    }
}
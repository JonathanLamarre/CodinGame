using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        (int height, int width) = (int.Parse(inputs[0]), int.Parse(inputs[1]));
        var numbers = new List<List<char>>();

        for (int i = 0; i < height; i++)
        {
            numbers.Add(Console.ReadLine().Split(" ").Select(x => x.First()).Select(x => x == '-' ? '-' : '1').ToList());
        }

        char previous = '0';

        for (int i = 0; i < height; i++)
        {
            string[] line = Console.ReadLine().Split(" ");

            for (int j = 0; j < width; j++)
            {
                if (line[j] == "X")
                {
                    if (numbers[i][j] == '-' && previous == '-' || numbers[i][j] == '1' && previous == '1')
                    {
                        Console.WriteLine("false");

                        return;
                    }

                    previous = numbers[i][j];
                }
            }
        }

        Console.WriteLine("true");
    }
}
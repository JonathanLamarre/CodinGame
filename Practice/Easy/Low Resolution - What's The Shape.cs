using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {    
        List<string> image = Enumerable
            .Range(0, int.Parse(Console.ReadLine().Split(' ')[1]))
            .Select(_ =>  Console.ReadLine())
            .ToList();

        if (image.All(x => x.All(y => y == 'X')))
        {
            Console.WriteLine("Rectangle");
        }
        else if (image.Select(x => x.Count(y => y == '.')).Sum() >= image.Count * image.First().Length / 3)
        {
            Console.WriteLine("Triangle");
        }
        else
        {
            Console.WriteLine("Ellipse");
        }
    }
}
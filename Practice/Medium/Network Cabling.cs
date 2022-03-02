using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        long minX = long.MaxValue;
        long maxX = long.MinValue;
        List<long> ys = new List<long>(); 
        
        for (int i = 0, nBuildings = int.Parse(Console.ReadLine()); i < nBuildings; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            long x = long.Parse(inputs[0]);
            ys.Add(long.Parse(inputs[1]));
            
            if (x < minX) {minX = x;}
            if (x > maxX) {maxX = x;}  
        }
        
        ys.Sort();
        long median = ys[ys.Count / 2];
        Console.WriteLine(maxX - minX + ys.Aggregate(0l, (a, y) => a + Math.Abs(y - median)));
    }
}
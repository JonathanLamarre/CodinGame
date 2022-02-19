using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        List<int> strenghts = new List<int>();
        
        for (int i = 0, nStrenghts = int.Parse(Console.ReadLine()); i < nStrenghts; i++)
        {
            strenghts.Add(int.Parse(Console.ReadLine()));
        }
        
        strenghts.Sort();
        int result = int.MaxValue;
        
        for (int i = 0; i < strenghts.Count - 1; i++)
        {
            int absoluteDifference = Math.Abs(strenghts[i] - strenghts[i + 1]);
            if (absoluteDifference < result) { result = absoluteDifference; }
        }        

        Console.WriteLine(result);
    }
}
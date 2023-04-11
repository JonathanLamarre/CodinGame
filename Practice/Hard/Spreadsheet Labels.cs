using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

public class Solution
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string[] inputs = Console.ReadLine().Split(' ');
        List<string> labels = new List<string>();
                
        for (int i = 0; i < n; i++)
        {
            //The string contains numbers
            if (inputs[i][0] < 65)
            {
                labels.Add(convertNumericToAlpha(long.Parse(inputs[i])));
            }
            //The string contains letters
            else
            {
                labels.Add(convertAlphaToNumeric(inputs[i]).ToString());
            }
        }
        
        Console.WriteLine(String.Join(" ", labels));
    }
    
    private static string convertNumericToAlpha(long numericLabel)
    {
        List<char> alphaLabel = new List<char>();
            
        while(numericLabel != 0)
        {
            long rest = (--numericLabel) % 26;
            alphaLabel.Add((char)('A' + rest));
            numericLabel = (numericLabel - rest) / 26;
        }
        
        alphaLabel.Reverse();
        
        return new String(alphaLabel.ToArray());
    }
    
    private static BigInteger convertAlphaToNumeric(string alphaLabel)
    {
        BigInteger numericLabel = 0;
        BigInteger power = 1;
        
        foreach(char c in alphaLabel.Reverse())
        {
            numericLabel += (c - 64) * power;
            power *= 26;
        }
        
        return numericLabel;
    }
}
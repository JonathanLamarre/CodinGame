using System;
using System.Collections.Generic;

public class Solution
{
    private static string[] mayanNumbers = new string[20];
    private static int height;
    
    public static void Main(string[] args)
    {        
        for (int i = 0; i < 20; i++)
        {
            mayanNumbers[i] = string.Empty;
        }
        
        string[] inputs = Console.ReadLine().Split(' ');
        int width = int.Parse(inputs[0]);
        height = int.Parse(inputs[1]);
                
        for (int i = 0; i < height; i++)
        {
            string line = Console.ReadLine();
            
            for (int j = 0; j < 20; j++)
            {
                mayanNumbers[j] += line.Substring(j * width, width);
            }
        }
        
        long operande1 = readMayanNumber();
        long operande2 = readMayanNumber();        
        string operation = Console.ReadLine();
        long result = 0;
        
        if (operation == "*") result = operande1 * operande2;
        else if (operation == "/") result = operande1 / operande2;
        else if (operation == "+") result = operande1 + operande2;
        else if (operation == "-") result = operande1 - operande2;
		
        List<long> resultBase20 = new List<long>();

        do
        {
            long rest = result % 20;
            resultBase20.Add(rest);
            result -= rest;
            result /= 20;            
        }
        while(result != 0);
        
        resultBase20.Reverse();
        
        foreach (long number in resultBase20)
        {
            for (int i = 0; i < height; i++)
            {
                Console.WriteLine(mayanNumbers[number].Substring(i * width, width));
            }
        }
    }
    
    private static long readMayanNumber()
    {
        int count = 0;
        string number = string.Empty;
        List<int> numbers = new List<int>();
        
        for (int i = 0, nLines = int.Parse(Console.ReadLine()); i < nLines; i++)
        {
            number += Console.ReadLine();
            ++count;
            
            if (count == height)
            {
                count = 0;
                numbers.Add(Array.IndexOf(mayanNumbers, number));
                number = string.Empty;
            }
        }
        
        numbers.Reverse();
        long result = 0;
        
        for (int i = 0; i < numbers.Count; i++)
        {
            result += numbers[i] * Power(20, i);
        }
        
        return result;
    }
    
    private static long Power(int b, int e)
    {
        long result = 1;
        
        while (e-- > 0)
        {
            result *= b;
        }
        
        return result;
    }
}
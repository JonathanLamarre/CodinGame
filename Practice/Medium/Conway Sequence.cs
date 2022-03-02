using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int originalNumber = int.Parse(Console.ReadLine());
        int lineToDisplay = int.Parse(Console.ReadLine());
        List<int> currentLine = new List<int> {originalNumber};
        
        for (int i = 1; i < lineToDisplay; i++)
        {
            List<int> newLine = new List<int>();
            int countedNumber = 0;
            int count = 0;
            
            foreach(int number in currentLine)
            {
                if (number != countedNumber)
                {
                    if (count != 0)
                    {
                        newLine.Add(count);
                        newLine.Add(countedNumber);
                    }
                    
                    count = 1;
                    countedNumber = number;
                }
                else
                {
                    ++count;
                }
            }
            
            newLine.Add(count);
            newLine.Add(countedNumber);
            currentLine = newLine;
        }
        
        Console.WriteLine(String.Join(" ", currentLine.ToArray()));
    }
}
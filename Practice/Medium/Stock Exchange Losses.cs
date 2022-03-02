using System;

public class Solution
{
    public static void Main(string[] args)
    {
        int nValues = int.Parse(Console.ReadLine());
        string[] inputs = Console.ReadLine().Split(' ');
        int highestValue = int.MinValue;
        int greatestLoss = 0;
                
        for (int i = 0; i < nValues; i++)
        {
            int value = int.Parse(inputs[i]);
                        
            if (value > highestValue)
            {
                highestValue = value;
            }
            else if (value - highestValue < greatestLoss)
            {
                int loss = value - highestValue;
                
                if (loss < greatestLoss)
                {
                    greatestLoss = loss;
                }                
            }
        }

        Console.WriteLine(greatestLoss);
    }
}
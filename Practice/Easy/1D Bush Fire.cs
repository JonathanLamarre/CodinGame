using System;

public class Solution
{
    public static void Main(string[] args)
    {
        int numberOfTestCases = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfTestCases; i++)
        {
            string input = Console.ReadLine() + ".";
            int numberOfWaterDrop = 0;
            bool nextWasCovered = false;
            bool previousWasFire = false;

            foreach(char c in input)
            {
                if (nextWasCovered)
                {
                    nextWasCovered = false;
                }
                else if (previousWasFire)
                {
                    numberOfWaterDrop++;
                    nextWasCovered = true;
                    previousWasFire = false;
                }
                else if (c == 'f')
                {
                    previousWasFire = true;
                }
            }

            Console.WriteLine(numberOfWaterDrop);
        }
    }
}
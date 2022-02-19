using System;

public class Solution
{
    public static void Main(string[] args)
    {
        string N = Console.ReadLine();
        int lastNumberOfClumps = 1;

        for (int B = 2; B < 10; B++)
        {
            int numberOfClumps = 0;
            int lastModulo = -1;

            for (int i = 0; i < N.Length; i++)
            {
                int modulo = (N[i] - '0') % B;

                if (modulo != lastModulo)
                {
                    lastModulo = modulo;
                    numberOfClumps++;
                }
            }

            if (numberOfClumps < lastNumberOfClumps)
            {
                Console.WriteLine(B);

                return;
            }

            lastNumberOfClumps = numberOfClumps;
        }

        Console.WriteLine("Normal");
    }
}
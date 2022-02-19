using System;

public class Solution
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int tries = 0;
        int maxTries = N / 5;
        int scoreAfterTries = N;

        do
        {
            int transformations = 0;
            int maxTransformations = Math.Min(tries, scoreAfterTries / 2);
            int scoreAfterTransformations = scoreAfterTries;

            do
            {
                if (scoreAfterTransformations % 3 == 0)
                {
                    int penaltiesAndDrops = scoreAfterTransformations / 3;
                    Console.WriteLine(tries + " " + transformations + " " + penaltiesAndDrops);
                }

                transformations++;
                scoreAfterTransformations -= 2;
            }
            while (transformations <= maxTransformations);

            tries++;
            scoreAfterTries -= 5;
        }
        while (tries <= maxTries);
    }
}
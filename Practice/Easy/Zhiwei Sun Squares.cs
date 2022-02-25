using System;

public class Solution
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int squareRootOfN = (int)Math.Sqrt(n);
        int numberOfAnswers = 0;

        for (int a = 0; a <= squareRootOfN; a++)
        {
            int a2 = a * a;

            for (int b = 0; b <= squareRootOfN; b++)
            {
                int a2b2 = a2 + b * b;

                if (a2b2 > n) break;

                for (int c = 0; c <= squareRootOfN; c++)
                {
                    int a2b2c2 = a2b2 + c * c;

                    if (a2b2c2 > n) break;

                    for (int d = 0; d <= squareRootOfN; d++)
                    {
                        int a2b2c2d2 = a2b2c2 + d * d;

                        if (a2b2c2d2 > n) break;

                        if (a2b2c2d2 != n) continue;

                        int b3c5d = b + 3 * c + 5 * d;
                        int e = (int)Math.Sqrt(b3c5d);

                        if (b3c5d == e * e)
                        {
                            numberOfAnswers++;
                        }
                    }
                }
            }
        }

        Console.WriteLine(numberOfAnswers);
    }
}
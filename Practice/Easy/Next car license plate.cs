using System;

public class Solution
{
    private static void Main(string[] args)
    {
        (string x, int n) = (Console.ReadLine(), int.Parse(Console.ReadLine()));
        int nPlateValue = int.Parse(x.Substring(3, 3)) + GetLetterValue(x[8], 0) + GetLetterValue(x[7], 1) + GetLetterValue(x[1], 2) + GetLetterValue(x[0], 3) + n - 1;
        int letter0 = nPlateValue / ((int)Math.Pow(26, 3) * 999);
        int intermediateValue = nPlateValue % ((int)Math.Pow(26, 3) * 999);
        int letter1 = intermediateValue / ((int)Math.Pow(26, 2) * 999);
        intermediateValue = nPlateValue % ((int)Math.Pow(26, 2) * 999);
        int letter2 = intermediateValue / (26 * 999);
        intermediateValue = nPlateValue % (26 * 999);
        int letter3 = intermediateValue / 999;
        intermediateValue = nPlateValue % 999;
        Console.WriteLine($"{(char)(letter0 + 'A')}{(char)(letter1 + 'A')}-{intermediateValue + 1:000}-{(char)(letter2 + 'A')}{(char)(letter3 + 'A')}");
    }

    private static int GetLetterValue(char c, int order) => (c -'A') * (int)Math.Pow(26, order) * 999;
}
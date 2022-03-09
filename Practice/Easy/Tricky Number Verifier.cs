using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

public class Solution
{
    private static readonly int[] s_multipliers = new int[]{3, 7, 9, 0, 5, 8, 4, 2, 1, 6};

    public static void Main(string[] args)
    {
        int numberOfLines = int.Parse(Console.ReadLine());

        while (numberOfLines-- > 0)
        {
            Console.WriteLine(GetSinValidity(Console.ReadLine()));            
        }
    }

    private static string GetSinValidity(string sin)
    {
        if (!Regex.Match(sin, @"^[1-9]\d{9}$").Success) return "INVALID SYNTAX";
        
        if (!DateTime.TryParseExact(sin.Substring(4), "ddMMyy", null, DateTimeStyles.None, out _)) return "INVALID DATE";

        int GetCheckDigit() => s_multipliers.Zip(sin.Select(x => x - 48), (x, y) => x * y).Sum() % 11;
        int checkDigit = GetCheckDigit();

        if (checkDigit != 10 && int.Parse(sin.Substring(3, 1)) == checkDigit) return "OK";

        if (int.Parse(sin.Substring(3, 1)) != checkDigit && checkDigit % 11 != 10) return sin.Substring(0, 3) + checkDigit + sin.Substring(4);

        do
        {
            sin = (int.Parse(sin.Substring(0, 3)) + 1) + sin.Substring(3);
            checkDigit = GetCheckDigit();
        } while(checkDigit % 11 == 10);

        return sin.Substring(0, 3) + checkDigit + sin.Substring(4);
    }
}
using System;
using System.Text;

public class Solution
{
    public static void Main(string[] args)
    {
        int numberOfLines = int.Parse(Console.ReadLine());
        string line1 = string.Empty;
        string line2 = string.Empty;

        for (int i = 0; i < numberOfLines + 2; i++)
        {
            string line3 = i < numberOfLines ? Console.ReadLine() : string.Empty;
            var stringBuilder = new StringBuilder(line3 + new string(' ', Math.Max(line3.Length, Math.Max(line1.Length + 2, line2.Length + 1)) - line3.Length));

            for (int j = 0; j < line2.Length; j++)
            {
                if (line2[j] != ' ' && stringBuilder[j + 1] == ' ')
                {
                    stringBuilder[j + 1] = '-';
                }
            }

            for (int j = 0; j < line1.Length; j++)
            {
                if (line1[j] != ' ' && stringBuilder[j + 2] == ' ')
                {
                    stringBuilder[j + 2] = '`';
                }
            }

            Console.WriteLine(stringBuilder.ToString().TrimEnd());
            line1 = line2;
            line2 = line3;
        }
    }
}
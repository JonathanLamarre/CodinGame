using System;

public class Solution
{
    public static void Main(string[] args)
    {
        long encodedValue = long.Parse(Console.ReadLine());
        string alphabet = Console.ReadLine();
        string answer = string.Empty;

        while (encodedValue >= 0)
        {
            answer += alphabet[(int)(encodedValue % alphabet.Length)];
            encodedValue = encodedValue / alphabet.Length - 1;
        }

        Console.WriteLine(answer);
    }
}
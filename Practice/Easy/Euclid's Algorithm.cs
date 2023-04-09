using System;

public class Solution
{
    private static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        (int originalA, int originalB) = (int.Parse(inputs[0]), int.Parse(inputs[1]));
        int a = originalA;
        int b = originalB;
        int remainder = -1;

        while(remainder != 0)
        {
            remainder = a % b;
            Console.WriteLine($"{a}={b}*{a / b}+{remainder}");
            a = b;
            b = remainder;
        }

        Console.WriteLine($"GCD({originalA},{originalB})={a}");
    }
}
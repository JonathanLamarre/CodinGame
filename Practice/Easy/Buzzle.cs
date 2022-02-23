using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        (int n, int a, int b) = (int.Parse(inputs[0]), int.Parse(inputs[1]), int.Parse(inputs[2]));
        int k = int.Parse(Console.ReadLine());
        List<int> buzzleNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        int SumOfNumbers(int number)
        {
            if (number <= n) return 0;

            int sum = 0;

            while (number > 0)
            {
                sum += number % n;
                number /= n;
            }

            return sum;
        }

        bool IsLastDigitOrMultipleOfAnyBuzzleNumber(int numberToTest)
            => buzzleNumbers.Any(x => numberToTest % n == x || numberToTest % x == 0);

        bool IsBuzzle(int numberToTest)
        {
            while(numberToTest > 0)
            {
                if (IsLastDigitOrMultipleOfAnyBuzzleNumber(numberToTest)) return true;

                numberToTest = SumOfNumbers(numberToTest);
            }

            return false;
        }

        for (int i = a; i <= b; i++)
        {
            Console.WriteLine(IsBuzzle(i) ? "Buzzle" : i.ToString());
        }        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Solution
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            HashSet<string> happyNumbers = new HashSet<string>{"1"};
            HashSet<string> unhappyNumbers = new HashSet<string>();
            int N = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            for (int i = 0; i < N; i++)
            {
                HashSet<string> calculatedNumbers = new HashSet<string>();
                string initialNumber = Console.ReadLine() ?? throw new InvalidOperationException();
                string number = initialNumber;

                do
                {
                    calculatedNumbers.Add(number);
                    number = number.Select(x => int.Parse(x.ToString())).Select(x => x * x).Sum().ToString();
                } while (!calculatedNumbers.Contains(number) && !happyNumbers.Contains(number) && !unhappyNumbers.Contains(number));

                if (happyNumbers.Contains(number))
                {
                    happyNumbers.UnionWith(calculatedNumbers);
                    Console.WriteLine(initialNumber + " :)");
                }
                else
                {
                    unhappyNumbers.UnionWith(calculatedNumbers);
                    Console.WriteLine(initialNumber + " :(");
                }
            }
        }
    }
}
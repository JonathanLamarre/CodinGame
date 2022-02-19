using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Solution
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            for (int i = 0; i < n; i++)
            {
                int result = Regex
                    .Replace(Console.ReadLine() ?? throw new InvalidOperationException(), "[^0-9]", "")
                    .Select(t => t - '0')
                    .Select((number, j) => j % 2 == 0 ? number > 4 ? number * 2 - 9 : number * 2 : number)
                    .Sum();

                Console.WriteLine(result % 10 == 0 ? "YES" : "NO");
            }
        }
    }
}
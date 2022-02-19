using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        var invalidISBSNs = new List<string>();
        int N = int.Parse(Console.ReadLine());

        for (int i = 0; i < N; i++)
        {
            string isbn = Console.ReadLine();

            if
            (
                isbn.Length != 10 && isbn.Length != 13
                || isbn.Length == 10 && (isbn.Take(9).Any(c => c < '0' || c > '9') || !(isbn[9] == 'X' || isbn[9] >= '0' && isbn[9] <= '9'))
                || isbn.Length == 13 && isbn.Any(c => c < '0' || c > '9')
                || isbn.Length == 10 && (isbn.Take(9).Select((x, y) => (10 - y) * (x - '0')).Sum() % 11 + (isbn[9] == 'X' ? 10 : isbn[9] - '0')) % 11 != 0
                || isbn.Length == 13 && (isbn.Take(12).Select((x, y) => (y % 2 == 0 ? 1 : 3) * (x - '0')).Sum() % 10 + (isbn[12] - '0')) % 10 != 0
            )
            {
                invalidISBSNs.Add(isbn);
            }
        }

        Console.WriteLine(invalidISBSNs.Count + " invalid:" + Environment.NewLine + string.Join(Environment.NewLine, invalidISBSNs));
    }
}
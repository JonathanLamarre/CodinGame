using System;

public class Solution
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        (int, int) indexOfFirstKnownIndex = (-1, -1);
        int indexOfFirstFizz = -1;
        int indexOfSecondFizz = -1;
        int indexOfFirstBuzz = -1;
        int indexOfSecondBuzz = -1;

        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();

            if (line.Contains("Fizz") || line.Contains("Buzz"))
            {
                if (line.Contains("Fizz") && indexOfFirstFizz == -1)
                {
                    indexOfFirstFizz = i;
                }
                else if (line.Contains("Fizz") && indexOfSecondFizz == -1)
                {
                    indexOfSecondFizz = i;
                }

                if (line.Contains("Buzz") && indexOfFirstBuzz == -1)
                {
                    indexOfFirstBuzz = i;
                }
                else if (line.Contains("Buzz") && indexOfSecondBuzz == -1)
                {
                    indexOfSecondBuzz = i;
                }
            }
            else if (indexOfFirstKnownIndex.Item1 == -1)
            {
                indexOfFirstKnownIndex = (i, int.Parse(line));
            }

            if (indexOfSecondFizz != -1 && indexOfSecondBuzz != -1) break;
        }

        int GetNumberFromFirstIndex(int firstIndex) => indexOfFirstKnownIndex.Item2 + firstIndex - indexOfFirstKnownIndex.Item1;
        int fizz = indexOfSecondFizz != -1 ? indexOfSecondFizz - indexOfFirstFizz : GetNumberFromFirstIndex(indexOfFirstFizz);
        int buzz = indexOfSecondBuzz != -1 ? indexOfSecondBuzz - indexOfFirstBuzz : GetNumberFromFirstIndex(indexOfFirstBuzz);
        Console.WriteLine($"{fizz} {buzz}");
    }
}
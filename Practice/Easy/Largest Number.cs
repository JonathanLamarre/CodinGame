using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    // Quite complex, but can be easily modified for the general case of removing any number of characters
    // by changing the 2 of line 15 for the desired max, and optimal in term of processing time and memory
    // Also the function GetAllCombinationsOfNElements is easily reusable
    public static void Main(string[] args)
    {
        string number = Console.ReadLine();
        int divisor = int.Parse(Console.ReadLine());
        int parsedMaxDivisibleNumber = int.Parse(number) % divisor == 0 ? int.Parse(number) : 0;

        for (int numberOfCharsToRemove = 1; numberOfCharsToRemove <= 2 && numberOfCharsToRemove < number.Length; numberOfCharsToRemove++)
        {
            if (parsedMaxDivisibleNumber > 0) break;

            foreach(IEnumerable<int> indicesToRemove in GetAllCombinationsOfNElements(Enumerable.Range(0, number.Length), numberOfCharsToRemove))
            {
                string numberWithCharsRemoved = number;

                indicesToRemove
                    .Select((x, y) => (x, y))
                    .ToList()
                    .ForEach(x => numberWithCharsRemoved = numberWithCharsRemoved.Remove(x.x - x.y, 1));
                
                int parsedNumber = int.Parse(numberWithCharsRemoved);

                if (parsedNumber % divisor == 0 && parsedNumber > parsedMaxDivisibleNumber)
                {
                    parsedMaxDivisibleNumber = parsedNumber;
                }
            }
        }

        Console.WriteLine(parsedMaxDivisibleNumber);
    }
 
    private static IEnumerable<IEnumerable<T>> GetAllCombinationsOfNElements<T>(IEnumerable<T> elements, int N)
    {
        T[] elementsArray = elements.ToArray();

        if (N > elementsArray.Length) yield break;

        int[] indices = Enumerable.Range(0, N).ToArray();

        bool CalculateNextCombination()
        {
            bool isArrayModified = false;

            if (N <= 0) return false;

            for (int i = N - 1; i >= 0 && !isArrayModified; i--)
            {
                if (indices[i] < elementsArray.Length - 1 - (N - 1) + i)
                {
                    indices[i]++;

                    if (i < N - 1)
                    {
                        for (int j = i + 1; j < N; j++)
                        {
                            indices[j] = indices[j - 1] + 1;
                        }
                    }

                    isArrayModified = true;
                }
            }

            return isArrayModified;
        }

        do
        {
            yield return indices.Select(x => elementsArray[x]);
        } while (CalculateNextCombination());
    }
}
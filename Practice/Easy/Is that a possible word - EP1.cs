using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        Console.ReadLine();
        Console.ReadLine();

        Dictionary<(string, char), string> stateAndLetterToState = Enumerable
            .Range(0, int.Parse(Console.ReadLine()))
            .Select(_ => Console.ReadLine().Split(" "))
            .ToDictionary(x => (x[0], x[1].First()), x => x[2]);

        string startState = Console.ReadLine();
        HashSet<string> endStates = Console.ReadLine().Split(" ").ToHashSet();
        int numberOfWords = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfWords; i++)
        {
            string actualState = startState;
            string word = Console.ReadLine();
            bool isValid = true;

            foreach (char letter in word)
            {
                if (!stateAndLetterToState.TryGetValue((actualState, letter), out string newState))
                {
                    isValid = false;
                    break;
                }

                actualState = newState;
            }

            Console.WriteLine(isValid && endStates.Contains(actualState) ? "true" : "false");
        }
    }
}
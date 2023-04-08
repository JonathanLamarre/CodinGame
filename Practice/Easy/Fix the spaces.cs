using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;

public class Solution
{
    private static void Main(string[] args)
    {
        string original = Console.ReadLine();
        Dictionary<string, int> wordToCount = Console.ReadLine().Split(' ').GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        List<(ImmutableList<string> Solution, string Left, ImmutableDictionary<string, int> WordCount)> solutionLeftWordCounts = new() {(ImmutableList<string>.Empty, original, ImmutableDictionary<string, int>.Empty)};

        while(solutionLeftWordCounts.Any(x => x.Left.Length > 0))
        {
            List<(ImmutableList<string> Solution, string Left, ImmutableDictionary<string, int>)> newsolutionLeftWordCounts = new();

            foreach((ImmutableList<string> Solution, string Left, ImmutableDictionary<string, int> WordCount) solutionLeftWordCount in solutionLeftWordCounts)
            {
                if (solutionLeftWordCount.Left.Length == 0)
                {
                    newsolutionLeftWordCounts.Add(solutionLeftWordCount);

                    continue;
                }

                foreach(string word in wordToCount.Keys)
                {
                    if (solutionLeftWordCount.Left.StartsWith(word))
                    {
                        ImmutableDictionary<string, int> wordCount = solutionLeftWordCount.WordCount;

                        if (!wordCount.ContainsKey(word))
                        {
                            wordCount = wordCount.Add(word, 0);
                        }

                        if (wordCount[word] == wordToCount[word]) continue;
                        
                        ImmutableList<string> newSolution = solutionLeftWordCount.Solution.Add(word);
                        string newLeft = solutionLeftWordCount.Left.Remove(0, word.Length);
                        ImmutableDictionary<string, int> newWordCount = wordCount.SetItem(word, wordCount[word] + 1);
                        newsolutionLeftWordCounts.Add((newSolution, newLeft, newWordCount));
                    }
                }
            }

            solutionLeftWordCounts = newsolutionLeftWordCounts;
        }
        
        Console.WriteLine(solutionLeftWordCounts.Count == 1 ? string.Join(' ', solutionLeftWordCounts.Single().Solution) : "Unsolvable");
    }
}
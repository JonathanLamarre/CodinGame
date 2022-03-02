using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    private const int MAX_LETTER = 7;
    
    public static void Main(string[] args)
    {        
        Dictionary<char,int> lettersValue = new Dictionary<char,int>()
        {
            {'e', 1}, {'a', 1}, {'i', 1}, {'o', 1}, {'n', 1}, {'r', 1}, {'t', 1}, {'l', 1}, {'s', 1},
            {'u', 1}, {'d', 2}, {'g', 2}, {'b', 3}, {'c', 3}, {'m', 3}, {'p', 3}, {'f', 4}, {'h', 4},
            {'v', 4}, {'w', 4}, {'y', 4}, {'k', 5}, {'j', 8}, {'x', 8}, {'q', 10}, {'z', 10}
        };
        
        List<string> words = new List<string>();
        List<int> wordScores = new List<int>();
        
        for (int i = 0, nWords = int.Parse(Console.ReadLine()); i < nWords; i++)
        {
            string word = Console.ReadLine();
            
            if (word.Length > 0 && word.Length <= MAX_LETTER)
            {
                words.Add(word);
                int score = 0;
                
                foreach (char c in word)
                {
                    score += lettersValue[c];
                }
                
                wordScores.Add(score);
            }            
        }
        
        char[] sortedLetters = Console.ReadLine().ToArray();
        Array.Sort(sortedLetters);
        string highestScoringWord = string.Empty;
        int highestScore = 0;
        
        for (int i = 0; i < words.Count; i++)
        {
            if (wordScores[i] > highestScore && SubsetOf(words[i], sortedLetters))
            {
                highestScore = wordScores[i];
                highestScoringWord = words[i];
            }
        }

        Console.WriteLine(highestScoringWord);
    }
    
    private static bool SubsetOf(string word, char[] sortedLetters)
    {        
        char[] sortedWord = word.ToArray();
        Array.Sort(sortedWord);
        int i = 0;
        int j = 0;
        
        while(true)
        {
            if (i == sortedWord.Length) return true;
            if (j == sortedLetters.Length || sortedWord[i] < sortedLetters[j])  return false;
            if (sortedWord[i] == sortedLetters[j]) ++i;
            ++j;
        }
    }
}
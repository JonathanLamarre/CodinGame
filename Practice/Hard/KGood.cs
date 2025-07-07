using System;

// Optimized in time O(n) and space O(n) where n is the string to parse's length. 
public class Solution
{
	public static void Main(string[] args)
	{
		(string stringToParse, int maxUniqueCharsCount) = (Console.ReadLine(), int.Parse(Console.ReadLine()));
		int[] charFrequencies = new int[26];
		int leftIndex = 0, rightIndex = 0, longestKGoodSubstring = 0, uniqueCharsCount = 0, charFrequenciesFrequencyIndex = 0;

		while (rightIndex < stringToParse.Length)
		{
			charFrequenciesFrequencyIndex = stringToParse[rightIndex] - 'a';

            if (charFrequencies[charFrequenciesFrequencyIndex] == 0)
            {
                uniqueCharsCount++;
            }

            charFrequencies[charFrequenciesFrequencyIndex]++;
			rightIndex++;

			while (uniqueCharsCount > maxUniqueCharsCount)
			{
				charFrequenciesFrequencyIndex = stringToParse[leftIndex] - 'a';
				charFrequencies[charFrequenciesFrequencyIndex]--;

				if (charFrequencies[charFrequenciesFrequencyIndex] == 0)
                {
                    uniqueCharsCount--;
                }
					
				leftIndex++;
			}

			longestKGoodSubstring = Math.Max(longestKGoodSubstring, rightIndex - leftIndex);
		}

		Console.WriteLine(longestKGoodSubstring);
	}
}
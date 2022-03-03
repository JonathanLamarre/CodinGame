using System;

public class Solution
{
    // This solution does the strict minimum number of shuffles necessary
    public static void Main(string[] args)
    {
        uint n = uint.Parse(Console.ReadLine());
        string[] cards = Console.ReadLine().Split();
        uint numberOfShufflesNecessary = n % GetNumberOfShufflesBeforeRepetition((uint)cards.Length);

        while (numberOfShufflesNecessary-- > 0)
        {
            string[] shuffledCards = new string[cards.Length];
            int middle = (cards.Length + 1) / 2;

            for (int i = 0; i < middle; i++)
            {
                shuffledCards[2 * i] = cards[i];

                if (i + middle < cards.Length)
                {
                    shuffledCards[2 * i + 1] = cards[i + middle];
                }
            }

            cards = shuffledCards;
        }

        Console.WriteLine(string.Join(" ", cards));
    }

    // If n is the index of the sequence and m the element at the index n
    // this respects the sequence of least m > 0 such that 2n+1 divides 2^m-1
    private static uint GetNumberOfShufflesBeforeRepetition(uint numberOfCards)
    {
        uint n = (numberOfCards - 1) / 2;
        uint divisor = 2 * n + 1;
        uint m = 0;
        uint powOf2 = 1;

        while (true)
        {
            m++;
            powOf2 *= 2;

            if ((powOf2 - 1) % divisor == 0) return m;
        }
    }
}
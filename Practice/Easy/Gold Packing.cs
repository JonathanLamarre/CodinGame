using System;
using System.Linq;
using System.Collections.Immutable;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int targetLength = int.Parse(Console.ReadLine());
        int numberOfBars = int.Parse(Console.ReadLine());
        List<int> barsLenghts = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        barsLenghts.Sort();
        int greatestLength = 0;
        ImmutableList<int> answer = ImmutableList<int>.Empty;

        void Search(ImmutableList<int> actualList, int actualLength, int barIndex)
        {
            if (actualLength > targetLength) return;

            if (barIndex == numberOfBars)
            {
                if (actualLength > greatestLength)
                {
                    greatestLength = actualLength;
                    answer = actualList;
                }

                if (actualLength == greatestLength)
                {
                    if (actualList.Count < answer.Count)
                    {
                        answer = actualList;
                    }
                    else if (actualList.Count == answer.Count)
                    {
                        for (int i = 0; i < actualList.Count; i++)
                        {
                            if (actualList[i] < answer[i])
                            {
                                answer = actualList;

                                break;
                            }
                        }
                    }               
                }
            }
            else
            {
                Search(actualList, actualLength, barIndex + 1);
                Search(actualList.Add(barsLenghts[barIndex]), actualLength + barsLenghts[barIndex], barIndex + 1);
            }
        }

        Search(answer, greatestLength, 0);
        Console.WriteLine(string.Join(" ", answer));
    }
}
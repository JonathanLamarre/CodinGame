using System;

public class Solution
{
    public static void Main(string[] args)
    {
		int previousSequenceLength = 0;
		int sequenceLength = 0;
		int longestSequenceLength = 0;
		
        foreach (char c in Console.ReadLine() + "0")
        {
            Console.Error.WriteLine(c);

			if (c == '1')
			{
				sequenceLength++;
			}
			else if (sequenceLength != 0)
			{
				if (previousSequenceLength + sequenceLength > longestSequenceLength)
				{
					longestSequenceLength = previousSequenceLength + sequenceLength;
				}
				
				previousSequenceLength = sequenceLength;
				sequenceLength = 0;
			}
            else
            {
                previousSequenceLength = 0;
            }
        }
		
        Console.WriteLine(longestSequenceLength + 1);
    }
}
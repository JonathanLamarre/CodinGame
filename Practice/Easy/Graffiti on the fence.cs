using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int fenceLength = int.Parse(Console.ReadLine());
        int numberOfSections = int.Parse(Console.ReadLine());
		var sortedSections = new SortedDictionary<int, int>();
		
        for (int i = 0; i < numberOfSections; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int sectionStart = int.Parse(inputs[0]);
            int sectionEnd = int.Parse(inputs[1]);
			
			if (!sortedSections.ContainsKey(sectionStart) || sortedSections[sectionStart] < sectionEnd)
			{
				sortedSections[sectionStart] = sectionEnd;
			}			
        }
		
		int unpaintedStart = 0;
        int numberOfUnpaintedSecton = 0;
		
		foreach(int sectionStart in sortedSections.Keys)
		{
			if (sectionStart > unpaintedStart)
			{
				Console.WriteLine(unpaintedStart + " " + sectionStart);
                numberOfUnpaintedSecton++;
			}
			
			if (sortedSections[sectionStart] > unpaintedStart)
			{
				unpaintedStart = sortedSections[sectionStart];
			}
		}
		
		if (unpaintedStart != fenceLength)
		{
			Console.WriteLine(unpaintedStart + " " + fenceLength);
            numberOfUnpaintedSecton++;
		}

        if (numberOfUnpaintedSecton == 0)
        {
            Console.WriteLine("All painted");
        }
    }
}
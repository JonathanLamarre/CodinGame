using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int actualElement = int.Parse(Console.ReadLine());
        int elementPositionDesired = int.Parse(Console.ReadLine());
		var elementToLastTimeSeen = new Dictionary<int, int>() {[actualElement] = 1};

		for (int i = 1; i < elementPositionDesired; i++)
		{
            int newElement = elementToLastTimeSeen.ContainsKey(actualElement) ? i - elementToLastTimeSeen[actualElement] : 0;
            elementToLastTimeSeen[actualElement] = i;
            actualElement = newElement;
		}

        Console.WriteLine(actualElement);
    }
}
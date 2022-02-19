using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int numberOfResistor = int.Parse(Console.ReadLine());
        var resistorNameToResistance = new Dictionary<string, double>();
		
        for (int i = 0; i < numberOfResistor; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
			resistorNameToResistance.Add(inputs[0], double.Parse(inputs[1]));
        }
				
		var stack = new Stack();

        List<double> PopStackUntilEndChar(string endChar)
		{
			var resistances = new List<double>();
			
			do
			{
				object poppedElement = stack.Pop();
				
				if (Equals(poppedElement, endChar))
				{
					return resistances;
				}
				else if (Equals(typeof(double), poppedElement.GetType()))
				{
					resistances.Add((double)poppedElement);
				}
				else
				{
					resistances.Add(resistorNameToResistance[(string)poppedElement]);
				}				
			} while(true);
		}

		foreach(string word in Console.ReadLine().Split(' '))
		{
			if (Equals(word, ")"))
			{
				stack.Push(PopStackUntilEndChar("(").Sum());
			}
			else if (Equals(word, "]"))
			{
				stack.Push(1.0 / PopStackUntilEndChar("[").Select(x => 1.0 / x).Sum());
			}
			else
			{
				stack.Push(word);
			}
		}

        Console.WriteLine(Math.Round((double)stack.Pop(), 1).ToString("0.0"));
    }
}
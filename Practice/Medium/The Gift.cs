using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int nParticipants = int.Parse(Console.ReadLine());
        long cost = long.Parse(Console.ReadLine());
        long[] budgets = new long[nParticipants];
                
        for (int i = 0; i < nParticipants; i++)
        {
            budgets[i] = long.Parse(Console.ReadLine());
        }
                
        if (budgets.Sum() < cost)
        {
            Console.WriteLine("IMPOSSIBLE");
			
            return;
        }
        
        Array.Sort(budgets);

        for(int i = 0; i < nParticipants; i++)
        {
            long rest = cost / (nParticipants - i);
            
            if (budgets[i] <= rest)
            {
                cost -= budgets[i];
                Console.WriteLine(budgets[i]);
            }
            else
            {
                cost -= rest;
                Console.WriteLine(rest);
            }
        }
    }
}
using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        List<int> opponentBowls = Console.ReadLine().Split().Select(int.Parse).ToList();
        List<int> myBowls = Console.ReadLine().Split().Select(int.Parse).ToList();
        int bowlPlayed = int.Parse(Console.ReadLine());
        int numberOfGrainsToPlay = myBowls[bowlPlayed];
        myBowls[bowlPlayed] = 0;
        int indexOfMyBowlToPutGrainInto = bowlPlayed + 1;
        int indexOfOpponentBowlToPutGrainInto = 0;
        bool isPuttingGrainsIntoMyBowl = true;

        while(numberOfGrainsToPlay > 0)
        {
            if (indexOfMyBowlToPutGrainInto == 7)
            {
                isPuttingGrainsIntoMyBowl = false;
                indexOfMyBowlToPutGrainInto = 0;
            }
            else if (indexOfOpponentBowlToPutGrainInto == 6)
            {
                isPuttingGrainsIntoMyBowl = true;
                indexOfOpponentBowlToPutGrainInto = 0;
            }

            if (isPuttingGrainsIntoMyBowl)
            {
                myBowls[indexOfMyBowlToPutGrainInto++]++;
            }
            else
            {
                opponentBowls[indexOfOpponentBowlToPutGrainInto++]++;
            }

            numberOfGrainsToPlay--;
        }
        
        Console.WriteLine(string.Join(" ", opponentBowls.Take(6).Select(x => x.ToString())) + $" [{opponentBowls[6]}]");
        Console.WriteLine(string.Join(" ", myBowls.Take(6).Select(x => x.ToString())) + $" [{myBowls[6]}]");

        if (indexOfMyBowlToPutGrainInto == 7)
        {
            Console.WriteLine("REPLAY");
        }
    }
}
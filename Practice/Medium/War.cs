using System;
using System.Collections.Generic;

public class Solution
{
    private const int STAKE_SIZE = 3;
    
    private static Queue<int> player1 = new Queue<int>();
    private static Queue<int> player2 = new Queue<int>();
    
    public static void Main(string[] args)
    {                
        for (int i = 0, nCardsPlayer1 = int.Parse(Console.ReadLine()) ; i < nCardsPlayer1; i++)
        {
           player1.Enqueue(ConvertCardStringToInt(Console.ReadLine()));
        }        
        
        for (int i = 0, nCardsPlayer2 = int.Parse(Console.ReadLine()) ; i < nCardsPlayer2; i++)
        {
             player2.Enqueue(ConvertCardStringToInt(Console.ReadLine()));
        }

        string result;
        int round = 0;

        while(true)
        {            
            if (player1.Count == 0 || player2.Count == 0)
            {
                result = (player1.Count == 0 ? 2 : 1) + " " + round;
                break;
            }
            
            if (Battle(new List<int>(), new List<int>()))
            {
                result = "PAT";
                break;
            }
            
            ++round;
        }

        Console.WriteLine(result);
    }
    
    private static int ConvertCardStringToInt(string card)
    {
        if (card[0] == '1')  return 10;
        if (card[0] == 'J')  return 11;
        if (card[0] == 'Q')  return 12;
        if (card[0] == 'K')  return 13;
        if (card[0] == 'A')  return 14;
        return card[0] - '0';
    }
    
    private static bool Battle(List<int> stakePlayer1, List<int> stakePlayer2)
    {
        int cardPlayer1 = player1.Dequeue();
        int cardPlayer2 = player2.Dequeue();
        
        if (cardPlayer1 != cardPlayer2)
        {
            Queue<int> winningPlayer = cardPlayer1 > cardPlayer2 ? player1 : player2;
			
            foreach (int card in stakePlayer1)
			{
				winningPlayer.Enqueue(card);
			}
			
            winningPlayer.Enqueue(cardPlayer1);
			
            foreach (int card in stakePlayer2)
			{
				winningPlayer.Enqueue(card);
			}
			
            winningPlayer.Enqueue(cardPlayer2);
			
            return false;
        }
        else
        {
            if (player1.Count < 4 || player2.Count < 4) return true;
			
            stakePlayer1.Add(cardPlayer1);
			
            for (int i = 0; i < STAKE_SIZE; i++)
			{
				stakePlayer1.Add(player1.Dequeue());
			}
			
            stakePlayer2.Add(cardPlayer2);
			
            for (int i = 0; i < STAKE_SIZE; i++)
			{
				stakePlayer2.Add(player2.Dequeue());
			}
			
            return Battle(stakePlayer1, stakePlayer2);
        }            
    }
}
using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int numberOfPlayers = int.Parse(Console.ReadLine());
        var players = new List<Player>();

        for (int i = 0; i < numberOfPlayers; i++)
        {
            players.Add(new Player(Console.ReadLine()));
        }

        for (int i = 0; i < numberOfPlayers; i++)
        {
            string[] shoots = Console.ReadLine().Split(' ');
            int shotsInRound = 0;
            int successiveMissesInRound = 0;

            foreach(string shoot in shoots)
            {
                int scoreBefore = players[i].Score;
                shotsInRound++;

                if (shoot == "X")
                {
                    successiveMissesInRound++;

                    if (successiveMissesInRound == 1)
                    {
                        players[i].Score -= 20;
                    }
                    else if (successiveMissesInRound == 2)
                    {
                        players[i].Score -= 30;
                    }
                    else
                    {
                        players[i].Score = 0;
                    }
                }
                else
                {
                    players[i].Score += shoot.Split('*').Select(int.Parse).Aggregate(1, (x, y) => x * y);
                    successiveMissesInRound = 0;
                }

                if (players[i].Score == 101)
                {
                    players[i].Rounds++;

                    break;
                }

                if (shotsInRound == 3 || players[i].Score > 101)
                {
                    players[i].Rounds++;
                    shotsInRound = 0;
                    successiveMissesInRound = 0;

                    if (players[i].Score > 101)
                    {
                        players[i].Score = scoreBefore;
                    }
                }
            }
        }

        Console.WriteLine(players.OrderByDescending(x => x.Score).ThenBy(x => x.Rounds).First().Name);
    }

    private class Player
    {
        public string Name { get; }

        public int Rounds { get; set; }

        public int Score { get; set; }

        public Player(string name) => Name = name;
    }
}
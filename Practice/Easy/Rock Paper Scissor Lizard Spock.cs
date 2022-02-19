using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int numberOfPlayers = int.Parse(Console.ReadLine());
        var players = new List<Player>();

        for (int i = 0; i < numberOfPlayers; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int playerNumber = int.Parse(inputs[0]);
            string playerSign = inputs[1];
            players.Add(new Player(playerNumber, playerSign));
        }

        while(players.Count != 1)
        {
            players = CompeteRound(players);
        }

        Console.WriteLine(players[0].Number);
        Console.WriteLine(string.Join(" ", players[0].Opponents));
    }

    private static List<Player> CompeteRound(List<Player> players)
    {
        var winningPlayers = new List<Player>();

        for (int i = 0; i < players.Count; i += 2)
        {
            players[i].Opponents.Add(players[i + 1].Number);
            players[i + 1].Opponents.Add(players[i].Number);
            Player winningPlayer = EvaluateWinner(players[i], players[i + 1]);
            winningPlayers.Add(winningPlayer);
        }

        return winningPlayers;
    }

    private static Player EvaluateWinner(Player player1, Player player2)
    {
        if (DoesFirstSignWinsAgainstSecondSign(player1.Sign, player2.Sign)) return player1;

        if (DoesFirstSignWinsAgainstSecondSign(player2.Sign, player1.Sign)) return player2;

        return player1.Number < player2.Number ? player1 : player2;
    }

    public static bool DoesFirstSignWinsAgainstSecondSign(string sign1, string sign2) =>
        (sign1 == "C" && (sign2 == "P" || sign2 == "L"))
        || (sign1 == "P" && (sign2 == "R" || sign2 == "S"))
        || (sign1 == "R" && (sign2 == "L" || sign2 == "C"))
        || (sign1 == "L" && (sign2 == "S" || sign2 == "P"))
        || (sign1 == "S" && (sign2 == "C" || sign2 == "R"));

    private class Player
    {
        public int Number { get; }

        public string Sign { get; }

        public List<int> Opponents { get; } = new List<int>();

        public Player(int number, string sign)
        {
            Number = number;
            Sign = sign;
        }
    }
}
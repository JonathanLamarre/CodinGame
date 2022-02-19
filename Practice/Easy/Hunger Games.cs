using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int numberOfTributes = int.Parse(Console.ReadLine());
        var tributes = new Dictionary<string, Tribute>();

        for (int i = 0; i < numberOfTributes; i++)
        {
            string playerName = Console.ReadLine();
            tributes.Add(playerName, new Tribute(playerName));
        }

        int numberOfTurns = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfTurns; i++)
        {
            string[] roundInfos = Console.ReadLine().Split(new string[] { " killed " }, StringSplitOptions.None);
            string killer = roundInfos[0];
            string[] killeds = roundInfos[1].Split(new string[] { ", " }, StringSplitOptions.None);

            foreach(string killed in killeds)
            {
                tributes[killer].Killed.Add(killed);
                tributes[killed].Killer = killer;
            }
        }
        
        IEnumerable<string> answers = tributes
            .Values
            .OrderBy(x => x.Name)
            .Select
            (
                x =>
                    $"Name: {x.Name + Environment.NewLine}"
                    + $"Killed: { (x.Killed.Count == 0 ? "None" : string.Join(", ", x.Killed.OrderBy(y => y))) + Environment.NewLine}"
                    + $"Killer: {x.Killer}"
            );

        Console.WriteLine(string.Join(Environment.NewLine + Environment.NewLine, answers));
    }

    private class Tribute
    {
        public string Name { get; }

        public List<string> Killed { get; } = new List<string>();

        public string Killer { get; set; } = "Winner";

        public Tribute(string name) => Name = name;
    }
}
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int numberOfRoadPatternLines = int.Parse(Console.ReadLine());
        string[] input = Console.ReadLine().Split(";");
        int carPosition = int.Parse(input[0]) - 1;

        List<(int, char)> numberOfCommandsRepetionToCommands = input
            .Skip(1)
            .Select(x => (int.Parse(x[0..^1]), x[^1..][0]))
            .ToList();
            
        var numberOfPatternRepetitionToPattern = new List<(int, string)>();

        for (int i = 0; i < numberOfRoadPatternLines; i++)
        {
            input = Console.ReadLine().Split(";");
            numberOfPatternRepetitionToPattern.Add((int.Parse(input[0]), input[1]));
        }

        foreach ((int, char) tuple in numberOfCommandsRepetionToCommands)
        {
            (int numberOfCommandsRepetion, char command) = tuple;

            while (numberOfCommandsRepetion != 0)
            {
                (int numberOfPatternRepetition, string pattern) = numberOfPatternRepetitionToPattern.First();
                int numberOfLinesToWrite = Math.Min(numberOfCommandsRepetion, numberOfPatternRepetition);
                numberOfCommandsRepetion -= numberOfLinesToWrite;
                numberOfPatternRepetition -= numberOfLinesToWrite;

                for (int i = 0; i < numberOfLinesToWrite; i++)
                {
                    if (command == 'L')
                    {
                        carPosition--;
                    }
                    else if (command == 'R')
                    {
                        carPosition++;
                    }

                    var patternWithCar = new StringBuilder(pattern);
                    patternWithCar[carPosition] = '#';
                    Console.WriteLine(patternWithCar.ToString());
                }

                if (numberOfPatternRepetition == 0)
                {
                    numberOfPatternRepetitionToPattern.RemoveAt(0);
                }
                else
                {
                    numberOfPatternRepetitionToPattern[0] = (numberOfPatternRepetition, pattern);
                }
            }
        }
    }
}
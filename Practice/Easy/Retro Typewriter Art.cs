using System;

public class Solution
{
    private static void Main(string[] args)
    {
        string[] commands = Console.ReadLine().Split(' ');
        string line = string.Empty;

        foreach(string command in commands)
        {
            if (command == "nl")
            {
                Console.WriteLine(line);
                line = string.Empty;

                continue;
            }

            string parsedCommand = command;

            if (command.EndsWith("sp"))
            {
                parsedCommand = command.Remove(command.Length - 2) + " ";
            }
            else if (command.EndsWith("bS"))
            {
                parsedCommand = command.Remove(command.Length - 2) + "\\";
            }
            else if (command.EndsWith("sQ"))
            {
                parsedCommand = command.Remove(command.Length - 2) + "'";
            }
            
            line += new string(parsedCommand[parsedCommand.Length - 1], int.Parse(parsedCommand.Remove(parsedCommand.Length - 1)));
        }

        Console.WriteLine(line);
    }
}
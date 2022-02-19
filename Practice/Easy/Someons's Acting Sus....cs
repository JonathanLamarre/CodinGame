using System;

public class Solution
{
    public static void Main(string[] args)
    {
        int _ = int.Parse(Console.ReadLine());
        string layout = Console.ReadLine();
        int numberOfCrewmates = int.Parse(Console.ReadLine().Split(' ')[0]);

        for (int i = 0; i < numberOfCrewmates; i++)
        {
            string crewmate = Console.ReadLine().Trim('#');

            bool IsSus()
            {
                int freeSpaces = 0;

                for (int j = 1; j < crewmate.Length; j++)
                {
                    if (crewmate[j] == '#')
                    {
                        freeSpaces++;

                        continue;
                    }

                    int index = layout.IndexOf(crewmate[j]);
                    string window = string.Empty;
                    
                    for (int k = index - 1 - freeSpaces; k <= index + 1 + freeSpaces; k++)
                    {
                        window += layout[(k + layout.Length) % layout.Length];
                    }

                    if (!window.Contains(crewmate[j - 1 - freeSpaces])) return true;
                
                    freeSpaces = 0;
                }

                return false;
            }

            Console.WriteLine(IsSus() ? "SUS" : "NOT SUS");
        }
    }
}
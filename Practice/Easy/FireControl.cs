using System;
using System.Linq;

public class Solution
{
    public static void Main(string[] args)
    {
        string[] map = Enumerable.Repeat(0, 6).Select(_ => Console.ReadLine()).ToArray();
        int numberOfFire = 0;
        int numberOfCutTree = 0;

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if (map[i][j] != '*') continue;;

                numberOfFire++;

                for (int m = -2; m <= 2; m++)
                {
                    for (int n = -2; n <= 2; n++)
                    {
                        if (i + m < 0 || i + m >= 6 || j + n < 0 || j + n >= 6 || map[i + m][j + n] != '#') continue;

                        numberOfCutTree++;
                        char[] line = map[i + m].ToArray();
                        line[j + n] = '=';
                        map[i + m] = new string(line);
                    }
                }
            }
        }

        Console.WriteLine(numberOfFire == 0 ? "RELAX" : map.All(x => !x.Contains('#')) ? "JUST RUN" : numberOfCutTree.ToString());
    }
}
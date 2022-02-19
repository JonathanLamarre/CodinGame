using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        List<int> inputs = Console.ReadLine().Split().Select(int.Parse).ToList();
        (int W, int H, int T1, int T2, int T3) = (inputs[0], inputs[1], inputs[2], inputs[3], inputs[4]);
        var asteroidesInPicture1 = Enumerable.Repeat<(int, int)?>(null, 26).ToList();
        var asteroidesInPicture2 = Enumerable.Repeat<(int, int)?>(null, 26).ToList();

        for (int i = 0; i < H; i++)
        {
            string[] inputs2 = Console.ReadLine().Split(' ');

            for(int j = 0; j < W; j++)
            {
                if (inputs2[0][j] >= 65 && inputs2[0][j] <= 90)
                {
                    asteroidesInPicture1[inputs2[0][j] - 65] = (i, j);
                }

                if (inputs2[1][j] >= 65 && inputs2[1][j] <= 90)
                {
                    asteroidesInPicture2[inputs2[1][j] - 65] = (i, j);
                }
            }
        }

        List<char[]> pictureAtT3 = Enumerable.Repeat(0, H).Select(_ => Enumerable.Repeat('.', W).ToArray()).ToList();

        float timeFactor = ((float)(T2 - T1)) / (T3 - T2);

        for(int i = 25; i >= 0; i--)
        {
            if (asteroidesInPicture1[i] == null) continue;

            (int h1, int w1) = ((int, int))asteroidesInPicture1[i];
            (int h2, int w2) = ((int, int))asteroidesInPicture2[i];
            int h3 = (int)Math.Floor((h2 + (h2 - h1) / timeFactor));
            int w3 = (int)Math.Floor((w2 + (w2 - w1) / timeFactor));

            if (h3 < 0 || h3 >= H || w3 < 0 || w3 >= W) continue;

            pictureAtT3[h3][w3] = (char)(65 + i);
        }

        pictureAtT3.ForEach(x => Console.WriteLine(new string(x)));
    }
}
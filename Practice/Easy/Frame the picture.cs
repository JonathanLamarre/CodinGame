using System;
using System.Linq;

public class Solution
{
    public static void Main(string[] args)
    {
        string framePattern = Console.ReadLine() + " ";
        string[] inputs = Console.ReadLine().Split(' ');
        (int h, int w) = (int.Parse(inputs[0]), int.Parse(inputs[1]));
        string ReverseString(string stringToReverse) => new string(stringToReverse.Select(x => x).Reverse().ToArray());

        for (int i = 0; i < framePattern.Length; i++)
        {
            string substring = framePattern.Substring(0, i + 1);
            Console.WriteLine($"{substring}{new string(framePattern[i], w + 2 * (framePattern.Length - 1 - i))}{ReverseString(substring)}");
        }

        string reversedFramePattern = ReverseString(framePattern);

        for(int i = 0; i < h; i++)
        {
            string pictureLine = Console.ReadLine();
            Console.WriteLine($"{framePattern}{pictureLine}{new string(' ', w - pictureLine.Length)}{reversedFramePattern}");
        }

        for (int i = framePattern.Length - 1; i >= 0; i--)
        {
            string substring = framePattern.Substring(0, i + 1);
            Console.WriteLine($"{substring}{new string(framePattern[i], w + 2 * (framePattern.Length - 1 - i))}{ReverseString(substring)}");
        }
    }
}
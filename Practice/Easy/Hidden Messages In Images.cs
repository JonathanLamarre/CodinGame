using System;
using System.Linq;

public class Solution
{
    public static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        (int w, int h) = (int.Parse(inputs[0]), int.Parse(inputs[1]));
        string answer = string.Empty;
        string bits = string.Empty;

        for (int i = 0; i < h; i++)
        {
            bits += string.Join(string.Empty, Console.ReadLine().Split(' ').Select(x => (byte.Parse(x) & 1).ToString()));
        }

        for(int i = 0; i < bits.Length; i += 8)
        {
            answer += (char)Convert.ToByte(bits.Substring(i, 8), 2);
        }

        Console.WriteLine(answer);
    }
}
using System;
using System.Linq;

// Based on a solution from Yatech https://www.codingame.com/profile/6607a67d3d4a69320845f2b4ba04744e1843873
public class Solution
{
    public static void Main(string[] args)
    {
        int numberOfNames = int.Parse(Console.ReadLine());
        string[] names = Enumerable.Repeat(0, numberOfNames).Select(_ => Console.ReadLine()).OrderBy(x => x).ToArray();
        string name1 = names[numberOfNames / 2 - 1];
        string name2 = names[numberOfNames / 2];
        int minLength = Math.Min(name1.Length, name2.Length);
        int index = Enumerable.Range(0, minLength).First(i => i == minLength - 1 || name1[i] != name2[i]);
        Console.WriteLine(index == minLength - 1 ? name1 : $"{name1[..index]}{(char)(name1[index] + 1)}");       
    }
}
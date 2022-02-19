using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int V = int.Parse(Console.ReadLine());
        int M = int.Parse(Console.ReadLine());
        var nodeToParentAndDirection = new Dictionary<int, (int, string)>();

        for (int i = 0; i < M; i++)
        {
            List<int> inputs = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            (int P, int L, int R) = (inputs[0], inputs[1], inputs[2]);
            nodeToParentAndDirection.Add(L, (P, "Left"));
            nodeToParentAndDirection.Add(R, (P, "Right"));
        }

        if (!nodeToParentAndDirection.ContainsKey(V))
        {
            Console.WriteLine("Root");

            return;
        }

        var path = new List<string>();

        while(nodeToParentAndDirection.TryGetValue(V, out (int, string) tuple))
        {
            (int parentNode, string direction) = tuple;
            V = parentNode;
            path.Add(direction);
        }

        path.Reverse();
        Console.WriteLine(string.Join(" ", path));
    }
}
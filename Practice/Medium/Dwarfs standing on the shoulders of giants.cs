using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        Dictionary<int,Node> nodes = new Dictionary<int,Node>();
        
        for (int i = 0, nRelations = int.Parse(Console.ReadLine()); i < nRelations; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int x = int.Parse(inputs[0]);
            int y = int.Parse(inputs[1]);
            Node nodeX;
            Node nodeY;
            
            if (!nodes.TryGetValue(x, out nodeX))
            {
                nodeX = new Node();
                nodes[x] = nodeX;
            }
            
            if (!nodes.TryGetValue(y, out nodeY))
            {
                nodeY = new Node();
                nodes[y] = nodeY;
            }
            
            nodeY.AddParent(nodeX);
            nodeX.AddChild(nodeY);
        }

        Console.WriteLine(nodes.Values.Max(node => node.Weight));
    }
    
    private class Node
    {
        private List<Node> parents = new List<Node>();
        
        public int Weight {get; private set;} = 1;
        
        public void AddParent(Node node)
        {
            parents.Add(node);
        }
        
        public void AddChild(Node node)
        {
            NotifyWeight(node.Weight);
        }
        
        private void NotifyWeight(int childrenWeight)
        {
            if (childrenWeight + 1 > Weight)
            {
                Weight = childrenWeight + 1;
                
                foreach (Node node in parents)
                {
                    node.NotifyWeight(Weight);
                }
            }
        }
    }
}
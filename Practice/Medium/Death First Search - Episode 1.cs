using System;
using System.Collections.Generic;

public class Player
{
    private static Node[] nodes;
    
    public static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int nNodes = int.Parse(inputs[0]);
        int nLinks = int.Parse(inputs[1]);
        int nExits = int.Parse(inputs[2]);
        nodes = new Node[nNodes];
                    
        for (int i = 0; i < nNodes; i++)
        {
            nodes[i] = new Node(i);
        }

        for (int i = 0; i < nLinks; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int node1 = int.Parse(inputs[0]);
            int node2 = int.Parse(inputs[1]);
            nodes[node1].links.Add(node2);
            nodes[node2].links.Add(node1);
        }

        for (int i = 0; i < nExits; i++)
        {
            nodes[int.Parse(Console.ReadLine())].isExit = true;
        }

        while (true)
        {
            int skynetNode = int.Parse(Console.ReadLine());
            double maxWeight = -1;
            int nodeMaxWeight = -1;
            
            foreach (int node in nodes[skynetNode].links)
            {
                if (nodes[node].isExit)
                {
                    nodeMaxWeight = node;
					
                    break;
                }
                
                double weight = nodes[node].GetWeight(new HashSet<int> {skynetNode});
				
                if (weight > maxWeight)
                {
                    maxWeight = weight;
                    nodeMaxWeight = node;
                }
            }
            
			nodes[skynetNode].links.Remove(nodeMaxWeight);
			nodes[nodeMaxWeight].links.Remove(skynetNode);
			Console.WriteLine(skynetNode < nodeMaxWeight ? skynetNode + " " + nodeMaxWeight : nodeMaxWeight + " " + skynetNode);
        }
    }
    
    private class Node
    {
        public readonly int id;
        
        public bool isExit = false;
        public HashSet<int> links = new HashSet<int>();
        
        public Node(int id)
        {
            this.id = id;
        }
        
        public double GetWeight(HashSet<int> exploredNodes)
        {
            if (isExit) { return 1; }
            
            exploredNodes.Add(id);
            double weight = 0;
            
            foreach (int node in links)
            {
                if (!exploredNodes.Contains(node))
                {
                    weight += 0.5 * nodes[node].GetWeight(exploredNodes);
                }
            }
            
            return weight;
        }
    }
}
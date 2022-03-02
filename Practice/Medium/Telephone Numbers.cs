using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        Node node = new Node();
        
        for (int i = 0, nPhoneNumber = int.Parse(Console.ReadLine()); i < nPhoneNumber; i++)
        {
            string phoneNumber = Console.ReadLine();
            List<int> numbers = new List<int>();
            
            foreach (char number in phoneNumber)
            {
                numbers.Add(number - '0');
            }
            
            node.AddNumbers(numbers);
        }

        Console.WriteLine(node.Weight);
    }
    
    private class Node
    {
        private readonly bool isRoot;
        private readonly int content;
        private readonly List<Node> children = new List<Node>();
        
        public int Weight
        {
            get
            {
                int weightChildren = 0;
            
                foreach (Node node in children)
                {
                    weightChildren += node.Weight;
                }
                
                return weightChildren + (isRoot ? 0 : 1);
            }
        }
        
        public Node()
        {
            isRoot = true;
            content = 0;
        }
        
        private Node(List<int> numbers)
        {
            isRoot = false;
            content = numbers[0];
            numbers.RemoveAt(0);
            
            if (numbers.Count > 0)
            {
                children.Add(new Node(numbers));
            }
        }
        
        public void AddNumbers(List<int> numbers)
        {
            if (numbers.Count == 0) return;
            
            foreach (Node node in children)
            {
                if (node.content == numbers[0])
                {
                    numbers.RemoveAt(0);
                    node.AddNumbers(numbers);
                    return;
                }
            }
            
            children.Add(new Node(numbers));
        }        
    }
}
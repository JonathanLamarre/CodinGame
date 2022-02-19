using System;
using System.Collections.Generic;

namespace Solution
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            string expression = Console.ReadLine() ?? throw new InvalidOperationException();
            var stack = new Stack<char>();
            int parsedChars = 0;

            foreach (char c in expression)
            {
                if (c == ')')
                {
                    if (stack.Count == 0 || stack.Peek() != '(') break;

                    stack.Pop();
                }
                else if (c == ']')
                {
                    if (stack.Count == 0 || stack.Peek() != '[') break;

                    stack.Pop();
                }
                else if (c == '}')
                {
                    if (stack.Count == 0 || stack.Peek() != '{') break;
                    
                    stack.Pop();
                }
                else if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                
                parsedChars++;
            }

            Console.WriteLine(parsedChars == expression.Length && stack.Count == 0 ? "true" : "false");
        }
    }
}
using System;

namespace Solution
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            string operation = Console.ReadLine() ?? throw new InvalidOperationException();
            int pseudoRandomNumber = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            string rotor1 = Console.ReadLine() ?? throw new InvalidOperationException();
            string rotor2 = Console.ReadLine() ?? throw new InvalidOperationException();
            string rotor3 = Console.ReadLine() ?? throw new InvalidOperationException();
            string message = Console.ReadLine() ?? throw new InvalidOperationException();
            string result = string.Empty;

            if (operation.Equals("ENCODE"))
            {
                int shift = 0;

                foreach (char c in message)
                {
                    result += ((char)((c - 'A' + pseudoRandomNumber + shift++) % 26 + 'A')).ToString();
                }
                                
                result = Rotor(result, rotor1);                
                result = Rotor(result, rotor2);                
                result = Rotor(result, rotor3);
            }
            else
            {
                message = InvertRotor(message, rotor3);                
                message = InvertRotor(message, rotor2);                
                message = InvertRotor(message, rotor1);                                
                int shift = 0;

                foreach (char c in message)
                {
                    result += ((char)((c - 'A' + (26 - (pseudoRandomNumber + shift++) % 26)) % 26 + 'A')).ToString();
                }
            }

            Console.WriteLine(result);
        }

        private static string Rotor(string message, string rotor)
        {
            string result = string.Empty;

            foreach (char c in message)
            {
                result += rotor[c - 'A'].ToString();
            }

            return result;
        }

        private static string InvertRotor(string message, string rotor)
        {
            string result = string.Empty;

            foreach (var c in message)
            {
                result += ((char)('A' + rotor.IndexOf(c))).ToString();
            }

            return result;
        }
    }
}
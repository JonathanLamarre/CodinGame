using System;

public class Solution
{
    public static void Main(string[] args)
    {
        Console.ReadLine();
        string packet = Console.ReadLine();

        while(packet.Length != 0)
        {
            string opCode = packet.Substring(0, 3);
            string payloadLength = packet.Substring(3, 4);
            string payload = packet.Substring(7, Convert.ToInt32(payloadLength, 2));
            
            if (opCode == "101")
            {
                Console.Write($"001{payloadLength}{payload}");
            }

            packet = packet[(7 + payload.Length)..];
        }
    }
}
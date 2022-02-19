using System;

public class Solution
{    
    public static void Main(string[] args)
    {
        string message = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(message)) return;

        string convertedMessage = string.Empty;
        
        foreach(char c in message)
        {
            convertedMessage += Convert.ToString((int)c,2).PadLeft(7, '0');
        }

        char bit = convertedMessage[0];
        int nSequence = 1;
        string answer = string.Empty;
        
        for (int i = 1; i < convertedMessage.Length; i++)
        {   
            if (convertedMessage[i] != bit)
            {
                answer += buildSequence(bit, nSequence) + " ";
                bit = convertedMessage[i];
                nSequence = 1;
            }
            else
            {
                ++nSequence;
            }
        }
        
        answer += buildSequence(bit, nSequence);
        Console.WriteLine(answer);
    }
    
    private static string buildSequence(char bit, int n) => (bit == '1' ? "0" : "00")
        + " "
        + new String('0', n);
}
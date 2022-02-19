using System;

public class Solution
{
    public static void Main(string[] args)
    {
        int numberOfTransformations = int.Parse(Console.ReadLine());
        string message = Console.ReadLine();
        string transformedMessage = string.Empty;

        if (numberOfTransformations > 0)
        {
            int numberOfLoops = 0;
            int numberOfCharactersTakenAfterLoops = 0;

            while(numberOfCharactersTakenAfterLoops + numberOfLoops + 1 <= message.Length)
            {
                numberOfCharactersTakenAfterLoops += ++numberOfLoops;
            }

            bool takeFromEndOnFirstLoop = numberOfLoops % 2 == 1;
            int numberOfCharactersTakenBeforeFirstLoop = message.Length - numberOfCharactersTakenAfterLoops;

            for (int i = 0; i < numberOfTransformations; i++)
            {
                transformedMessage = string.Empty;
                bool takeFromEnd = takeFromEndOnFirstLoop;
                string substring = string.Empty;
                Decode(ref message, ref substring, numberOfCharactersTakenBeforeFirstLoop, !takeFromEnd);
                transformedMessage = substring + transformedMessage;

                for (int charactersTaken = numberOfLoops; message.Length != 0; charactersTaken--)
                {
                    Decode(ref message, ref substring, charactersTaken, takeFromEnd);
                    transformedMessage = substring + transformedMessage;
                    takeFromEnd = !takeFromEnd;
                }

                message = transformedMessage;
            }
        }
        else
        {
            for (int i = 0; i < -numberOfTransformations; i++)
            {
                transformedMessage = string.Empty;
                bool addAtEnd = true;

                for (int charactersTaken = 1; message.Length != 0; charactersTaken++)
                {
                    string substring = message.Substring(0, Math.Min(charactersTaken, message.Length));
                    message = message.Remove(0, substring.Length);
                    transformedMessage = addAtEnd ? transformedMessage += substring : substring + transformedMessage;
                    addAtEnd = !addAtEnd;
                }

                message = transformedMessage;
            }
        }

        Console.WriteLine(transformedMessage);
    }

    private static void Decode(ref string message, ref string substring, int charactersTaken, bool takeFromEnd)
    {
        if (takeFromEnd)
        {
            substring = message.Substring(message.Length - charactersTaken);
            message = message.Remove(message.Length - charactersTaken);
        }
        else
        {
            substring = message.Substring(0, charactersTaken);
            message = message.Remove(0, charactersTaken);
            
        }
    }
}
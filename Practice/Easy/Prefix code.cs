using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int numberOfAssociations = int.Parse(Console.ReadLine());
        var binaryCodeToChar = new Dictionary<string, char>();
        int maxLengthOfBinaryCode = 0;
        string binaryCode;

        for (int i = 0; i < numberOfAssociations; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            binaryCode = inputs[0];
            maxLengthOfBinaryCode = binaryCode.Length >  maxLengthOfBinaryCode ? binaryCode.Length : maxLengthOfBinaryCode;
            binaryCodeToChar.Add(binaryCode, (char)int.Parse(inputs[1]));
        }

        string encodedString = Console.ReadLine();
        string decodedString = string.Empty;
        binaryCode = string.Empty;

        for(int i = 0; i < encodedString.Length; i++)
        {
            binaryCode += encodedString[i];

            if (binaryCode.Length > maxLengthOfBinaryCode)
            {
                Console.WriteLine("DECODE FAIL AT INDEX " + (i - binaryCode.Length + 1));

                return;
            }

            if (!binaryCodeToChar.TryGetValue(binaryCode, out char decodedChar)) continue;

            decodedString += decodedChar;
            binaryCode = string.Empty;
        }

        Console.WriteLine(binaryCode.Length > 0 ? "DECODE FAIL AT INDEX " + (encodedString.Length - binaryCode.Length) : decodedString);
    }
}
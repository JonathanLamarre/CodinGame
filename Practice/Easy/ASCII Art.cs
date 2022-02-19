using System;

public class Solution
{
    public static void Main(string[] args)
    {
        int width = int.Parse(Console.ReadLine());
        int height = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();
        string[] rows = new string[height];
        
        for (int i = 0; i < height; i++)
        {
            rows[i] = Console.ReadLine();
        }
        
        string[] answer = new string[height];
        
        for (int i = 0; i < height; i++)
        {
            answer[i] = string.Empty;
        }
        
        for (int i = 0; i < text.Length; i++)
        {
            int intChar = char.ToUpper(text[i]);
            int letter = intChar >= 65 && intChar <= 90 ? intChar - 65 : 26;
                        
            for (int j = 0; j < height; j++)
            {
                answer[j] = answer[j] + rows[j].Substring(letter * width, width);
            }
        }
        
        foreach(string lineAnswer in answer)
        {
            Console.WriteLine(lineAnswer);
        }
    }
}
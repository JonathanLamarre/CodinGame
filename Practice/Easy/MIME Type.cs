using System;
using System.IO;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {        
        int nTableLines = int.Parse(Console.ReadLine());
        int nFiles = int.Parse(Console.ReadLine());
        Dictionary<string, string> extensionsMIME = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        
        for (int i = 0; i < nTableLines; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            extensionsMIME.Add("." + inputs[0], inputs[1]);
        }
        
        for (int i = 0; i < nFiles; i++)
        {
            string MIME;
            Console.WriteLine(extensionsMIME.TryGetValue(Path.GetExtension(Console.ReadLine()), out MIME) ? MIME : "UNKNOWN");
        }
    }
}
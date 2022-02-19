using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Solution
{
    public static void Main(string[] args)
    {
        string TEXT = new Regex("[^a-zA-Z]").Replace(Console.ReadLine(), "").ToLower();         

        string FindSecret(string secret)
        {
            if (secret.Length == 1)
            {
                if (!TEXT.Contains(secret)) return string.Empty;

                return secret.ToUpper();
            }

            var indexes = new List<int>();
            bool isSecretFound = false;

            for (int i = 0; i < TEXT.Length && !isSecretFound; i++)
            {
                for (int j = TEXT.Length - 1; j > i && !isSecretFound; j--)
                {   
                    if (TEXT[i] != secret[0] || TEXT[j] != secret[1]) continue;
                    
                    indexes.Add(i);
                    indexes.Add(j);
                    int distance = j - i;
                    isSecretFound = true;

                    for (int k = 2; k < secret.Length; k++)
                    {
                        int textIndex = i + k * distance;

                        if (textIndex >= TEXT.Length || TEXT[textIndex] != secret[k])
                        {
                            isSecretFound = false;
                            indexes.Clear();

                            break;
                        }

                        indexes.Add(textIndex);
                    }
                }
            }

            if (!isSecretFound) return string.Empty;

            var stringBuilder = new StringBuilder(TEXT.Substring(indexes[0], indexes.Last() - indexes[0] + 1));

            foreach(int index in indexes)
            {
                stringBuilder[index - indexes[0]] = (char)(TEXT[index] -32);
            }

            return stringBuilder.ToString();
        }

        string longestSecret = Enumerable
            .Range(0, int.Parse(Console.ReadLine()))
            .Select(_ => Console.ReadLine())
            .OrderByDescending(x => x.Length)
            .Select(FindSecret)
            .Where(x => x != string.Empty)
            .First();

        Console.WriteLine(longestSecret);
    }
}
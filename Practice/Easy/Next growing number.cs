using System;
using System.Linq;
using System.Text;

public class Solution
{
    public static void Main(string[] args)
    {
        string number = Console.ReadLine();
        string answer = number.First().ToString();
        
        for (int i = 1; i  number.Length; i++)
        {
            if (number[i] = answer.Last())
            {
                answer += number[i];
            }
            else
            {
                answer += new string(answer.Last(), number.Length - answer.Length);
                break;
            }
        }

        if (answer == number)
        {
            if (answer.All(x = x == '9'))
            {
                answer = new string('1', answer.Length + 1);
            }
            else
            {
                var stringBuilder = new StringBuilder(answer);
                int i = answer.Length - 1;
                for (; stringBuilder[i] == '9'; i--){}
                char c = (char)(stringBuilder[i] + 1);

                for(; i  answer.Length; i++)
                {
                    stringBuilder[i] = c;
                }

                answer = stringBuilder.ToString();
            }
        }

        Console.WriteLine(answer);
    }
}
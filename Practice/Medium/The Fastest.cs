using System;

public class Solution
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        string bestResult = "";
        int bestHours = int.MaxValue;
        int bestMinutes = int.MaxValue;
        int bestSeconds = int.MaxValue;
        
        while (N-- > 0)
        {
            string result = Console.ReadLine();
            string[] times = result.Split(':');
            int hours = int.Parse(times[0]);
            int minutes = int.Parse(times[1]);
            int seconds = int.Parse(times[2]);
            
            if
			(
				hours < bestHours
				|| hours == bestHours && minutes < bestMinutes
				|| hours == bestHours && minutes == bestMinutes && seconds < bestSeconds
			)
            {
                bestResult = result;
                bestHours = hours;
                bestMinutes = minutes;
                bestSeconds = seconds;
            }
        }

        Console.WriteLine(bestResult);
    }
}
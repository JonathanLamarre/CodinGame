using System;

namespace Solution
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            string[] beginDateSplitted = (Console.ReadLine() ?? throw new InvalidOperationException()).Split('.');
            var beginDateTime = new DateTime(int.Parse(beginDateSplitted[2]), int.Parse(beginDateSplitted[1]), int.Parse(beginDateSplitted[0]));
            string[] endDateSplitted = (Console.ReadLine() ?? throw new InvalidOperationException()).Split('.');
            var endDateTime = new DateTime(int.Parse(endDateSplitted[2]), int.Parse(endDateSplitted[1]), int.Parse(endDateSplitted[0]));
            int years = endDateTime.Year - beginDateTime.Year;

            years = years > 0 && (endDateTime.Month < beginDateTime.Month || endDateTime.Month == beginDateTime.Month && endDateTime.Day < beginDateTime.Day)
                ? years - 1
                : years;

            int months = Math.Abs(endDateTime.Year * 12 + (endDateTime.Month - 1) - (beginDateTime.Year * 12 + (beginDateTime.Month - 1)));
            months = (beginDateTime.AddMonths(months) > endDateTime || endDateTime.Day < beginDateTime.Day ? months - 1 : months) % 12;
            int days = (endDateTime - beginDateTime).Days;
            string y = years == 0 ? string.Empty : years + " year" + (years > 1 ? "s" : string.Empty) + ", ";
            string m = months == 0 ? string.Empty : months + " month" + (months > 1 ? "s" : string.Empty) + ", ";
            string d = "total " + days + " days";
            Console.WriteLine(y + m + d);
        }
    }
}
using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    private static readonly Dictionary<string, int> s_monthNameToMonthNumber = new Dictionary<string, int>
    {
        {"Jan", 0}, {"Feb", 1}, {"Mar", 2}, {"Apr", 3}, {"May", 4}, {"Jun", 5},
        {"Jul", 6}, {"Aug", 7}, {"Sep", 8}, {"Oct", 9}, {"Nov", 10}, {"Dec", 11}
    };

    private static readonly Dictionary<string, int> s_dayOfTheWeekNameToDayOfTheWeekNumber = new Dictionary<string, int>
    {
        {"Monday", 0}, {"Tuesday", 1}, {"Wednesday", 2}, {"Thursday", 3},
        {"Friday", 4}, {"Saturday", 5}, {"Sunday", 6}
    };

    private static readonly Dictionary<int, string> s_dayOfTheWeekNumberToDayOfTheWeekName = new Dictionary<int, string>
    {
        {0, "Monday"}, {1, "Tuesday"}, {2, "Wednesday"}, {3, "Thursday"},
        {4, "Friday"}, {5, "Saturday"}, {6, "Sunday"}
    };

    public static void Main(string[] args)
    {
        List<int> daysByMonths = new List<int> {31, 28 + int.Parse(Console.ReadLine()), 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
        string[] inputs = Console.ReadLine().Split(' ');
        int dayOfTheWeekNumber = s_dayOfTheWeekNameToDayOfTheWeekNumber[inputs[0]];
        int monthNumber = s_monthNameToMonthNumber[inputs[1]];
        int dayOfMonth = int.Parse(inputs[2]);
        inputs = Console.ReadLine().Split(' ');
        int targetMonthNumber = s_monthNameToMonthNumber[inputs[0]];
        int targetDayOfMonth = int.Parse(inputs[1]);

        int daysDifference = targetMonthNumber == monthNumber
            ? targetDayOfMonth - dayOfMonth
            : targetMonthNumber > monthNumber
                ? daysByMonths[monthNumber]
                    - dayOfMonth
                    + Enumerable.Range(monthNumber + 1, targetMonthNumber - monthNumber - 1).Select(x => daysByMonths[x]).Sum()
                    + targetDayOfMonth
                : targetDayOfMonth
                    - dayOfMonth
                    - Enumerable.Range(targetMonthNumber + 1, monthNumber - targetMonthNumber - 1).Select(x => daysByMonths[x]).Sum()
                    - daysByMonths[targetMonthNumber];
                    
        Console.WriteLine(s_dayOfTheWeekNumberToDayOfTheWeekName[((dayOfTheWeekNumber + daysDifference) % 7 + 7) % 7]);
    }
}
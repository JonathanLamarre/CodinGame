using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Solution
{
    public static void Main(string[] args)
    {
        string sqlQuery = Console.ReadLine();
        int numberOfRows = int.Parse(Console.ReadLine());
        string[] headers = Console.ReadLine().Split(" ");
        Dictionary<string, int> headerToIndex =  headers.Select((x, y) => (x, y)).ToDictionary(x => x.x, x => x.y);
        string regex = @"SELECT (?<Select>.*) FROM \w+(?: WHERE (?<WhereColumn>\w+) = (?<WhereValue>\w+))?(?: ORDER BY (?<OrderBy>\w*) (?<desAsc>ASC|DESC))?";
        Match match = Regex.Match(sqlQuery, regex);
        List<string[]> tableRows = new List<string[]>(numberOfRows);

        for (int i = 0; i < numberOfRows; i++)
        {
            string[] row = Console.ReadLine().Split();
            
            if (match.Groups["WhereColumn"].Success)
            {
                if (row[headerToIndex[match.Groups["WhereColumn"].Value]] == match.Groups["WhereValue"].Value)
                {
                    tableRows.Add(row);
                }
            }
            else
            {
                tableRows.Add(row);
            }           
        }

        int[] indexOfColumnsToSelect = match.Groups["Select"].Value == "*"
            ? Enumerable.Range(0, headerToIndex.Count).ToArray()
            : match.Groups["Select"].Value.Split(", ").Select(x => headerToIndex[x]).ToArray();

        if (match.Groups["OrderBy"].Success)
        {
            int sortColumnIndex = headerToIndex[match.Groups["OrderBy"].Value];
            
            int Compare(string x, string y) => float.TryParse(x, out float floatx) && float.TryParse(y, out float floaty)
                ? match.Groups["desAsc"].Value == "ASC" ? floatx.CompareTo(floaty) : floaty.CompareTo(floatx)
                : match.Groups["desAsc"].Value == "ASC" ? x.CompareTo(y) : y.CompareTo(x);            

            tableRows.Sort((x, y) => Compare(x[sortColumnIndex], y[sortColumnIndex]));
        }

        Console.WriteLine(string.Join(" ", indexOfColumnsToSelect.Select(x => headers[x])));
        tableRows.ForEach(x => Console.WriteLine(string.Join(" ", indexOfColumnsToSelect.Select(y => x[y]))));
    }
}
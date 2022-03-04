using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int numberOfMeasurements = int.Parse(Console.ReadLine().Split(' ')[1]);
        int[] maxClientsByService = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int[] actualNumberOfClients = new int[maxClientsByService.Length];

        int GetNumberOfServices(int index, int[] numberOfClients) => numberOfClients[index] / maxClientsByService[index]
            + (numberOfClients[index] % maxClientsByService[index] == 0 ? 0 : 1);

        while (numberOfMeasurements-- > 0)
        {
            int[] newNumberOfClients = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            
            IEnumerable<int> servicesToStartOrStop = actualNumberOfClients
                .Select((x, i) => GetNumberOfServices(i, newNumberOfClients) - GetNumberOfServices(i, actualNumberOfClients));
            
            Console.WriteLine(string.Join(" ", servicesToStartOrStop));
            actualNumberOfClients = newNumberOfClients;
        }
    }
}
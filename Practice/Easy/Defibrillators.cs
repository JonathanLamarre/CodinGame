using System;

public class Solution
{   
    public static void Main(string[] args)
    {
        double lonA = DegreeToRadian(ToDouble(Console.ReadLine()));
        double latA = DegreeToRadian(ToDouble(Console.ReadLine()));
        string nameClosest = string.Empty;
        double distanceClosest = double.MaxValue;
        
        for (int i = 0, nDefibrillator = int.Parse(Console.ReadLine()); i < nDefibrillator; i++)
        {
            string[] inputs = Console.ReadLine().Split(';');
            double lonB = DegreeToRadian(ToDouble(inputs[4]));
            double latB = DegreeToRadian(ToDouble(inputs[5]));
            double distance = Havresine(lonA, latA, lonB, latB);
            
            if (distance < distanceClosest)
            {
                nameClosest = inputs[1];
                distanceClosest = distance;
            }
        }

        Console.WriteLine(nameClosest);
    }
    
    private static double ToDouble(string input) => double.Parse(input.Replace(',', '.'));
    
    private static double DegreeToRadian(double angle) => Math.PI * angle / 180.0;
    
    private static double Havresine(double lonA, double latA, double lonB, double latB)
    {
        double x = (lonB - lonA) * Math.Cos((latA + latB) / 2);
        double y = latB - latA;

        return Math.Sqrt(x * x + y * y);
    }
}
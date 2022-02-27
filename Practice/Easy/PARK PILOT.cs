using System;

public class Solution
{
    public static void Main(string[] args)
    {
        int roadLength = int.Parse(Console.ReadLine());
        int vehicleLength = int.MaxValue;
        int indexOfFirstLeftFrontFreeSpaceFound = -1;
        int numberfConsecutiveFreeSpacesOnTheLeft = 0;
        int numberfConsecutiveFreeSpacesOnTheRight = 0;

        for (int i = 0; i < roadLength; i++)
        {
            string sensorData = Console.ReadLine();
            bool isFrontLeftFree = sensorData[0] == '0';
            bool isFrontRightFree = sensorData[1] == '0';
            bool isBackRightFree = sensorData[2] == '0';
            bool isBackLeftFree = sensorData[3] == '0';

            if (indexOfFirstLeftFrontFreeSpaceFound == -1 && isFrontLeftFree)
            {
                indexOfFirstLeftFrontFreeSpaceFound = i;
            }

            if (vehicleLength == int.MaxValue && isBackLeftFree)
            {
                vehicleLength = i - indexOfFirstLeftFrontFreeSpaceFound +1;
                Console.WriteLine(vehicleLength);
            }

            numberfConsecutiveFreeSpacesOnTheLeft = isFrontLeftFree ? numberfConsecutiveFreeSpacesOnTheLeft + 1 : 0;
            numberfConsecutiveFreeSpacesOnTheRight = isFrontRightFree ? numberfConsecutiveFreeSpacesOnTheRight + 1 : 0;
            
            if (numberfConsecutiveFreeSpacesOnTheLeft >= vehicleLength)
            {
                Console.WriteLine($"{i + vehicleLength - 1}L");
            }

            if (numberfConsecutiveFreeSpacesOnTheRight >= vehicleLength)
            {
                Console.WriteLine($"{i + vehicleLength - 1}R");
            }
        }
    }
}
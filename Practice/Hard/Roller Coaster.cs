using System;
using System.Collections.Generic;

namespace Solution
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine()?.Split(' ') ?? throw new ArgumentException();
            long numberOfPlaces = long.Parse(inputs[0]);
            long totalNumberOfRides = long.Parse(inputs[1]);
            long numberOfGroups = long.Parse(inputs[2]);
            List<long> groups = new List<long>();
            Dictionary<int, long> indexToMoneyForThisRide = new Dictionary<int, long>();
            Dictionary<int, int> indexToNextIndex = new Dictionary<int, int>();

            for (long i = 0; i < numberOfGroups; i++)
            {
                long groupSize = long.Parse(Console.ReadLine() ?? throw new ArgumentException());
                groups.Add(groupSize);
            }

            long money = 0;
            int actualIndexOfGroup = 0;

            for (long rideNumber = 0; rideNumber < totalNumberOfRides; rideNumber++)
            {
                if (indexToMoneyForThisRide.ContainsKey(actualIndexOfGroup))
                {
                    money += indexToMoneyForThisRide[actualIndexOfGroup];
                    actualIndexOfGroup = indexToNextIndex[actualIndexOfGroup];

                    continue;
                }

                int startingIndex = actualIndexOfGroup;
                long numberOfBoardedPeople = 0;

                do
                {
                    numberOfBoardedPeople += groups[actualIndexOfGroup];
                    money += groups[actualIndexOfGroup];
                    actualIndexOfGroup++;

                    if (actualIndexOfGroup == groups.Count)
					{
						actualIndexOfGroup = 0;
					}
                }
                while (actualIndexOfGroup != startingIndex && numberOfBoardedPeople + groups[actualIndexOfGroup] <= numberOfPlaces);

                indexToMoneyForThisRide[startingIndex] = numberOfBoardedPeople;
                indexToNextIndex[startingIndex] = actualIndexOfGroup;
            }

            Console.WriteLine(money);
        }
    }
}
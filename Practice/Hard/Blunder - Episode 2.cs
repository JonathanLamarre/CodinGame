using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    private static void Main(string[] args)
    {
        int ConvertToRoomNumber(string input) => int.TryParse(input, out int roomNumber)? roomNumber : -1;

        Dictionary<int, (int Cash, int Exit1, int Exit2)> roomToCashAndRooms = Enumerable
            .Repeat(0, int.Parse(Console.ReadLine()))
            .Select(_ => Console.ReadLine()
            .Split(' '))
            .ToDictionary(x => int.Parse(x[0]), x => (int.Parse(x[1]), ConvertToRoomNumber(x[2]), ConvertToRoomNumber(x[3])));

        Dictionary<int, int> roomToMaxCash = new();

        int GetMaxCash(int room)
        {
            if (room == -1) return 0;

            if (roomToMaxCash.TryGetValue(room, out int maxCash)) return maxCash;

            (int cash, int exit1, int exit2) = roomToCashAndRooms[room];
            maxCash = Math.Max(GetMaxCash(exit1), GetMaxCash(exit2)) + cash;
            roomToMaxCash[room] = maxCash;

            return maxCash;  
        }

        Console.WriteLine(GetMaxCash(0));
    }
}
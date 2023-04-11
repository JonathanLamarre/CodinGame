using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;

public class Solution
{
    private static void Main(string[] args)
    {
        int ConvertToRoomNumber(string input) => int.TryParse(input, out int roomNumber)
            ? roomNumber
            : -1;

        Dictionary<int, (int Cash, int Exit1, int Exit2)> roomToCashAndRooms = Enumerable
            .Repeat(0, int.Parse(Console.ReadLine()))
            .Select(_ => Console.ReadLine()
            .Split(' '))
            .ToDictionary(x => int.Parse(x[0]), x => (int.Parse(x[1]), ConvertToRoomNumber(x[2]), ConvertToRoomNumber(x[3])));

        Dictionary<int, Dictionary<ImmutableHashSet<int>, (bool, int)>> roomToPathToIsExitAndMaxCash = new();

        (bool IsExit, int Cash) GetIsExitMaxCash(int room, ImmutableHashSet<int> path)
        {
            if (room == -1) return (true, 0);

            if (!roomToPathToIsExitAndMaxCash.TryGetValue(room, out Dictionary<ImmutableHashSet<int>, (bool, int)> pathToIsExitAndMaxCash))
            {
                pathToIsExitAndMaxCash = new Dictionary<ImmutableHashSet<int>, (bool, int)>(new ImmutableHashSetEqualityComparer());
                roomToPathToIsExitAndMaxCash[room] = pathToIsExitAndMaxCash;
            }
            
            if (pathToIsExitAndMaxCash.TryGetValue(path, out (bool, int) isExitAndMaxCash)) return isExitAndMaxCash;
            
            if (path.Contains(room))
            {
                isExitAndMaxCash = (false, 0);
            }
            else
            {
                (int cash, int exit1, int exit2) = roomToCashAndRooms[room];
                path = path.Add(room);
                (bool isExit1, int cash1) = GetIsExitMaxCash(exit1, path);
                (bool isExit2, int cash2) = GetIsExitMaxCash(exit2, path);
                bool isExit = isExit1 || isExit2;
                int totalCash = isExit1 ? (isExit2 ? Math.Max(cash1, cash2) + cash : cash1 + cash) : (isExit2 ? cash2 + cash : 0);

                isExitAndMaxCash = (isExit, totalCash);
            }

            pathToIsExitAndMaxCash[path] = isExitAndMaxCash;

            return isExitAndMaxCash;
        }

        Console.WriteLine(GetIsExitMaxCash(0, ImmutableHashSet<int>.Empty).Cash);
    }

    public class ImmutableHashSetEqualityComparer : IEqualityComparer<ImmutableHashSet<int>>
    {
        public bool Equals(ImmutableHashSet<int> immutableHashSet1, ImmutableHashSet<int> immutableHashSet2)
        {
            if (immutableHashSet1 == null && immutableHashSet2 == null) return true;
            else if (immutableHashSet1 == null || immutableHashSet2 == null) return false;
            else return immutableHashSet1.SetEquals(immutableHashSet2);
        }

        public int GetHashCode(ImmutableHashSet<int> immutableHashSet) => immutableHashSet == null ? 0 : immutableHashSet.GetHashCode();
    }
}
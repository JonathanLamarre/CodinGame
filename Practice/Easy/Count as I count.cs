using System;
using System.Collections.Generic;

public class Solution
{
    private readonly static Dictionary<int, int> s_numberOfMissingPinsToPossibleCombinations = new Dictionary<int, int>
    {
        {1, 1}, {2, 3}, {3, 7}, {4, 17}, {5, 40}, {6, 88}, {7, 176}, {8, 320}, {9, 536}, {10, 840}, {11, 1248}, {12, 1776}, {13, 2438}, {14, 3250}, {15, 4220},
        {16, 5348}, {17, 6612}, {18, 7972}, {19, 9380}, {20, 10788}, {21, 12148}, {22, 13412}, {23, 14532}, {24, 15460}, {25, 16148}, {26, 16552}, {27, 16632},
        {28, 16376}, {29, 15808}, {30, 14976}, {31, 13928}, {32, 12712}, {33, 11376}, {34, 9968}, {35, 8536}, {36, 7128}, {37, 5792}, {38, 4576}, {39, 3520},
        {40, 2640}, {41, 1920}, {42, 1344}, {43, 896}, {44, 560}, {45, 320}, {46, 160}, {47, 64}, {48, 16}
    };

    public static void Main(string[] args)
    {
        int numberOfMissingPins = 50 - int.Parse(Console.ReadLine());
        Console.WriteLine(s_numberOfMissingPinsToPossibleCombinations.ContainsKey(numberOfMissingPins) ? s_numberOfMissingPinsToPossibleCombinations[numberOfMissingPins] : 0);
    }
}
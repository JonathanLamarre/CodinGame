using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        (int n, int m) = (int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
        Dictionary<string, List<bool>> inputSignals = new Dictionary<string, List<bool>>();
        string[] inputs;

        for (int i = 0; i < n; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            inputSignals[inputs[0]] = inputs[1].Select(x => x == '-').ToList();
        }

        for (int i = 0; i < m; i++)
        {
            inputs = Console.ReadLine().Split(' ');

            bool GetLogicGateResult(bool x, bool y)
            {
                if (inputs[1] == "AND") return x && y;
                if (inputs[1] == "OR") return x || y;
                if (inputs[1] == "XOR") return x ^ y;
                if (inputs[1] == "NAND") return !(x && y);
                if (inputs[1] == "NOR") return !(x || y);
                return !(x ^ y);
            }

            char[] outputSignal = inputSignals[inputs[2]]
                .Zip(inputSignals[inputs[3]], GetLogicGateResult)
                .Select(x => x ? '-' : '_')
                .ToArray();

            Console.WriteLine($"{inputs[0]} {new string(outputSignal)}");
        }
    }
}
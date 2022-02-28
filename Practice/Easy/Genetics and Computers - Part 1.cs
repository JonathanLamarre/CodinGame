using System;
using System.Linq;
using System.Collections.Generic;


public class Solution
{
    public static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        (string parent1, string parent2) = (inputs[0], inputs[1]);
        var seedGenotypeToCount = new Dictionary<string, int>();
        
        void AddToSeedGenotypeToCount(string genotype)
        {
            string orderedGenotype = string.Concat(genotype.OrderBy(x => x));
            seedGenotypeToCount.TryGetValue(orderedGenotype, out int count);
            seedGenotypeToCount[orderedGenotype] = count + 1;
        }

        AddToSeedGenotypeToCount($"{parent1[0]}{parent1[2]}{parent2[0]}{parent2[2]}");
        AddToSeedGenotypeToCount($"{parent1[0]}{parent1[2]}{parent2[0]}{parent2[3]}");
        AddToSeedGenotypeToCount($"{parent1[0]}{parent1[2]}{parent2[1]}{parent2[2]}");
        AddToSeedGenotypeToCount($"{parent1[0]}{parent1[2]}{parent2[1]}{parent2[3]}");
        AddToSeedGenotypeToCount($"{parent1[0]}{parent1[3]}{parent2[0]}{parent2[2]}");
        AddToSeedGenotypeToCount($"{parent1[0]}{parent1[3]}{parent2[0]}{parent2[3]}");
        AddToSeedGenotypeToCount($"{parent1[0]}{parent1[3]}{parent2[1]}{parent2[2]}");
        AddToSeedGenotypeToCount($"{parent1[0]}{parent1[3]}{parent2[1]}{parent2[3]}");
        AddToSeedGenotypeToCount($"{parent1[1]}{parent1[2]}{parent2[0]}{parent2[2]}");
        AddToSeedGenotypeToCount($"{parent1[1]}{parent1[2]}{parent2[0]}{parent2[3]}");
        AddToSeedGenotypeToCount($"{parent1[1]}{parent1[2]}{parent2[1]}{parent2[2]}");
        AddToSeedGenotypeToCount($"{parent1[1]}{parent1[2]}{parent2[1]}{parent2[3]}");
        AddToSeedGenotypeToCount($"{parent1[1]}{parent1[3]}{parent2[0]}{parent2[2]}");
        AddToSeedGenotypeToCount($"{parent1[1]}{parent1[3]}{parent2[0]}{parent2[3]}");
        AddToSeedGenotypeToCount($"{parent1[1]}{parent1[3]}{parent2[1]}{parent2[2]}");
        AddToSeedGenotypeToCount($"{parent1[1]}{parent1[3]}{parent2[1]}{parent2[3]}");

        IEnumerable<int> ratios = Console
            .ReadLine()
            .Split(':')
            .Select(x => string.Concat(x.OrderBy(x => x)))
            .Select(x => seedGenotypeToCount.ContainsKey(x) ? seedGenotypeToCount[x] : 0);

        int greatestCommonDivisor = ratios.Aggregate(FindGreatestCommonDivisor);
        Console.WriteLine($"{string.Join(":", ratios.Select(x => x / greatestCommonDivisor))}");
    }

    static int FindGreatestCommonDivisor(int a, int b) => b == 0 ? a : FindGreatestCommonDivisor(b, a % b);
}
using System;
using System.Linq;
using System.Collections.Generic;

class Solution
{
    private const string SOUTH = "SOUTH";
    private const string EAST = "EAST";
    private const string NORTH = "NORTH";
    private const string WEST = "WEST";
    
    private static int width = 0; 
    private static int height = 0;
    private static int x = 0;
    private static int y = 0;
    private static string actualDirection = SOUTH;
    private static string[] directionsPriorities = {SOUTH, EAST, NORTH, WEST};
    private static List<string> directions = new List<string>();
    private static bool isBreakerMode = false;
    private static List<Tuple<int, int>> teleporters = new List<Tuple<int, int>>();
    private static HashSet<int> previousStates = new HashSet<int>();
    private static char[,] map;
    
    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        height = int.Parse(inputs[0]);
        width = int.Parse(inputs[1]);
        map = new char[width,height];
                        
        for (int j = 0; j < height; j++)
        {
            string line =  Console.ReadLine();
                        
            for (int i = 0; i < line.Length; i++)
            {
                map[i,j] = line[i];
                
                if (line[i] == 'T')
                {
                    teleporters.Add(Tuple.Create(i,j));
                }
                
                if (line[i] == '@')
                {
                    x = i;
                    y = j;
                }
            }
        }
                
        while(true)
        {
            //The End
            if (map[x,y] == '$')
            {
                break;
            }
            
            //Loop check
            int state = getStateHash();
            
            if (previousStates.Contains(state))
            {
                directions.Clear();
                directions.Add("LOOP");
				
                break;
            }
            else
            {
                previousStates.Add(state);
            }
            
            //Path modifiers
            if (map[x,y] == 'S') {actualDirection = SOUTH;}
            if (map[x,y] == 'E') {actualDirection = EAST;}
            if (map[x,y] == 'N') {actualDirection = NORTH;}
            if (map[x,y] == 'W') {actualDirection = WEST;}
            
            //Inverter
            if (map[x,y] == 'I') {Array.Reverse(directionsPriorities);}
            
            //Beer
            if (map[x,y] == 'B') {isBreakerMode = !isBreakerMode;}
            
            //Breaking wall
            if (map[x,y] == 'X') {map[x,y] = ' ';}
            
            //Teleporters
            if (map[x,y] == 'T')
            {
                Tuple<int, int> otherTeleporter = teleporters.First(t => t.Item1 != x || t.Item2 != y);
                x = otherTeleporter.Item1;
                y = otherTeleporter.Item2;
            }
            
            //Deciding direction
            int nextX = 0;
            int nextY = 0;
            int indexOfDirectionsPriorities = 0;
            
            while(true)
            {
                if (actualDirection == SOUTH) {nextX = x; nextY = y + 1;}
                if (actualDirection == EAST) {nextX = x + 1; nextY = y;}
                if (actualDirection == NORTH) {nextX = x; nextY = y - 1;}
                if (actualDirection == WEST) {nextX = x - 1; nextY = y;}
                
                //Impassable
                if (map[nextX,nextY] == '#' || (map[nextX,nextY] == 'X' && !isBreakerMode))
                {
                    actualDirection = directionsPriorities[indexOfDirectionsPriorities];
                    indexOfDirectionsPriorities++;
                }
                else
                {                    
                    directions.Add(actualDirection);
                    x = nextX;
                    y = nextY;
					
                    break;
                }
            }
        }
        
        foreach(string direction in directions)
        {
            Console.WriteLine(direction);
        }
    }
    
    private static int getStateHash()
    {
        int hash = 17;
        
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                hash = hash * 31 + map[i, j];
            }
        }
                
        hash = hash * 31 + x;
        hash = hash * 31 + y;
        hash = hash * 31 + actualDirection.GetHashCode();
        hash = hash * 31 + directionsPriorities[0].GetHashCode();
        hash = hash * 31 + isBreakerMode.GetHashCode();
                
        return hash;
    }
}
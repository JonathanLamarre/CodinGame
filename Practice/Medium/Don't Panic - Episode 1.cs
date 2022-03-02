using System;

public class Player
{    
    public static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int nFloors = int.Parse(inputs[0]);
        int width = int.Parse(inputs[1]);
        int maxRounds = int.Parse(inputs[2]);
        int exitFloor = int.Parse(inputs[3]);
        int exitPosition = int.Parse(inputs[4]);
        int nClones = int.Parse(inputs[5]);
        int nAdditionalElevators = int.Parse(inputs[6]);
        int nElevators = int.Parse(inputs[7]);
        int[] floors = new int[nFloors];
        bool[] isSolvedFloor = new bool[nFloors];
                
        for (int i = 0; i < nElevators; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            floors[int.Parse(inputs[0])] = int.Parse(inputs[1]);
        }
        
        floors[exitFloor] = exitPosition;
        bool isWaitingToBlock = false;

        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int leadingCloneFloor = int.Parse(inputs[0]);
            int leadingClonePosition = int.Parse(inputs[1]);
            string leadingCloneDirection = inputs[2];
            string action;
            
            if (isWaitingToBlock)
            {
                action = "BLOCK";
                isWaitingToBlock = false;
            }
            else
            {
                action = "WAIT";
                                
                if
                (
                    (
						leadingCloneDirection == "LEFT" && leadingClonePosition < floors[leadingCloneFloor]
						|| leadingCloneDirection == "RIGHT" && leadingClonePosition > floors[leadingCloneFloor]
					)
                    && !isSolvedFloor[leadingCloneFloor]
                )
                {
                    isWaitingToBlock = true;
                    isSolvedFloor[leadingCloneFloor] = true;
                }
            }

            Console.WriteLine(action);
        }
    }
}
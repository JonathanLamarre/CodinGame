using System;

public class Solution
{
    public static void Main(string[] args)
    {
        int triangleSize = int.Parse(Console.ReadLine());
        int lengthOfLine = 3 + ((triangleSize - 1) * 4);

        for (int i = 0; i < triangleSize; i++)
        {
            int numberOfStars = 1 + (2 * i);
            int numberOfSpacesBefore = (lengthOfLine - numberOfStars) / 2;
            string spacesBefore = new string(' ', numberOfSpacesBefore);
            string line = spacesBefore +  new string('*', numberOfStars);
            
            if (i == 0)
            {
                line = '.' + line.Remove(0, 1);
            }

            Console.WriteLine(line);
        }

        for (int i = 0; i < triangleSize; i++)
        {
            int numberOfStars = 1 + (2 * i);
            string stars = new string('*', numberOfStars);
            int numberOfSpacesBefore = (lengthOfLine - (2 * numberOfStars)) / 4;
            string spacesBefore = new string(' ', numberOfSpacesBefore);
            int numberOfSpaceInMiddle = lengthOfLine - (2 * numberOfStars) - (2 * numberOfSpacesBefore);
            string spacesInMiddle = new string(' ', numberOfSpaceInMiddle);
            string line = spacesBefore + stars + spacesInMiddle + stars;
            Console.WriteLine(line);
        }       
    }
}
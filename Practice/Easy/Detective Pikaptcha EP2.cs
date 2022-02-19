using System.Text;

namespace Player
{
    using System;

    public class Player
    {
        public static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine()?.Split(' ');

            if (inputs == null) return;

            int width = int.Parse(inputs[0]);
            int height = int.Parse(inputs[1]);
            int[,] maze = new int[height, width];
            int startHeight = -1;
            int startWidth = -1;
            char orientation = '!';

            for (int i = 0; i < height; i++)
            {
                string line = Console.ReadLine();

                if (line == null) return;

                for (int j = 0; j < width; j++)
                {

                    if (line[j] == '0')
                    {
                        maze[i, j] = 0;
                    }
                    else if (line[j] == '<' || line[j] == '^' || line[j] == '>' || line[j] == 'v')
                    {
                        startHeight = i;
                        startWidth = j;
                        maze[i, j] = 0;
                        orientation = line[j];
                    }
                    else
                    {
                        maze[i, j] = -1;
                    }
                }
            }

            string sideToFollow = Console.ReadLine();
            int actualHeight = startHeight;
            int actualWidth = startWidth;

            if
            (
                (actualHeight == 0 || maze[actualHeight - 1, actualWidth] == -1)
                && (actualHeight == height - 1 || maze[actualHeight + 1, actualWidth] == -1)
                && (actualWidth == 0 || maze[actualHeight, actualWidth - 1] == -1)
                && (actualWidth == width - 1 || maze[actualHeight, actualWidth + 1] == -1)
            )
            {
                WriteResult(height, width, maze);

                return;
            }


            do
            {
                bool hasProgressed = false;

                do
                {
                    if (orientation == '<')
                    {
                        if (sideToFollow == "L" && actualHeight != height - 1 && maze[actualHeight + 1, actualWidth] != -1)
                        {
                            orientation = 'v';
                            ++actualHeight;
                            maze[actualHeight, actualWidth] = maze[actualHeight, actualWidth] + 1;
                            hasProgressed = true;
                        }
                        else if (sideToFollow == "R" && actualHeight != 0 && maze[actualHeight - 1, actualWidth] != -1)
                        {
                            orientation = '^';
                            --actualHeight;
                            maze[actualHeight, actualWidth] = maze[actualHeight, actualWidth] + 1;
                            hasProgressed = true;
                        }
                        else if (actualWidth == 0 || maze[actualHeight, actualWidth - 1] == -1)
                        {
                            orientation = sideToFollow == "L" ? '^' : 'v';
                        }
                        else
                        {
                            --actualWidth;
                            maze[actualHeight, actualWidth] = maze[actualHeight, actualWidth] + 1;
                            hasProgressed = true;
                        }
                    }
                    else if (orientation == '^')
                    {
                        if (sideToFollow == "L" && actualWidth != 0 && maze[actualHeight, actualWidth - 1] != -1)
                        {
                            orientation = '<';
                            --actualWidth;
                            maze[actualHeight, actualWidth] = maze[actualHeight, actualWidth] + 1;
                            hasProgressed = true;
                        }
                        else if (sideToFollow == "R" && actualWidth < width - 1 && maze[actualHeight, actualWidth + 1] != -1)
                        {
                            orientation = '>';
                            ++actualWidth;
                            maze[actualHeight, actualWidth] = maze[actualHeight, actualWidth] + 1;
                            hasProgressed = true;
                        }
                        else if (actualHeight == 0 || maze[actualHeight - 1, actualWidth] == -1)
                        {
                            orientation = sideToFollow == "L" ? '>' : '<';
                        }
                        else
                        {
                            --actualHeight;
                            maze[actualHeight, actualWidth] = maze[actualHeight, actualWidth] + 1;
                            hasProgressed = true;
                        }
                    }
                    else if (orientation == '>')
                    {
                        if (sideToFollow == "L" && actualHeight != 0 && maze[actualHeight - 1, actualWidth] != -1)
                        {
                            orientation = '^';
                            --actualHeight;
                            maze[actualHeight, actualWidth] = maze[actualHeight, actualWidth] + 1;
                            hasProgressed = true;
                        }
                        else if (sideToFollow == "R" && actualHeight != height - 1 && maze[actualHeight + 1, actualWidth] != -1)
                        {
                            orientation = 'v';
                            ++actualHeight;
                            maze[actualHeight, actualWidth] = maze[actualHeight, actualWidth] + 1;
                            hasProgressed = true;
                        }
                        else if (actualWidth == width - 1 || maze[actualHeight, actualWidth + 1] == -1)
                        {
                            orientation = sideToFollow == "L" ? 'v' : '^';
                        }
                        else
                        {
                            ++actualWidth;
                            maze[actualHeight, actualWidth] = maze[actualHeight, actualWidth] + 1;
                            hasProgressed = true;
                        }
                    }
                    else
                    {
                        if (sideToFollow == "L" && actualWidth != width - 1 && maze[actualHeight, actualWidth + 1] != -1)
                        {
                            orientation = '>';
                            ++actualWidth;
                            maze[actualHeight, actualWidth] = maze[actualHeight, actualWidth] + 1;
                            hasProgressed = true;
                        }
                        else if (sideToFollow == "R" && actualWidth != 0 && maze[actualHeight, actualWidth - 1] != -1)
                        {
                            orientation = '<';
                            --actualWidth;
                            maze[actualHeight, actualWidth] = maze[actualHeight, actualWidth] + 1;
                            hasProgressed = true;
                        }
                        else if (actualHeight == height - 1 || maze[actualHeight + 1, actualWidth] == -1)
                        {
                            orientation = sideToFollow == "L" ? '<' : '>';
                        }
                        else
                        {
                            ++actualHeight;
                            maze[actualHeight, actualWidth] = maze[actualHeight, actualWidth] + 1;
                            hasProgressed = true;
                        }
                    }
                } while (!hasProgressed);
            } while (actualHeight != startHeight || actualWidth != startWidth);

            WriteResult(height, width, maze);
        }
        
        public static void WriteResult(int height, int width, int[,] maze)
        {
            for (int i = 0; i < height; i++)
            {
                var stringBuilder = new StringBuilder();

                for (int j = 0; j < width; j++)
                {
                    stringBuilder.Append(maze[i, j] == -1 ? "#" : maze[i, j].ToString());
                }

                Console.WriteLine(stringBuilder.ToString());
            }
        }
    }
}

// Write an action using Console.WriteLine()
// To debug: Console.Error.WriteLine("Debug messages...");
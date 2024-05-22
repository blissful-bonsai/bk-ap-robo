namespace Robo
{
    internal class Program
    {
        static int[,] robots;
        static char[] directions; // to store the directions of each robot

        static int[,] grid;
        static int gridX;
        static int gridY;
        static int numberOfRobots;

        static void Main(string[] args)
        {
            createGrid();
            createRobots();
            moveRobots();
        }

        /// <summary>
        /// Here we create the grid, it has to be a rectangle
        /// </summary>
        static void createGrid()
        {
            Console.WriteLine("What are the grid dimensions?");
            Console.Write("X: ");
            gridX = int.Parse(Console.ReadLine());
            Console.Write("Y: ");
            gridY = int.Parse(Console.ReadLine());
            while (gridX == gridY)
            {
                Console.WriteLine("It's a rectangle, the sizes can't be equal to each other");
                Console.Write("X: ");
                gridX = int.Parse(Console.ReadLine());
                Console.Write("Y: ");
                gridY = int.Parse(Console.ReadLine());
            }
            grid = new int[gridX, gridY];
            Console.WriteLine($"The grid has a maximum coordinate of: {grid.Length}");
        }

        /// <summary>
        /// Here we create the robots, each robot is represented by a line.
        /// Each line has 3 columns: x, y, and x*y (coordinate)
        /// </summary>
        static void createRobots()
        {
            Console.WriteLine("How many robots do you want?");
            numberOfRobots = int.Parse(Console.ReadLine());
            robots = new int[numberOfRobots, 3]; // x, y, and x*y (coordinate)
            directions = new char[numberOfRobots]; // to store the direction of each robot

            for (int i = 0; i < numberOfRobots; i++)
            {
                while (true)
                {
                    Console.WriteLine($"Enter initial position and direction for robot {i + 1} (format: X Y D):");
                    string[] initialPosition = Console.ReadLine().Split(' ');

                    if (initialPosition.Length != 3)
                    {
                        Console.WriteLine("Invalid input format. Please use the format: X Y D");
                        continue;
                    }

                    if (!int.TryParse(initialPosition[0], out int x) || !int.TryParse(initialPosition[1], out int y) || !char.TryParse(initialPosition[2], out char direction))
                    {
                        Console.WriteLine("Invalid input values. X and Y must be integers, and D must be a character.");
                        continue;
                    }

                    direction = char.ToUpper(direction);

                    if (!IsWithinBounds(x, y))
                    {
                        Console.WriteLine("Position is out of bounds. Please enter a valid position.");
                        continue;
                    }

                    if (IsPositionOccupied(x, y))
                    {
                        Console.WriteLine("Position is already occupied. Please enter a different position.");
                        continue;
                    }

                    robots[i, 0] = x;
                    robots[i, 1] = y;
                    directions[i] = direction;

                    // Calculate coordinate value
                    robots[i, 2] = x * y;
                    Console.WriteLine($"Robot {i + 1} initialized at ({x}, {y}, {direction})");
                    break;
                }
            }
        }

        /// <summary>
        /// Move the robots based on the commands provided by the user
        /// </summary>
        static void moveRobots()
        {
            for (int i = 0; i < numberOfRobots; i++)
            {
                Console.WriteLine($"Enter commands for robot {i + 1} (format: E, D, M):");
                string commands = Console.ReadLine().ToUpper();

                foreach (char command in commands)
                {
                    switch (command)
                    {
                        case 'E':
                            TurnLeft(i);
                            break;
                        case 'D':
                            TurnRight(i);
                            break;
                        case 'M':
                            MoveForward(i);
                            break;
                    }
                }
                Console.WriteLine($"Final position of robot {i + 1}: {robots[i, 0]}, {robots[i, 1]}, {directions[i]}");
            }
        }

        static void TurnLeft(int robotIndex)
        {
            switch (directions[robotIndex])
            {
                case 'N':
                    directions[robotIndex] = 'W';
                    break;
                case 'W':
                    directions[robotIndex] = 'S';
                    break;
                case 'S':
                    directions[robotIndex] = 'E';
                    break;
                case 'E':
                    directions[robotIndex] = 'N';
                    break;
            }
        }

        static void TurnRight(int robotIndex)
        {
            switch (directions[robotIndex])
            {
                case 'N':
                    directions[robotIndex] = 'E';
                    break;
                case 'E':
                    directions[robotIndex] = 'S';
                    break;
                case 'S':
                    directions[robotIndex] = 'W';
                    break;
                case 'W':
                    directions[robotIndex] = 'N';
                    break;
            }
        }

        static void MoveForward(int robotIndex)
        {
            int newX = robots[robotIndex, 0];
            int newY = robots[robotIndex, 1];

            switch (directions[robotIndex])
            {
                case 'N':
                    newY++;
                    break;
                case 'E':
                    newX++;
                    break;
                case 'S':
                    newY--;
                    break;
                case 'W':
                    newX--;
                    break;
            }

            // Check if the new position is within bounds and not occupied
            if (IsWithinBounds(newX, newY) && !IsPositionOccupied(newX, newY))
            {
                robots[robotIndex, 0] = newX;
                robots[robotIndex, 1] = newY;
            }
            else
            {
                Console.WriteLine($"Robot {robotIndex + 1} cannot move to ({newX}, {newY}). Position is out of bounds or occupied.");
            }
        }

        static bool IsWithinBounds(int x, int y)
        {
            return x >= 0 && x < gridX && y >= 0 && y < gridY;
        }

        static bool IsPositionOccupied(int x, int y)
        {
            for (int i = 0; i < numberOfRobots; i++)
            {
                if (robots[i, 0] == x && robots[i, 1] == y)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

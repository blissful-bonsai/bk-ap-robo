// Create an array called robot, which has x, y and facing position elements

// Create a matrix called grid, populate it based on it's size

// Receive commands from the user and assign the final position to the robot!

// Seems pretty simple, but it's definitely not.

namespace Robo
{
    internal class Program
    {
        static int[,] grid;
        static int x = 0;
        static int y = 0;

        static int[] robot = new int[3];
        static int robotX = 0;
        static int robotY = 0;

        static void Main(string[] args)
        {
            createMatrix();
        }

        // This functions creates the grid the robot(s) is supposed to explore. Then it creates a robot(or more), sets it's initial coordinates and direction.
        static void createMatrix()
        {
            char robotDirection;
            Console.WriteLine("Now, we will specify the size of the grid");
            Console.WriteLine("Insert a first value and press enter. Then, insert another value and press enter again\n");
            while(x == y)
            {
                Console.WriteLine("The values can't be equal to each other, since the grid is rectangular");
                if (int.TryParse(Console.ReadLine(), out x))
                {
                    Console.WriteLine($"One of the sides measures {x}");
                }
                if (int.TryParse(Console.ReadLine(), out y))
                {
                    Console.WriteLine($"The second side measures {y}\n");
                }
            }
            grid = new int [x, y];
            int setter = 0;
            for(int i = 0; i < x; i++)
            {
                for(int j = 0; j < y; j++)
                {
                    grid[i, j] = setter;
                    setter = grid[i, j] + 1;
                }
            }
            Console.WriteLine($"The grid the robot will explore measures {grid.Length}\n");

            Console.WriteLine("Please specify the coordinates for the robot now: ");
            Console.WriteLine("X: ");
            robotX = int.Parse(Console.ReadLine());
            Console.WriteLine("Y: ");
            robotY = int.Parse(Console.ReadLine());
            if(validateRobot(robotX, robotY, x, y))
            {
                createRobot();
            }
        }

        static void createRobot()
        {
            robot[0] = robotX;
            robot[1] = robotY;
            Console.WriteLine("Which direction is the robot facing?: ");
            robot[2] = char.Parse(Console.ReadLine());
            Console.WriteLine($"The robot's coordinates are: {x},{y}, it's facing {(char)robot[2]}");
        }

        static bool validateRobot(int robotX, int robotY, int x, int y)
        {
            if(robotX > x)
            {
                return false;
            }
            if(robotY > y)
            {
                return false;
            }
            return true;
        }
    }
}
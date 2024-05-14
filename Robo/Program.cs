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
        static int robotCoordinateValue;

        static int directionIncrement = 90;
        static void Main(string[] args)
        {
            createMatrix();
            createRobot();
            showRobotInfo();
        }

        // This functions creates the grid the robot(s) is supposed to explore. Then it creates a robot(or more), sets it's initial coordinates and direction.
        static void createMatrix()
        {
            char robotDirection;
            Console.WriteLine("Now, we will specify the size of the grid");
            Console.WriteLine("Insert a first value and press enter. Then, insert another value and press enter again\n");
            while (x == y)
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
            grid = new int[x, y];
            int setter = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    grid[i, j] = setter;
                    setter = grid[i, j] + 1;
                }
            }
            Console.WriteLine($"The grid the robot will explore measures {grid.Length}\n");
            Console.WriteLine($"{grid[1, 1]}");
        }

        static void createRobot()
        {
            Console.WriteLine("Inform the x and y coordinates: ");
            robotX = int.Parse(Console.ReadLine());
            robotY = int.Parse(Console.ReadLine());
            Console.WriteLine("Which direction is the robot facing? East-E, North-N, West-W or South-S?");
            robot[2] = char.Parse(Console.ReadLine());
            if (robot[2] == 'E')
            {
                robot[2] = 0;
            }
            else if (robot[2] == 'N')
            {
                robot[2] = 90;
            }
            else if (robot[2] == 'W')
            {
                robot[2] = 180;
            }
            else
            {
                robot[2] = 270;
            }
            Console.WriteLine($"The robot is on the {robotX},{robotY} coordinate!");
            Console.WriteLine($"{grid[robotX, robotY]}");
            Console.WriteLine($"The robot is facing, numerically: {robot[2]}");
            receiveOrders();
        }

        static void receiveOrders()
        {
            char previousDirection = (char)robot[2];
            Console.WriteLine("L - Turn 90 degrees to the left. R - Turn 90 deegres to the right. M - Move one point forward on the grid");
            Console.WriteLine("Specify a list of movements like LRLRLRLRM, the robot will complete each of them in sequence");
            string movementList = Console.ReadLine();
            for (int i = 0; i < movementList.Length; i++)
            {
                char direction = movementList[i];
                switch (direction)
                {
                    case 'L':
                        turnLeft();
                        break;

                    case 'R':
                        turnRight();
                        break;

                    case 'M':
                        move();
                        break;
                }
            }
        }

        static void checkFullCircle()
        {
            if (robot[2] == 360)
            {
                robot[2] = 0;
            }
        }
        static void turnLeft()
        {
            robot[2] += directionIncrement;
            checkFullCircle();
        }

        static void turnRight()
        {
            robot[2] -= directionIncrement;
            if (robot[2] < 0)
            {
                robot[2] = 270;
            }
        }


        static void move()
        {
            switch (robot[2])
            {
                case 0: // East
                    robotX += 1;
                    break;

                case 90: // North
                    robotY += 1;
                    break;

                case 180:
                    robotX -= 1;
                    break;

                case 270:
                    robotY -= 1;
                    break;
            }
        }

        static void showRobotInfo()
        {
            Console.WriteLine($"{robotX}, {robotY}, {robot[2]}");
        }


    }
}
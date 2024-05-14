namespace Robo
{
    internal class Program
    {
        static int gridX, gridY;
        static int[,] grid;
        static int robotX, robotY, robotValue, robotAngleValue;

        // Direction logic, not necessary actually, gonna leave it here until I'm sure it's not needed
        static Dictionary<char, int> robotAngle = new Dictionary<char, int>()
        {
            {'E', 0},
            {'N', 90},
            {'W', 180},
            {'S', 270}
        };

        static void Main(string[] args)
        {
            defineGridSize();
            populateGrid();
            createRobot();
        }

        // Here, we ask for the grid size, since it's a rectangle, we need two different sizes.
        static void defineGridSize()
        {
            Console.WriteLine("Plese, specify a size for the grid, type a value, press enter, then type another value and press enter: ");
            gridX = int.Parse(Console.ReadLine());
            gridY = int.Parse(Console.ReadLine());
            while (checkGridValidity(gridX, gridY) != true)
            {
                Console.WriteLine("Since it's an rectangular area, the values cannot be equal to each other");
                gridX = int.Parse(Console.ReadLine());
                gridY = int.Parse(Console.ReadLine());
            }
            grid = new int[gridX, gridY];
        }

        // Used in defineGridSize() to check if the area is rectangular, takes two parameters, which are input from the user
        static bool checkGridValidity(int x, int y)
        {
            if (x == y)
            {
                return false;
            }
            return true;
        }

        // Two loops that we use to populate the array
        static void populateGrid()
        {
            int setter = 0;
            for (int i = 0; i < gridX; i++)
            {
                for (int j = 0; j < gridY; j++)
                {
                    grid[i, j] = setter;
                    setter++;
                }
            }
        }

        // Checks if the robot X coordinate is available
        static bool checkX(int x)
        {
            if (x > gridX)
            {
                Console.WriteLine("Please insert a valid value for the X coordinate, this value is higher than possible");
                return false;
            }
            return true;
        }

        // Checks if the Y coordinate for the robot is available
        static bool checkY(int y)
        {
            if (y > gridY)
            {
                Console.WriteLine("Please insert a valid value for the Y coordinate, this value is higher than possible");
                return false;
            }
            return true;
        }

        // This determines the INITIAL angle of the robot
        static bool determineAngle(char direction)
        {
            int numericUserInput;
            if (robotAngle.ContainsKey(direction))
            {
                numericUserInput = robotAngle[direction];
                Console.WriteLine("The angle is: " + numericUserInput);
                Console.WriteLine($"The robot is facing {robotAngle[direction]}");
                robotAngleValue = robotAngle[direction];
                Console.WriteLine($"The robot's angle value: {robotAngleValue}");
                return true;
            }
            return false;
        }

        static void createRobot()
        {
            Console.WriteLine("Write the initial coordinates of the robot: ");

            robotX = int.Parse(Console.ReadLine()) - 1;
            while (!checkX(robotX))
            {
                robotX = int.Parse(Console.ReadLine()) - 1;
            }

            robotY = int.Parse(Console.ReadLine()) - 1;
            while (!checkY(robotY))
            {
                robotY = int.Parse(Console.ReadLine()) - 1;
            }
            robotValue = grid[robotX, robotY];
            Console.WriteLine($"The robot is on the point {robotValue}");

            Console.WriteLine("Which direction is the robot facing? E, N, W, S");
            char userInput = char.Parse(Console.ReadLine());
            while (!determineAngle(userInput))
            {
                Console.WriteLine("Insert a valid direction");
                userInput = char.Parse(Console.ReadLine());
            }
        }

        static void increaseAngleValue()
        {
            robotAngleValue += 90;
            if (robotAngleValue == 360)
            {
                robotAngleValue = 0;
                Console.WriteLine(robotAngleValue);
            }
        }

        static void decreaseAngleValue()
        {
            robotAngleValue -= 90;
            if (robotAngleValue == 270)
            {
                robotAngleValue = 0;
                Console.WriteLine(robotAngleValue);
            }
        }

        //static void changeAngle()
        //{
        //    Console.WriteLine("The angle changes in increments of 90, specify a direction, right - R or left - L: ");
        //    char direction = char.Parse(Console.ReadLine());
        //    switch (direction)
        //    {
        //        case 'R':
        //            decreaseAngleValue();
        //            break;
        //        case 'L':
        //            increaseAngleValue();
        //            break;
        //    }
        //}

        static void moveRobot()
        {
            // Check dictionary value
            switch (robotAngleValue)
            {
                case 0:
                    robotY += 1;
                    break;

                case 90:

                    break;

                case 180:

                    break;

                case 270:

                    break;
            }
        }

        static void receiveInputs()
        {
            string userInput = Console.ReadLine();
            for (int i = 0; i <= userInput.Length; i++)
            {
                if (userInput[i] == 'M')
                {
                    moveRobot();
                }
                if (userInput[i] == 'R')
                {
                    decreaseAngleValue();
                }
                if (userInput[i] == 'L')
                {
                    increaseAngleValue();
                }
            }
        }
    }
}
// Create an array called robot, which has x, y and facing position elements

// Create a matrix called grid, populate it based on it's size

// Receive commands from the user and assign the final position to the robot!

// Seems pretty simple, but it's definitely not.

namespace Robo
{
    internal class Program
    {
        int[,] grid;

        static int[] robot = new int[3];

        static void Main(string[] args)
        {
            createMatrix();
        }

        static void createMatrix()
        {
            int x = 0;
            int y = 0;
            char robotDirection;

            Console.WriteLine("Now, we will specify the size of the grid\n");
            Console.WriteLine("Insert a first value and press enter. Then, insert another value and press enter again\n");

            while(x == y)
            {
                Console.WriteLine("The values can't be equal to each other, since the grid is rectangular");
                if (int.TryParse(Console.ReadLine(), out x))
                {
                    Console.WriteLine($"One of the sides measures {x}\n");
                }
                if (int.TryParse(Console.ReadLine(), out y))
                {
                    Console.WriteLine($"The second side measures {y}\n");
                }
            }
            Console.WriteLine("Please insert the the direction the robot is facing");
            Console.WriteLine("N - North\n E - East\n S - South\n W - West\n");
            robotDirection = char.Parse(Console.ReadLine());
            createRobot(x, y, robotDirection);
        }
       
        static void createRobot(int userInputOne, int userInputTwo, char userInputThree)
        {
            robot[0] = userInputOne; // First coordinate number
            robot[1] = userInputTwo; // Second coordinate number
            robot[2] = userInputThree; // Robot direction
            // Should we use userInputOne and Two as "global" variables?
        }
    }
}

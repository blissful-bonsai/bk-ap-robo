namespace Robo
{
    internal class Program
    {

        /// <summary>
        /// Each robot will be represented by a line
        /// Each robot will have 4 columns
        /// x, y, x*y (to represent the coordinate), and angle, which will be used to determine the moving direction
        /// </summary>
        static int[,] robots;

        static int[,] grid;
        static int gridX;
        static int gridY;


        static void Main(string[] args)
        {
            createGrid();
            createRobots();
        }

        /// <summary>
        /// Here we create the grid, it has to a rectangle
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
        }
        /// <summary>
        /// Here we create the robots, each robot is represented by a line.
        /// Each line has 4 columns: x, y, x*y and angle
        /// </summary>
        static void createRobots()
        {
            Console.WriteLine("How many robots do you want?");
            int numberOfRobots = int.Parse(Console.ReadLine());
            robots = new int[numberOfRobots, 4];
            //Console.WriteLine(robots.Length); // Testing purposes
        }


    }
}
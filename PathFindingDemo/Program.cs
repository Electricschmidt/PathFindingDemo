using System;

namespace PathFindingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathFinder = new PathFinder();
            
            Console.WriteLine("Please enter a width for the grid:");
            var widthInput = Console.ReadLine();
            int width;
            while(!int.TryParse(widthInput, out width))
            {
                Console.WriteLine("Please enter an integer value for the width.");
                widthInput = Console.ReadLine();
            }
            Console.WriteLine("Please enter a height for the grid:");
            
            var heightInput = Console.ReadLine();
            int height;
            while (!int.TryParse(heightInput, out height))
            {
                Console.WriteLine("Please enter an integer value for the height.");
                heightInput = Console.ReadLine();
            }
            var map = new Map(width, height);
            
            Console.WriteLine("Starting grid:");
            map.Draw();
            
            int[] start = new int[2] { -1, -1};

            while (start[0] < 0)
            {
                Console.WriteLine("Please enter the start X coordinate:");                
                var startXInput = Console.ReadLine();
                while(!int.TryParse(startXInput, out start[0]))
                {
                    Console.WriteLine("Please enter a positive integer value for the start Y coordinate.");
                    startXInput = Console.ReadLine();
                }
            }
            while (start[1] < 0)
            {
                Console.WriteLine("Please enter the start Y coordinate:");                
                var startYInput = Console.ReadLine();
                while(!int.TryParse(startYInput, out start[1]))
                {
                    Console.WriteLine("Please enter a positive integer value for the start Y coordinate.");
                    startYInput = Console.ReadLine();
                }
            }

            map.SetPoint(start[0], start[1], "A");
            map.Draw();

            int[] finish = new int[2] { -1, -1 };

            while (finish[0] < 0)
            {
                Console.WriteLine("Please enter the end X coordinate:");
                var finishXInput = Console.ReadLine();
                while (!int.TryParse(finishXInput, out finish[0]))
                {
                    Console.WriteLine("Please enter a positive integer value for the end Y coordinate.");
                    finishXInput = Console.ReadLine();
                }
            }
            while (finish[1] < 0)
            {
                Console.WriteLine("Please enter the endX Y coordinate:");
                var finishYInput = Console.ReadLine();
                while (!int.TryParse(finishYInput, out finish[1]))
                {
                    Console.WriteLine("Please enter a positive integer value for the end Y coordinate.");
                    finishYInput = Console.ReadLine();
                }
            }

            map.SetPoint(finish[0], finish[1], "B");
            map.Draw();

            Console.WriteLine("Enter the dimesions and position of an obstacle: ");
            var obstacle = Console.ReadLine().Split(",");

            map.AddObstacle((int.Parse(obstacle[0]), int.Parse(obstacle[1])), (int.Parse(obstacle[2]), int.Parse(obstacle[3])));

            map.Draw();
            var path = pathFinder.FindPath(map);
            map.DrawPath(path);
            Console.WriteLine("Path from A to B:");
            map.Draw();
        }
    }
}

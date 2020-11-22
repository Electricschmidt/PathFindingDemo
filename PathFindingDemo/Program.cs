using System;

namespace PathFindingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathFinder = new PathFinder();
            Console.WriteLine("Please enter a width for the grid:");
            var width = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter a height for the grid:");
            var height = int.Parse(Console.ReadLine());
            var map = new Map(width, height);
            Console.WriteLine("Starting grid:");
            map.Draw();
            Console.WriteLine("Please enter the starting coordinates:");
            var start = Console.ReadLine().Split(",");
            map.SetPoint(int.Parse(start[0]), int.Parse(start[1]), "A");

            Console.WriteLine("Please enter the finish coordinates:");
            var finish = Console.ReadLine().Split(",");
            map.SetPoint(int.Parse(finish[0]), int.Parse(finish[1]), "B");

            Console.WriteLine("Enter the dimesions and position of an obstacle:");
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PathFindingDemo
{
    public static class MapExtensions
    {
        public static (int, int) GetCoords(this Map map, string name)
        {
            var coords = (0, 0);
            for (int i = 0; i < map.Grid.GetLength(0); i++)
            {
                for (int j = 0; j < map.Grid.GetLength(1); j++)
                {
                    if (map.Grid[i, j] == name)
                    {
                        coords = (j, i);
                    }
                    else continue;
                }
            }
            return coords;
        }

        public static void AddObstacle(this Map map, (int, int) dimensions, (int, int) position)
        {
            for (int i = position.Item1; i < position.Item1 + dimensions.Item1; i++)
            {
                for (int j = position.Item2; j < position.Item2 + dimensions.Item2; j++)
                {
                    map.Grid[j, i] = "X";
                }
            }
        }

        public static void Draw(this Map map)
        {
            for (int i = 0; i < map.Grid.GetLength(0); i++)
            {
                for (int j = 0; j < map.Grid.GetLength(1); j++)
                {
                    if(map.Grid[i,j] == "\\" || map.Grid[i, j] == "-" || map.Grid[i, j] == "/" || map.Grid[i, j] == "|")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(map.Grid[i, j]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(map.Grid[i, j]);
                    }
                }
                Console.Write(Environment.NewLine);
            }
        }

        public static void SetPoint(this Map map, int x, int y, string label)
        {
            map.Grid[y, x] = label;
        }

        public static bool IsEmpty(this Map map, int x, int y)
        {
            if (map.Grid[y, x] == "+")
            {
                return true;
            }
            else return false;
        }
        
        public static bool IsPoint(this Map map, int x, int y, string name)
        {
            if (map.Grid[y, x] == name)
            {
                return true;
            }
            else return false;
        }

        public static void DrawPath(this Map map, List<(int, int)> path)
        {
            foreach (var nodePair in path.Pairwise())
            {
                if (map.IsEmpty(nodePair.Item2.Item1, nodePair.Item2.Item2))
                {
                    if((nodePair.Item1.Item1 < nodePair.Item2.Item1 && nodePair.Item1.Item2 < nodePair.Item2.Item2) ||
                        (nodePair.Item1.Item1 > nodePair.Item2.Item1 && nodePair.Item1.Item2 > nodePair.Item2.Item2))
                    {
                        map.Grid[nodePair.Item2.Item2, nodePair.Item2.Item1] = "\\";
                    }
                    if (nodePair.Item1.Item2 == nodePair.Item2.Item2)
                    {
                        map.Grid[nodePair.Item2.Item2, nodePair.Item2.Item1] = "-";
                    }
                    if ((nodePair.Item1.Item1 < nodePair.Item2.Item1 && nodePair.Item1.Item2 > nodePair.Item2.Item2) ||
                        (nodePair.Item1.Item1 > nodePair.Item2.Item1 && nodePair.Item1.Item2 < nodePair.Item2.Item2))
                    {
                        map.Grid[nodePair.Item2.Item2, nodePair.Item2.Item1] = "/";
                    }
                    if (nodePair.Item1.Item1 == nodePair.Item2.Item1)
                    {
                        map.Grid[nodePair.Item2.Item2, nodePair.Item2.Item1] = "|";
                    }
                }
            }
        }
    }
}

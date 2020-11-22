using System;
using System.Collections.Generic;
using System.Text;

namespace PathFindingDemo
{
     public class Map
    {
        public Map(int width, int height)
        {
            Grid = MakeGrid(width, height);
            Dimensions = (width, height);
        }
        
        public string[,] MakeGrid(int width, int height)
        {
            string[,] grid = new string[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    grid[i, j] = "+";
                }
            }
            return grid;
        }

        public string[,] Grid { get; set; }

        public (int, int) Dimensions { get; set; }

    }
}

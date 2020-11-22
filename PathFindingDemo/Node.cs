using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PathFindingDemo
{
    public class Node
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Cost { get; set; }
        public int Distance { get; set; }
        public int CostDistance => Cost + Distance;
        public Node Parent { get; set; }

        //The distance is essentially the estimated distance, ignoring walls to our target. 
        //So how many tiles left and right, up and down, ignoring walls, to get there. 
        public void SetDistance(int targetX, int targetY)
        {
            Distance = Math.Max(Math.Abs(targetX - X), Math.Abs(targetY - Y));
        }
    }
}

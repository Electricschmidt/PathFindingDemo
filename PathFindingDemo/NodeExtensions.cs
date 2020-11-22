using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PathFindingDemo
{
    public static class NodeExtensions
    {
        public static List<Node> GetNeighbours(this Node currentNode, Map map, Node targetNode)
        {
            var potentialNodes = new List<Node>
            {
                new Node { X = currentNode.X, Y = currentNode.Y - 1, Parent = currentNode, Cost = currentNode.Cost + 1 },
                new Node { X = currentNode.X, Y = currentNode.Y + 1, Parent = currentNode, Cost = currentNode.Cost + 1 },
                new Node { X = currentNode.X + 1, Y = currentNode.Y, Parent = currentNode, Cost = currentNode.Cost + 1 },
                new Node { X = currentNode.X - 1, Y = currentNode.Y, Parent = currentNode, Cost = currentNode.Cost + 1 },
                new Node { X = currentNode.X - 1, Y = currentNode.Y - 1, Parent = currentNode, Cost = currentNode.Cost + 1 },
                new Node { X = currentNode.X + 1, Y = currentNode.Y + 1, Parent = currentNode, Cost = currentNode.Cost + 1 },
                new Node { X = currentNode.X - 1, Y = currentNode.Y + 1, Parent = currentNode, Cost = currentNode.Cost + 1 },
                new Node { X = currentNode.X + 1, Y = currentNode.Y - 1, Parent = currentNode, Cost = currentNode.Cost + 1 },
            };

            potentialNodes.ForEach(node => node.SetDistance(targetNode.X, targetNode.Y));

            var maxX = map.Dimensions.Item1 - 1;
            var maxY = map.Dimensions.Item2 - 1;


            return potentialNodes
                        .Where(node => node.X >= 0 && node.X <= maxX)
                        .Where(node => node.Y >= 0 && node.Y <= maxY)
                        .Where(node => map.IsEmpty(node.X, node.Y) || map.IsPoint(node.X, node.Y, "B"))
                        .ToList();

        }
    }
}

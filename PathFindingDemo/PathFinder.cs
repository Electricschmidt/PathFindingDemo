using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PathFindingDemo
{
    class PathFinder
    {
        public List<(int, int)> FindPath(Map map)
        {
            var startNode = new Node();
            startNode.X = map.GetCoords("A").Item1;
            startNode.Y = map.GetCoords("A").Item2;

            var endNode = new Node();
            endNode.X = map.GetCoords("B").Item1;
            endNode.Y = map.GetCoords("B").Item2;

            startNode.SetDistance(endNode.X, endNode.Y);
            
            var openNodes = new List<Node>();
            openNodes.Add(startNode);
            var closedNodes = new List<Node>();

            while(openNodes.Any())
            {
                var currentNode = openNodes.OrderBy(x => x.CostDistance).First();
                Debug.Print((currentNode.X, currentNode.Y).ToString());
                if (currentNode.X == endNode.X && currentNode.Y == endNode.Y) //if we've reached the end node a path has been found.
                {
                    var node = currentNode;
                    var path = new List<(int, int)>();
                    while (true)
                    {
                        path.Add((node.X, node.Y));
                        node = node.Parent;
                        if (node == null)
                        {
                            ////Console.WriteLine("Path found!");
                            //foreach (var pathNode in path)
                            //{
                            //    Console.WriteLine(pathNode.ToString());
                            //}
                            return path;
                        }
                    }
                }
                
                closedNodes.Add(currentNode);
                openNodes.Remove(currentNode);

                var validNeighbourNodes = currentNode.GetNeighbours(map, endNode);

                foreach (var node in validNeighbourNodes)
                {
                    if (closedNodes.Any(x => x.X == node.X && x.Y == node.Y)) //Don't need to recheck node if it's already be looked at
                        continue;
                    if (openNodes.Any(x => x.X == node.X && x.Y == node.Y)) //After further evaluation one of the open nodes may be better
                    {
                        var currentBestNode = openNodes.First(x => x.X == node.X && x.Y == node.Y);
                        if (currentBestNode.CostDistance > currentNode.CostDistance)
                        {
                            openNodes.Remove(currentBestNode);
                            openNodes.Add(node);
                        }
                    }
                    else //this is a brand new node
                    {
                        openNodes.Add(node);
                    }
                }
            }
            return new List<(int, int)>();
        }


        
    }
}

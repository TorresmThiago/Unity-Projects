using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{

    private const int MOVE_STRAIGHT_COST = 10;
    private const int MOVE_DIAGONAL_COST = 14;

    private Grid<PathNode> grid;
    private List<PathNode> openList;
    private List<PathNode> closedList;

    public Pathfinding(int width, int height)
    {
        grid = new Grid<PathNode>(width, height, 1f, Vector3.zero, (Grid<PathNode> g, int x, int y) => new PathNode(g, x, y));
    }

    private List<PathNode> FindPath(int startX, int startY, int endX, int endY)
    {
        PathNode startNode = grid.GetValue(startX, startY);
        PathNode endNode = grid.GetValue(endX, endY);

        openList = new List<PathNode> { startNode };
        closedList = new List<PathNode>();

        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                PathNode node = grid.GetValue(x, y);
                node.gCost = int.MaxValue;
                node.CalculateFCost();
                node.parent = null;
                //node.hCost = GetDistance(node, endNode);
                //node.fCost = node.hCost + node.gCost;
            }
        }

        startNode.gCost = 0;
        startNode.hCost = CalculateDistanceCost(startNode, endNode);
        startNode.CalculateFCost();

        while (openList.Count > 0)
        {
            PathNode currentNode = GetLowestFCostNode(openList);
            if (currentNode == endNode)
            {
                return CalculatePath(endNode);
            }

            openList.Remove(currentNode);
            closedList.Add(currentNode);

            foreach (PathNode neighbour in GetNeighbourList(currentNode))
            {
                if (closedList.Contains(neighbour))
                {
                    continue;
                }

                if (!neighbour.isWalkable)
                {
                    closedList.Add(neighbour);
                    continue;
                }

                if (neighbour.gCost > currentNode.gCost + CalculateDistanceCost(currentNode, neighbour))
                {
                    neighbour.gCost = currentNode.gCost + CalculateDistanceCost(currentNode, neighbour);
                    neighbour.hCost = CalculateDistanceCost(neighbour, endNode);
                    neighbour.CalculateFCost();
                    neighbour.parent = currentNode;

                    if (!openList.Contains(neighbour))
                    {
                        openList.Add(neighbour);
                    }
                }
            }
        }

        return null;
    }

    private List<PathNode> GetNeighbourList(PathNode currentNode)
    {
        List<PathNode> neighbourList = new List<PathNode>();

        if (currentNode.x - 1 >= 0)
        {
            neighbourList.Add(grid.GetValue(currentNode.x - 1, currentNode.y));

            if (currentNode.y - 1 >= 0)
            {
                neighbourList.Add(grid.GetValue(currentNode.x - 1, currentNode.y - 1));
            }

            if (currentNode.y + 1 < grid.GetLength(1))
            {
                neighbourList.Add(grid.GetValue(currentNode.x - 1, currentNode.y + 1));
            }
        }

        if (currentNode.x + 1 < grid.GetLength(0))
        {
            neighbourList.Add(grid.GetValue(currentNode.x + 1, currentNode.y));

            if (currentNode.y - 1 >= 0)
            {
                neighbourList.Add(grid.GetValue(currentNode.x + 1, currentNode.y - 1));
            }

            if (currentNode.y + 1 < grid.GetLength(1))
            {
                neighbourList.Add(grid.GetValue(currentNode.x + 1, currentNode.y + 1));
            }
        }

        if (currentNode.y - 1 >= 0)
        {
            neighbourList.Add(grid.GetValue(currentNode.x, currentNode.y - 1));
        }

        if (currentNode.y + 1 < grid.GetLength(1))
        {
            neighbourList.Add(grid.GetValue(currentNode.x, currentNode.y + 1));
        }

        return neighbourList;
    }

    private List<PathNode> CalculatePath(PathNode endNode)
    {
        List<PathNode> path = new List<PathNode>();
        path.Add(endNode);
        PathNode currentNode = endNode;
        while (currentNode.parent != null)
        {
            path.Add(currentNode.parent);
            currentNode = currentNode.parent;
        }
        path.Reverse();
        return path;
    }

    private int CalculateDistanceCost(PathNode a, PathNode b)
    {
        int xDistance = Mathf.Abs(a.x - b.x);
        int yDistance = Mathf.Abs(a.y - b.y);

        int remaining = Mathf.Abs(xDistance - yDistance);

        return MOVE_STRAIGHT_COST * Mathf.Min(xDistance, yDistance) + MOVE_DIAGONAL_COST * remaining;
    }

    private PathNode GetLowestFCostNode(List<PathNode> pathNodeList)
    {
        PathNode lowest = pathNodeList[0];
        for (int i = 1; i < pathNodeList.Count; i++)
        {
            if (pathNodeList[i].fCost < lowest.fCost)
            {
                lowest = pathNodeList[i];
            }
        }
        return lowest;
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode
{

    private Grid<PathNode> grid;
    public int x, y;

    public int fCost, gCost, hCost;

    public PathNode parent;

    public PathNode(Grid<PathNode> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
    }

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }

    public override string ToString()
    {
        return x + ", " + y;
    }

}
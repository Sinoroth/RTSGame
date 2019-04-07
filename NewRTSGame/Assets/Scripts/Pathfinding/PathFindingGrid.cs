using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingGrid  {

    private PathfindingCell[][] pathfindingGrid;

    private int highestX, highestY;    

    public PathFindingGrid(int x, int y) {

        highestX = x;
        highestY = y;

        pathfindingGrid = new PathfindingCell[x][];

        for(int i = 0; i < x; ++i)
        {
            pathfindingGrid[i] = new PathfindingCell[y];
        }
    }

    internal void InitializeGrid()
    {
        pathfindingGrid = new PathfindingCell[highestX][];

        for (int i = 0; i < highestX; ++i)
        {
            pathfindingGrid[i] = new PathfindingCell[highestY];
            for(int j = 0; j < highestY;++j)
            {
                pathfindingGrid[i][j] = new PathfindingCell();
            }
        }

        for (int i = 0; i < highestX;++i) {
            for(int j = 0; j < highestY; ++j)
            {
                pathfindingGrid[i][j].InitializeValues();
            }
        }
    }

    internal void InitializeStartingCell(int i,int j)
    {
        pathfindingGrid[i][j].SetValueForCell(i, j, 0, 0, 0);
    }

    internal double GetG(int v, int j)
    {
        return pathfindingGrid[v][j].GetG();
    }

    internal bool CanAdd(int v, int j, double fNew)
    {
        if(pathfindingGrid[v][j].IsNewFGreater(fNew))
        {
            return true;
        }
        return false;
    }

    internal void UpdateValue(int x, int y, double gNew, double hNew, double fNew, int i, int j)
    {
        pathfindingGrid[x][y].UpdateValues(gNew, hNew, fNew, i, j);
    }

    internal void UpdateParent(int neighborI, int neighborJ, int i, int j)
    {
        pathfindingGrid[neighborI][neighborJ].UpdateParents(i, j);
    }

    internal bool HasNoParents(int coorI, int coorJ, int parentI, int parentJ)
    {
        if (coorI == -1 || coorJ == -1) return true;
        return pathfindingGrid[coorI][coorJ].HasNoParents(parentI, parentJ);
    }

    internal int GetIParent(int i, int j)
    {
        return pathfindingGrid[i][j].GetIParent();
    }

    internal int GetjParent(int i, int j)
    {
        return pathfindingGrid[i][j].GetJParent();
    }

    internal void SetMaxCoordinates(int highestX, int highestY)
    {
        this.highestX = highestX;
        this.highestY = highestY;
    }
}

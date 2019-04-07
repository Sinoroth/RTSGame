using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathFinding : MonoBehaviour {

    /* 
        Generating all the 8 successor of this cell 
  
            N.W   N   N.E 
              \   |   / 
               \  |  / 
            W----Cell----E 
                / | \ 
               /  |  \ 
            S.W   S   S.E 
  
        Cell-->Popped Cell (i, j) 
        N -->  North       (i-1, j) 
        S -->  South       (i+1, j) 
        E -->  East        (i, j+1) 
        W -->  West           (i, j-1) 
        N.E--> North-East  (i-1, j+1) 
        N.W--> North-West  (i-1, j-1) 
        S.E--> South-East  (i+1, j+1) 
        S.W--> South-West  (i+1, j-1)
    */
    public Material start, path, end;

    WorldCoordinates startPosition, endPosition;

    private PathFindingGrid pfGrid;

    public PathFinding()
    {
        startPosition = new WorldCoordinates();
        endPosition = new WorldCoordinates();
    }

    int count = 0;

    public Stack<Pair<int, int>> PerformPathFinding()
    {
        #region Variables initialization
        int i, j;

        int highestX = RTS.PathFindingHelper.maxWidth;
        int highestY = RTS.PathFindingHelper.maxHeight;

        GameGrid grid = RTS.PathFindingHelper.grid;

        Debug.Log("HIghest are " + highestX + " " + highestY);
        Debug.Log("Start coord are " + startPosition.X + " " + startPosition.Y);
        Debug.Log("End coord are " + endPosition.X + " " + endPosition.Y);

        bool[][] closedList = new bool[highestX][];

        for (i = 0; i < highestX; ++i)
        {
            closedList[i] = new bool[highestY];
            for (j = 0; j < highestY; ++j)
            {
                closedList[i][j] = false;
            }
        }

        SortedSet<Pair<int, int>> openList = new SortedSet<Pair<int, int>>();

        Pair<int, int> startingGrid = new Pair<int, int>();
        startingGrid.SetValues(startPosition.X, startPosition.Y);

        openList.Add(0.0, startingGrid);

        pfGrid = new PathFindingGrid(RTS.PathFindingHelper.maxWidth, RTS.PathFindingHelper.maxHeight);

        pfGrid.InitializeGrid();

        pfGrid.InitializeStartingCell(startPosition.X, startPosition.Y);
        Stack<Pair<int, int>> emptyPath = new Stack<Pair<int, int>>();

        //if (count == 1) return emptyPath;

        #endregion
        while (openList.IsNotEmpty())
        {
            Pair<double, Pair<int, int>> currentCell = openList.GetFirstElement();

            openList.RemoveElement(currentCell.First, currentCell.Second);

            i = currentCell.Second.First;
            j = currentCell.Second.Second;

            closedList[i][j] = true;

            int index;
            for (index = 0; index < RTS.PathFindingHelper.neighborLength; ++index)
            {
                // To store the 'g', 'h' and 'f' of the 8 successors 
                double gNew = 0, hNew = 0, fNew = 0;

                int neighborI, neighborJ;

                neighborI = i + RTS.PathFindingHelper.Neighbors[index, 0];
                neighborJ = j + RTS.PathFindingHelper.Neighbors[index, 1];

                if (RTS.PathFindingHelper.IsSearchValid(neighborI, neighborJ, endPosition.X, endPosition.Y))
                {
                    //ReachedDestination
                    if (RTS.PathFindingHelper.HasDestinationBeenReached(neighborI, neighborJ, endPosition.X, endPosition.Y))
                    {
                        pfGrid.UpdateParent(neighborI, neighborJ, i, j);
                        count++;
                        return TracePath();
                    }
                    else if (closedList[neighborI][neighborJ] == false && RTS.PathFindingHelper.IsCellFree(grid, neighborI, neighborJ))
                    {
                        double gValue = 1.0;
                        if (neighborI != i && neighborJ != j)
                        {
                            gValue = 1.414;
                        }

                        gNew = pfGrid.GetG(i, j) + gValue;
                        hNew = RTS.PathFindingHelper.CaculateHValue(neighborI, neighborJ, endPosition.X, endPosition.Y);
                        fNew = gNew + hNew;

                        if (!pfGrid.CanAdd(neighborI, neighborJ, fNew))
                        {
                            openList.Add(fNew, new Pair<int, int>(neighborI, neighborJ));

                            pfGrid.UpdateValue(neighborI, neighborJ, gNew, hNew, fNew, i, j);
                        }
                    }
                }
            }
        }

        //If we got here we didn't find a path

        return emptyPath;
    }

    public Stack<Pair<int, int>> GetPath(WorldCoordinates currentPosition, WorldCoordinates destination)
    {

        startPosition.SetCoordinates(currentPosition);
        endPosition.SetCoordinates(destination);


        return PerformPathFinding();
    }

    public Stack<Pair<int, int>> TracePath()
    {
        Stack<Pair<int, int>> path = new Stack<Pair<int, int>>();

        int i, j;

        i = endPosition.X;
        j = endPosition.Y;
        while (!pfGrid.HasNoParents(i, j, i, j))
        {
            path.Push(new Pair<int, int>(i, j));
            int tempI = pfGrid.GetIParent(i, j);
            int tempJ = pfGrid.GetjParent(i, j);

            i = tempI;
            j = tempJ;
        }

        return path;

    }

    private void UpdateGridSpaceMaterial(int i,int j)
    {
        RTS.PathFindingHelper.grid.UpdateGridSpaceMaterial(path, i, j);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class GameGrid{

    /*The GameObject order is:
     * 0.GridObject
     * 1.GridMap
     */
    //[SerializeField] private List<GridSpace> gameGrid;
    [SerializeField] private GameGridList gameGrid;
    [SerializeField] private GameObject gridMap;


    public GameGrid()
    {
        gameGrid = new GameGridList();
    }

    public GameGrid(Transform map,int width, int length)
    {
        gameGrid = new GameGridList(width, length);

        gridMap = map.gameObject;
    }

    #region Code that adds/defines a grid
    internal void AddObjectToGrid(GameObject generatedObject)
    {
        AddChildGridElement(generatedObject);
    }

    private void AddChildGridElement(GameObject gridObject)
    {
        gridObject.transform.parent = gridMap.transform;
        gridObject.SetActive(true);
    }

    internal void AddGridSpacetoArray(GridSpace newGridSpace,int widthIndex,int heightIndex)
    {
        gameGrid.InsetGridElement(newGridSpace, widthIndex, heightIndex);
    }

    internal void UpdateGridSpaceMaterial(Material path, int currentX, int currentY)
    {
        gameGrid.UpdateGridSpaceMaterial(path, currentX, currentY);
    }

    internal bool IsCellFree(int v, int j)
    {
        return gameGrid.IsCellFree(v, j);
    }
    #endregion

}

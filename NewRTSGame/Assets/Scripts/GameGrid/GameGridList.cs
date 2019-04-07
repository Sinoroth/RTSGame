using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameGridList {

    [SerializeField]
    private GridSpace[][] list;
    [SerializeField]
    private int maxX, maxY;

    public GameGridList()
    {
        CreateNewList(50, 50);
    }

    public GameGridList(int width, int length)
    {
        CreateNewList(width, length);
    }

    #region Initialization
    private void CreateNewList(int width, int length)
    {
        InitializeList(width, length);
        SetDimensions(width, length);
    }

    private void SetDimensions(int x,int y)
    {
        maxX = x;
        maxY = y;
    }

    private void InitializeList(int width, int length)
    {
        list = new GridSpace[width][];
        for (int i = 0; i < width; ++i)
        {
            list[i] = new GridSpace[length];
        }
    }
    #endregion

    public void InsetGridElement(GridSpace gridSpace, int x, int y)
    {
        if (!((x < 0) || (x > maxX) || (y < 0) || (y > maxY)))
        {
            list[x][y] = gridSpace;
        }
    }

    internal void UpdateGridSpaceMaterial(Material path, int currentX, int currentY)
    {
        list[currentX][currentY].SetMaterial(path);
    }

    internal bool IsCellFree(int v, int j)
    {
        return list[v][j].IsFree();
    }
}

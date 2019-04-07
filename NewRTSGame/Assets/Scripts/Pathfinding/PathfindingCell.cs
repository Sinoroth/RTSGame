using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingCell {

    private int parent_i, parent_j;
    // f = g + h 
    private double f, g, h;

    public PathfindingCell()
    {
    }

    internal void InitializeValues()
    {
        parent_i = -1;
        parent_j = -1;
        f = RTS.PathFindingHelper.maxValue;
        g = RTS.PathFindingHelper.maxValue;
        h = RTS.PathFindingHelper.maxValue;
    }

    internal void SetValueForCell(int i,int j, int f,int g,int h)
    {
        parent_i = i;
        parent_j = j;

        this.f = f;
        this.g = g;
        this.h = h;
    }

    internal double GetG()
    {
        return g;
    }

    internal double GetH()
    {
        return h;
    }

    internal double GetF()
    {
        return f;
    }

    internal bool EqualsMaxValue()
    {
        if(f == RTS.PathFindingHelper.maxValue)
        {
            return true;
        }
        return false;
    }

    internal bool IsNewFGreater(double newF)
    {
        if(newF > f)
        {
            return true;
        }
        return false;
    }

    internal void UpdateValues(double gNew, double hNew, double fNew, int i, int j)
    {
        g = gNew;
        h = hNew;
        f = fNew;
        parent_i = i;
        parent_j = j;
    }

    internal void UpdateParents(int i, int j)
    {
        parent_i = i;
        parent_j = j;
    }

    internal bool IsParent(int parentI, int parentJ)
    {
        if (parent_i == parentI && parent_j == parentJ)
        {
            return true;
        }
        else return false;
    }

    internal int GetIParent()
    {
        return parent_i;
    }

    internal int GetJParent()
    {
        return parent_j;
    }

    internal bool HasNoParents(int parentI, int parentJ)
    {
        if(parentI == -1 || parentJ == -1) return true;

        if (IsParent(parentI, parentJ)) return true;
        return false;
    }
}

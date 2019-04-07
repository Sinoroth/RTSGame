using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorldCoordinates
{
    [SerializeField]private int x;
    public int X { get { return x; } set { x = value; } }

    [SerializeField] private int y;
    public int Y { get { return y; } set { y = value; } }


    internal void SetCoordinates(WorldCoordinates NewCoordinates)
    {
        X = NewCoordinates.X;
        Y = NewCoordinates.Y;
    }

    public override bool Equals(System.Object obj)
    {
        if (obj == null)
            return false;
        WorldCoordinates c = obj as WorldCoordinates;
        if ((System.Object)c == null)
            return false;

        if(X != c.X || Y != c.Y)
        {
            return false;
        }

        return true;
    }
    public bool Equals(WorldCoordinates c)
    {
        if ((object)c == null)
            return false;
        if (X != c.X || Y != c.Y)
        {
            return false;
        }

        return true;
    }
}

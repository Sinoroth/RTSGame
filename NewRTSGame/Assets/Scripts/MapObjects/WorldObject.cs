using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject : MonoBehaviour
{

    [SerializeField] WorldCoordinates coordinates;

    [SerializeField] protected bool blocksSquare = false;

    public bool BlocksSquare()
    {
        return blocksSquare;
    }

    internal void SetCoordinates(int widthIndex, int heightIndex)
    {
        coordinates.X = widthIndex;
        coordinates.Y = heightIndex;
    }
}
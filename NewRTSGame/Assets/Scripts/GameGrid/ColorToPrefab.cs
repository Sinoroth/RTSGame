using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ColorToPrefab {

    [SerializeField] private Color color;
    [SerializeField] private GameObject associatedPrefab;

    public bool IsColor(Color pixelColor)
    {
        if (Equals(pixelColor)) return true;
        return false;
    }

    internal Color GetColor()
    {
        return color;
    }

    private bool Equals(Color pixelColor)
    {
        if(pixelColor.r == color.r && pixelColor.g == color.g && pixelColor.b == color.b)
        {
            return true;
        }
        return false;
    }

    internal void SetColor(int r, int g, int b)
    {
        color.r = r;
        color.g = g;
        color.b = b;
    }

    internal GameObject ReturnGameObject()
    {
        return associatedPrefab;
    }
}

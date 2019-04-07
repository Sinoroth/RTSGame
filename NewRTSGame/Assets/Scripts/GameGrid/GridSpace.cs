using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GridSpace {

    [SerializeField]
    private GameObject gridObject;
    [SerializeField]
    private float xCenter, yCenter;
    [SerializeField]
    private bool isFree;

    public GridSpace(float coordX, GameObject gridObject, float coordY)
    {
        xCenter = coordX;
        yCenter = coordY;
        this.gridObject = gridObject;
        isFree = true;
    }

    public GridSpace(float coordX,float coordY, GameObject gridObject, bool blocksSquare)
    {
        xCenter = coordX;
        yCenter = coordY;
        this.gridObject = gridObject;
        isFree = !blocksSquare;
    }

    public void SetMaterial(Material material)
    {
        gridObject.GetComponent<Renderer>().material = material;
    }


    public bool IsFree()
    {
        return isFree;
    }
}

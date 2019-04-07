using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SelectedObjects{

    [SerializeField]
    private List<GameObject> selectedObjects;


    public void NewSelectedItems(List<GameObject> sObjects)
    {
        selectedObjects = sObjects;
    }

    public SelectedObjects()
    {
        selectedObjects = new List<GameObject>();
    }

    internal bool HasUnit(GameObject unit)
    {
        if (selectedObjects.Contains(unit))
        {
            return true;
        }
        return false;
    }

    internal void Reset()
    {
        selectedObjects.Clear();
    }
}

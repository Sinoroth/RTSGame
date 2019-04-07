using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitManager{

    [SerializeField] private SelectedObjects selectedObjects;
    private PlayerUnits units;
    private bool hasUnitsSelected;

    public PlayerUnitManager()
    {
        selectedObjects = new SelectedObjects();
        units = new PlayerUnits();
        hasUnitsSelected = false;
    }

    #region UnitFunctions
    internal bool HasUnitSelected(GameObject unit)
    {
        if (selectedObjects.HasUnit(unit))
        {
            return true;
        }
        else return false;
    }

    internal void ResetSelectedObjects()
    {
        selectedObjects.Reset();
    }

    internal bool HasUnitsSelected()
    {
        return hasUnitsSelected;
    }

    public void UpdateSelectedObjects(List<GameObject> sObjects)
    {
        selectedObjects.NewSelectedItems(sObjects);
    }
    #endregion
}

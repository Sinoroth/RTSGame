using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager {

    private PlayerUnitManager unitManager;
    private PlayerResourceManager resourceManager;

    public PlayerManager()
    {
        unitManager = new PlayerUnitManager();
        resourceManager = new PlayerResourceManager();
    }

    #region UnitFunctions
    public void UpdateSelectedObjects(List<GameObject> sObjects)
    {
        unitManager.UpdateSelectedObjects(sObjects);
    }

    internal bool HasUnitSelected(GameObject unit)
    {
        return unitManager.HasUnitSelected(unit);
    }

    internal void ResetSelectedObjects()
    {
        unitManager.ResetSelectedObjects();
    }

    internal bool HasUnitsSelected()
    {
        return unitManager.HasUnitsSelected();
    }
    #endregion

    #region ResourceFunctions
    internal void GetInitialResources(ref PlayerCampaignResourceManager playerResources)
    {
        resourceManager.GetInitialResources(ref playerResources);
    }
    #endregion

}

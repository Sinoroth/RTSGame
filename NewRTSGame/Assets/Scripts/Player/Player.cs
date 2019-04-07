using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private PlayerManager manager;
	
    public Player()
    {
        InitializePlayer();
    }

    public void InitializePlayer()
    {
        manager = new PlayerManager();
    }

    public void UpdateSelectedObjects(List<GameObject> sObjects)
    {
        manager.UpdateSelectedObjects(sObjects);
    }

    internal bool HasUnitSelected(GameObject unit)
    {
        return manager.HasUnitSelected(unit);
    }

    internal void ResetSelectedObjects()
    {
        manager.ResetSelectedObjects();
    }

    internal bool HasUnitsSelected()
    {
        return manager.HasUnitsSelected();
    }

    internal void GetInitialResources(ref PlayerCampaignResourceManager playerResources)
    {
        manager.GetInitialResources(ref playerResources);
    }
}

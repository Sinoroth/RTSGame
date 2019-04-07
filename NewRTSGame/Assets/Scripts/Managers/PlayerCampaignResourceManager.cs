using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerCampaignResourceManager {

    [SerializeField] private Resource Food, Wood, Gold, Stone;

    public PlayerCampaignResourceManager(int foodValue,int woodValue, int goldValue, int stoneValue)
    {
        Food  = new Resource(RTS.GameResourceManager.ResourceTypes.Food , foodValue);
        Wood  = new Resource(RTS.GameResourceManager.ResourceTypes.Wood , woodValue);
        Gold  = new Resource(RTS.GameResourceManager.ResourceTypes.Gold , goldValue);
        Stone = new Resource(RTS.GameResourceManager.ResourceTypes.Stone, stoneValue);
    }

    internal string GetFood()
    {
        return Food.GetValue().ToString();
    }

    internal string GetWood()
    {
        return Wood.GetValue().ToString();
    }

    internal string GetGold()
    {
        return Gold.GetValue().ToString();
    }

    internal string GetStone()
    {
        return Stone.GetValue().ToString();
    }
}

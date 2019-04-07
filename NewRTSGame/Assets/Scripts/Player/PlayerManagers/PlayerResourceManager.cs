using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResourceManager{

    private PlayerCampaignResourceManager resources;
    public PlayerCampaignResourceManager Resources { get { return resources; } protected set { resources = value; } }
    private bool haveResourcesBeenPassedAtInitialization;

    public PlayerResourceManager()
    {
        haveResourcesBeenPassedAtInitialization = false;
        resources = new PlayerCampaignResourceManager(500, 200, 150, 100);
    }

    internal void GetInitialResources(ref PlayerCampaignResourceManager playerResources)
    {
        if(haveResourcesBeenPassedAtInitialization == false)
        {
            playerResources = Resources;
            haveResourcesBeenPassedAtInitialization = true;
        }
    }
}

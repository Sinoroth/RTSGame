using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneResourceManger {
    private CampaignResourceManager resourceManager;

    public SceneResourceManger()
    {
        resourceManager = new CampaignResourceManager();
    }

    internal void LoadCampaignResources(GameObject[] resources)
    {
        resourceManager.FillCampaignResources(resources);
    }
}

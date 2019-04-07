using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampaignResourceManager{

    private CampaignResourceList resourceList;

    public CampaignResourceManager()
    {
        resourceList = new CampaignResourceList();
    }

    public void FillCampaignResources(GameObject[] GameResources)
    {
        List<CampaignResource> temporaryList = new List<CampaignResource>();
        foreach(GameObject resource in GameResources)
        {
            CampaignResource campaignResource = resource.GetComponent<CampaignResource>();

            temporaryList.Add(campaignResource);
        }

        resourceList.FillCampaignResources(temporaryList);
    }

}

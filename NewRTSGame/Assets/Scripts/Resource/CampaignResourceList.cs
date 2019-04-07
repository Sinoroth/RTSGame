using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampaignResourceList{

    private List<CampaignResource> campaignResources;

    public CampaignResourceList()
    {
        campaignResources = new List<CampaignResource>();
    }

    public void FillCampaignResources(List<CampaignResource> cResources)
    {
        campaignResources = cResources;
    }
}

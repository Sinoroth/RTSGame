using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampaignResource :MonoBehaviour{

    [SerializeField] private Resource resource;

    public CampaignResource(RTS.GameResourceManager.ResourceTypes resourceType, int quantity)
    {
        resource = new Resource(resourceType, quantity);
    }

    public string TestGetresourceName()
    {
        return resource.ReturnType();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Resource {

    [SerializeField]
    RTS.GameResourceManager.ResourceTypes type;
    [SerializeField]
    private int quantity;

    public Resource(RTS.GameResourceManager.ResourceTypes type,int quantity)
    {
        this.type = type;
        this.quantity = quantity;
    }

    public Resource(RTS.GameResourceManager.ResourceTypes type)
    {
        this.type = type;
        this.quantity = RTS.GameResourceManager.ResourceValues[(int)type,1];
    }

    public int GetValue()
    {
        return quantity;
    }

    public string ReturnType()
    {
        return type.ToString();
    }
}

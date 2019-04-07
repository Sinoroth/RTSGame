using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MovingObject
{
    protected UnitManager manager;

    protected float movementSpeed;

    internal void SetManager(UnitManager manager)
    {
        this.manager = manager;
    }
}

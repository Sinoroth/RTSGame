using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnits
{
    [SerializeField] private List<GameObject> enemyUnits;

    public EnemyUnits()
    {
        enemyUnits = new List<GameObject>();
    }
}

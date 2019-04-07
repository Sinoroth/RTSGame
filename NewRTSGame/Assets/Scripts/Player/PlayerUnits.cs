using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerUnits {

    [SerializeField] private List<GameObject> playerUnits;
    [SerializeField] private List<TestUnit> playerUnitsCode;

    internal void DeselectUnits()
    {
        foreach (GameObject unit in playerUnits)
        {
            unit.GetComponent<Projector>().enabled = false;
        }
    }

    public PlayerUnits()
    {
        playerUnits = new List<GameObject>();
        playerUnitsCode = new List<TestUnit>();
    }

    public List<GameObject> GetUnits()
    {
        return playerUnits;
    }

    internal void SetStartingUnits(GameObject[] units)
    {
        foreach (GameObject unit in units)
        {
            if (playerUnits.Contains(unit)) continue;
            playerUnits.Add(unit);
            playerUnitsCode.Add(unit.GetComponent<TestUnit>());
        }
    }

    public void MoveObjectsToPos(int x, int y)
    {
        foreach (TestUnit unit in playerUnitsCode)
        {
            unit.GoToLocation(x, y);
        }
    }

    internal void MoveSelectedUnitsTo(int x, int y)
    {
        foreach(TestUnit unit in playerUnitsCode)
        {
            unit.GoToLocation(x, y);
        }
    }
}

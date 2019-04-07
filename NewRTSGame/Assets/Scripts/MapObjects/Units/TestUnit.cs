using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TestUnit : Unit
{
    [SerializeField] private GameObject unit;

    [SerializeField] private PathFindingUnitLogic logic;

    // Use this for initialization
    void Start()
    {
        //Initialize();
    }

    private void Update()
    {
        logic.MoveUnit(unit,movementSpeed);
    }

    public void Initialize(int widthIndex, int heightIndex, int x, int y)
    {
        movementSpeed = 1.5f;
        unit = this.gameObject;
        InitializeLogic(widthIndex,heightIndex,x,y);
    }

    private void InitializeLogic(int widthIndex, int heightIndex, int x,int y)
    {
        logic = new PathFindingUnitLogic();
        logic.SetStart(x, y);
    }

    public void SetLocation(int x, int y)
    {
        logic.SetStart(x, y);
    }

    public void GoToLocation(int x,int y)
    {
        logic.MoveUnit(unit, x, y,movementSpeed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridElementClickEvents : MonoBehaviour
{

    private GameGridManager gridManager;
    private int gridCoordX, gridCoordY;
    public int X { get { return gridCoordX; } protected set { gridCoordX = value; } }
    public int Y { get { return gridCoordY; } protected set { gridCoordY = value; } }

    // Use this for initialization
    void Start () {
        SetManager();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            gridManager.GetClickedObject(this.gameObject, X, Y);
            RTS.UnitManagerHelper.GetClickedLocation(Input.mousePosition.x,Input.mousePosition.y);
        }
    }

    private void SetManager()
    {
        gridManager = GameObject.Find("GameGridManager").GetComponent<GameGridManager>();
    }
     
    public void SetGrid(int x,int y)
    {
        X = x;
        Y = y;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGridManager : MonoBehaviour {

    [SerializeField]private SceneManager manager;

    #region Color Codes
    /*                 GIMP       UNITY
     * 0.Empty space - 09FF0000 - 08FF00FF
     * 1.Stone       - CEC7C6FF - CEC8C8FF/CEC7C6FF(if paired with others)
     * 2.Gold        - ffc000   - FFBF0000/FFBE00FF(if paired with others)
     * 3.Food        - FF000000 - FF0000
     * 4.Wood        - A5690FFF - A56910FF
     */
    #endregion

    [SerializeField] private GameGrid grid;

    [SerializeField] private GameObject[] gridObjects;

    [SerializeField] private int highestX, highestY;

    [SerializeField] private Texture2D map;

    [SerializeField] private MapGeneratorFromDrawing mapGenerator;

    [SerializeField] private GameObject testObject;

    private PathFinding pathFinding;

    public int clickedNumber;


    // Use this for initialization
    void Start () {

        RTS.GeneralManagerFunctions.SetSceneManager(manager);
        manager = GameObject.Find("SceneManager").GetComponent<SceneManager>();

        InitializeGrid();
    }

    private void InitializeGrid()
    {
        grid = new GameGrid(this.gameObject.transform.GetChild(1), map.width, map.height);

        mapGenerator.GenerateMap(testObject, grid, map, this);

        highestX = map.width;
        highestY = map.height;

        pathFinding = this.gameObject.GetComponent<PathFinding>();

        RTS.PathFindingHelper.SetMaxDimensions(map.width, map.height);
        RTS.PathFindingHelper.SetGameGrid(grid);

        clickedNumber = 0;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void GetClickedObject(GameObject clickedObject, int x,int y)
    {
        manager.MoveClick(x, y);
        //pathFinding.updateObject(clickedObject, ref clickedNumber, x, y);
    }

    public GameGrid GetGameGrid()
    {
        return grid;
    }

    internal void UpdateGrid(GameGrid grid)
    {
        this.grid = grid;
    }
}

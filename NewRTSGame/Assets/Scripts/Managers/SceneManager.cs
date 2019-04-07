using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour {

    #region Player
    private GameObject playerObject;
    private Player playerScript;
    [SerializeField] private PlayerCampaignResourceManager playerResources;
    #endregion

    #region Units
    private UnitManager unitManager;
    [SerializeField] private GameObject unitManagerObject;
    #endregion

    #region GameGrid
    private GameGridManager gridManager;
    [SerializeField] private GameObject gridManagerObject;
    #endregion

    #region UI
    [SerializeField]public Text[] resourceValues;
    #endregion

    #region Resource
    private SceneResourceManger resourceManager;
    #endregion

    // Use this for initialization
    void Start () {
        InitializeGame();
    }

    // Update is called once per frame
    void Update () {
        //UpdateDisplayedResources();
	}

    void OnGUI()
    {
        if (RTS.MouseFunctions.isSelecting)
        {
            // Create a rect from both mouse positions
            var rect = RTS.MouseFunctions.UnitSelectionUtilities.GetScreenRect(RTS.MouseFunctions.selectionMousePosition, Input.mousePosition);
            RTS.MouseFunctions.UnitSelectionUtilities.DrawScreenRect(rect, new Color(0.8f, 0.8f, 0.95f, 0.25f));
            RTS.MouseFunctions.UnitSelectionUtilities.DrawScreenRectBorder(rect, 2, new Color(0.8f, 0.8f, 0.95f));
        }
    }


    #region StartFunctions
    private void InitializeGame()
    {
        playerObject = GameObject.Find("Player");
        InitializePlayer();
        InitializePlayerResources();
        InitializeUnits();

        InitializeResources();
    }

    internal void MoveClick(int x, int y)
    {
        unitManager.MoveSelectedUnitsTo(x, y);
    }

    #region UnitInitialization
    private void InitializeUnits()
    {
        unitManager = unitManagerObject.GetComponent<UnitManager>();
        unitManager.SetPlayer(playerScript);
    }
    #endregion

    #region GameGridInitialization
    private void InitializeGameGrid()
    {
        gridManager = gridManagerObject.GetComponent<GameGridManager>();
    }
    #endregion

    #region PlayerInitialization
    private void InitializePlayer()
    {
        playerScript = playerObject.transform.GetComponent<Player>();
        playerScript.InitializePlayer();
    }

    private void InitializePlayerResources()
    {
        playerScript.GetInitialResources(ref playerResources);
    }
    #endregion

    #region ResourceInitialization
    private void InitializeResources()
    {
        resourceManager = new SceneResourceManger();
        resourceManager.LoadCampaignResources(GameObject.FindGameObjectsWithTag("Resource"));

        //MatchResourceValuesToInGameUI();
    }

    private void MatchResourceValuesToInGameUI()
    {
        resourceValues[(int)RTS.GameResourceManager.ResourceTypes.Food] = GameObject.Find("FoodValue").GetComponent<Text>();
        resourceValues[(int)RTS.GameResourceManager.ResourceTypes.Wood] = GameObject.Find("WoodValue").GetComponent<Text>();
        resourceValues[(int)RTS.GameResourceManager.ResourceTypes.Gold] = GameObject.Find("GoldValue").GetComponent<Text>();
        resourceValues[(int)RTS.GameResourceManager.ResourceTypes.Stone] = GameObject.Find("StoneValue").GetComponent<Text>();
    }

    #endregion

    #endregion


    #region UpdateFunctions
    private void UpdateDisplayedResources() {
        resourceValues[(int)RTS.GameResourceManager.ResourceTypes.Food].text =playerResources.GetFood();
        resourceValues[(int)RTS.GameResourceManager.ResourceTypes.Wood].text = playerResources.GetWood();
        resourceValues[(int)RTS.GameResourceManager.ResourceTypes.Gold].text = playerResources.GetGold();
        resourceValues[(int)RTS.GameResourceManager.ResourceTypes.Stone].text = playerResources.GetStone();
    }
    #endregion

}

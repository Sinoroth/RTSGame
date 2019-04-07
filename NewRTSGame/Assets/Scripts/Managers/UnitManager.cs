using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [SerializeField] private SceneManager manager;

    private bool HasUnitsSelected = true; //if testing set to true otherwise false.

    private Player playerScript;

    #region Units
    [SerializeField]
    private PlayerUnits playerUnits;
    private List<GameObject> enemyUnits;
    [SerializeField]
    private List<GameObject> selectedUnits;
    #endregion

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        MouseFunction();
        SelectObjects();
        playerUnits.SetStartingUnits(GameObject.FindGameObjectsWithTag("PlayerUnit"));
        RTS.GeneralManagerFunctions.SetSceneManager(manager);
        manager = GameObject.Find("SceneManager").GetComponent<SceneManager>();


    }
    #region Initialize

    private void Initialize()
    {
        InitializePlayerUnits();   
    }

    private void InitializePlayerUnits()
    {
        playerUnits = new PlayerUnits();
        selectedUnits = new List<GameObject>();
        playerUnits.SetStartingUnits(GameObject.FindGameObjectsWithTag("PlayerUnit"));
    }

    internal void SetPlayer(Player playerScript)
    {
        this.playerScript = playerScript;
    }
    #endregion

    #region MouseFunctions
    private void MouseFunction()
    {

        GetMousePosition();
        if (Input.GetMouseButtonDown(0))
        {
            //PassClickedObjectToPlayer();
        }

        MouseUnitSelection();
        MouseUnitMove();
    }

    private void PassClickedObjectToPlayer()
    {
        GameObject clickedObject = RTS.MouseFunctions.GetClickedGameObject();
        List<GameObject> clickedObjects = new List<GameObject>();

        clickedObjects.Add(clickedObject);

        playerScript.UpdateSelectedObjects(clickedObjects);
    }

    private void PassObjectsToPlayer(List<GameObject> unit)
    {
        playerScript.UpdateSelectedObjects(unit);
    }

    internal void MoveSelectedUnitsTo(int x, int y)
    {
        playerUnits.MoveSelectedUnitsTo(x, y);
    }

    private bool IsWithinSelectionBounds(GameObject gameObject)
    {
        if (!RTS.MouseFunctions.isSelecting)
            return false;

        var camera = Camera.main;
        var viewportBounds =
            RTS.MouseFunctions.UnitSelectionUtilities.GetViewportBounds(camera, RTS.MouseFunctions.selectionMousePosition, Input.mousePosition);

        return viewportBounds.Contains(
            camera.WorldToViewportPoint(gameObject.transform.position));
    }

    private void SelectObjects()
    {
        if (RTS.MouseFunctions.isSelecting)
        {
            foreach (GameObject unit in playerUnits.GetUnits())
            {
                if (IsWithinSelectionBounds(unit))
                {
                    if (UnitIsNotAlreadySelected(unit))
                    {
                        unit.GetComponent<Projector>().enabled = true;
                        selectedUnits.Add(unit);
                    }
                }
                else
                {
                    selectedUnits.Remove(unit);
                    unit.GetComponent<Projector>().enabled = false;
                }
            }
        }
    }

    private bool UnitIsNotAlreadySelected(GameObject unit)
    {
        if (selectedUnits.Contains(unit)) return false;
        else return true;
    }
#endregion

    #region MouseFunctions
    private void GetMousePosition()
    {
        RTS.MouseFunctions.mousePosition = Input.mousePosition;
    }

    private void MouseUnitSelection()
    {
        // If we press the left mouse button, save mouse location and begin selection
        if (Input.GetMouseButtonDown(0))
        {
            if (RTS.MouseFunctions.isSelecting == false)
            {
                selectedUnits.Clear();
                playerUnits.DeselectUnits();
                playerScript.ResetSelectedObjects();
            }
            RTS.MouseFunctions.selectionMousePosition = Input.mousePosition;
            RTS.MouseFunctions.isSelecting = true;
        }
        // If we let go of the left mouse button, end selection
        if (Input.GetMouseButtonUp(0))
        {
            RTS.MouseFunctions.isSelecting = false;
            PassObjectsToPlayer(selectedUnits);
        }

    }

    private void MouseUnitMove()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!playerScript.HasUnitsSelected())
            {
                foreach (GameObject unit in selectedUnits)
                {
                    unit.transform.position = Camera.main.ScreenToWorldPoint(RTS.MouseFunctions.mousePosition);
                    unit.transform.position = new Vector3(unit.transform.position.x, unit.transform.position.y, 0);
                }
            }
        }
    }
    #endregion

}

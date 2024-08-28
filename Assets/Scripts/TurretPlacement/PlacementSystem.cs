using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{

    [SerializeField]
    private GameObject mouseIndicator, cellIndicator;
    [SerializeField]
    private InputManager inputManager;
    [SerializeField]
    private Grid grid;
    [SerializeField]
    private ObjectsDatabaseSO database;
    private int selectedObjectIndex = 1;

    Vector3 offset;

    private void Start()
    {
        StopPlacement();
    }

    public void StartPlacement(int ID)
    {
        Debug.Log("0");
        StopPlacement();
        selectedObjectIndex = database.objectsData.FindIndex(data => data.ID == ID); //acts as for loop
        if(selectedObjectIndex < 0)
        {
            Debug.Log($"No ID found {ID}");
            return;
        }
        cellIndicator.SetActive(true);
        inputManager.OnClick += PlaceStructure; //subscribes to events
        inputManager.OnExit += StopPlacement;
    }

    private void PlaceStructure()
    {
        Debug.Log("1");
        //if(inputManager.isPointerOverUI())
        //{
        //    return;
        //}

        Vector3 mousePosition = inputManager.GetSelectedMapPosition(); //gets the location of what the mouse is pointing at
        Vector3Int gridPosition = grid.WorldToCell(mousePosition); //converst that position to cell coordinates and stores it
        GameObject newObject = Instantiate(database.objectsData[selectedObjectIndex].Prefab);
        Debug.Log("2");
        newObject.transform.position = grid.CellToWorld(gridPosition); //converst position back into world coords
    }

    private void StopPlacement()
    {
        selectedObjectIndex = -1;
        cellIndicator.SetActive(false);
        inputManager.OnClick -= PlaceStructure; //unsubscribes from events
        inputManager.OnExit -= StopPlacement;
    }

    private void Update()
    {
        if (selectedObjectIndex < 0)
            return;
        Vector3 mousePosition = inputManager.GetSelectedMapPosition(); //gets the location of what the mouse is pointing at
        Vector3Int gridPosition = grid.WorldToCell(mousePosition); //converst that position to cell coordinates and stores it
        mouseIndicator.transform.position = mousePosition; //mouses the indicator to that grid posiotion
        cellIndicator.transform.position = grid.CellToWorld(gridPosition); //converst position back into world coords

    }   

}


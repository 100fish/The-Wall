using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField]
    private Tilemap tilemap;
    [SerializeField]
    public EnemySpawner enemySpawner;
    [SerializeField]
    private GameObject mouseIndicator, cellIndicator;
    [SerializeField]
    private InputManager inputManager;
    [SerializeField]
    private Grid grid;
    [SerializeField]
    private ObjectsDatabaseSO database;
    private int selectedObjectIndex = 1;
    private GridData towerData;
    public LineController lc;

    private Renderer previewRenderer;

    private List<GameObject> placedGameObjects = new();

    Vector3 offset;

    private void Start()
    {
        StopPlacement();
        towerData = new GridData();
        previewRenderer = cellIndicator.GetComponentInChildren<Renderer>();

    }

    public void StartPlacement(int ID)
    {
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

        //if (inputManager.isPointerOverUI())
        //{
        //   return;
        //}

        if (database.objectsData[selectedObjectIndex].cost > GameManager.Instance.money)
            return;

        Vector3 mousePosition = inputManager.GetSelectedMapPosition(); //gets the location of what the mouse is pointing at
        Vector3Int gridPosition = grid.WorldToCell(mousePosition); //converst that position to cell coordinates and stores it

        bool placementValidity = CheckPlacementValidity(gridPosition, selectedObjectIndex);//checks if thesize is too big


        if (placementValidity == false)
            return;

        GameObject newObject = Instantiate(database.objectsData[selectedObjectIndex].Prefab);
        newObject.transform.position = grid.CellToWorld(gridPosition); //converst position back into world coords
        placedGameObjects.Add(newObject);
        GridData selectedData = towerData;
        selectedData.AddObjectAt(gridPosition,
            database.objectsData[selectedObjectIndex].size,
            database.objectsData[selectedObjectIndex].ID,
            placedGameObjects.Count - 1);

        //newObject.GetComponent<Turret1Shoot>().enemySpawner = enemySpawner;
        //newObject.GetComponent<Turret1Shoot>().line = lc;

        GameManager.Instance.money -= database.objectsData[selectedObjectIndex].cost;
    }

    private bool CheckPlacementValidity(Vector3Int gridPosition, int selectedObjectIndex)
    {

        if (gridPosition.z != 0)
        {
            cellIndicator.SetActive(false);
            return false;
        }


        TileBase hitTile = tilemap.GetTile(gridPosition); //this part of the code is mine, it checks what tile is selected and only builds on buildable tiles
        if (hitTile.name != "Floor")
            return false;
        

        GridData selectedData = towerData;
        return selectedData.CanPlaceObjectAt(gridPosition, database.objectsData[selectedObjectIndex].size);//checks if the size is too big
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
        cellIndicator.SetActive(true);
        Debug.Log(GameManager.Instance.gameState);
        if (selectedObjectIndex < 0)
            return;
        Vector3 mousePosition = inputManager.GetSelectedMapPosition(); //gets the location of what the mouse is pointing at
        Vector3Int gridPosition = grid.WorldToCell(mousePosition); //converst that position to cell coordinates and stores it

        bool placementValidity = CheckPlacementValidity(gridPosition, selectedObjectIndex);
        if (placementValidity == false)
            previewRenderer.material.color = Color.red;
        else
            previewRenderer.material.color = Color.white;

        mouseIndicator.transform.position = mousePosition; //mouses the indicator to that grid posiotion
        cellIndicator.transform.position = grid.CellToWorld(gridPosition); //converst position back into world coords

    }   

}


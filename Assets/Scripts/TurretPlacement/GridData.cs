using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GridData
{
    //GRIFFIN CODE


    Dictionary<Vector3Int, PlacementData> placedObjects = new Dictionary<Vector3Int, PlacementData>();

    public void AddObjectAt(Vector3Int gridPosition,
                            Vector2Int objectSize,
                            int ID,
                            int placedObjectIndex)
    {
        List<Vector3Int> positionToOccupy = CalculatePositions(gridPosition, objectSize); //sets posisitiontooccupy as every position that the new object takes up 
        PlacementData data = new PlacementData(positionToOccupy, ID, placedObjectIndex); //sets the placementdata of a cell based on Placementdata class
        foreach (var pos in positionToOccupy) 
        {
            if (placedObjects.ContainsKey(pos))
                throw new Exception($"Dictionary already contains this cell position {pos}");
            placedObjects[pos] = data;

        }
    }

    private List<Vector3Int> CalculatePositions(Vector3Int gridPosition, Vector2Int objectSize)
    {
        List<Vector3Int> returnVal = new List<Vector3Int>(); // creates a new Vector3 list
        for (int x = 0; x < objectSize.x; x++) //for every x value in the objectsize
        {
            for (int y = 0; y < objectSize.y; y++) //for every y value in the objectsize
            {
                returnVal.Add(gridPosition + new Vector3Int(x, 0, y)); //add a new entry to the list at that coordinate
            }
        }
        return returnVal; //returns list of space that the new object takes up !!!!!!!!!!!!!!!!!
    }

    public bool CanPlaceObjectAt (Vector3Int gridPosition, Vector2Int objectSize)//checks if the size is too big
    {
        List<Vector3Int> positionToOccupy = CalculatePositions(gridPosition, objectSize);//checks size against proposed posisiton to occupy
        foreach (var pos in positionToOccupy)
        {
            if (placedObjects.ContainsKey(pos))//if 
                return false;
        }
        return true;
    }
}

public class PlacementData
{
    public List<Vector3Int> occupiedPositions;

    public int ID { get; private set; }

    public int PlacedObjects { get; private set; }

    public PlacementData(List<Vector3Int> occupiedPositions, int iD, int placedObjects)
    {
        this.occupiedPositions = occupiedPositions;
        ID = iD;
        PlacedObjects = placedObjects;
    }
}

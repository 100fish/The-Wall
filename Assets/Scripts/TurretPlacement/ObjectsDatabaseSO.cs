using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu]
public class ObjectsDatabaseSO : ScriptableObject
{
    //GRIFFIN CODE

    public List<ObjectData> objectsData;
}

[Serializable]

public class ObjectData
{

    [field: SerializeField]
    public string Name { get; private set; }
    [field: SerializeField]
    public int ID { get; private set; }
    [field: SerializeField]
    public Vector2Int size { get; private set; } = Vector2Int.one;
    [field: SerializeField]
    public GameObject Prefab { get; private set; }

    [field: SerializeField]
    public int cost { get; private set; }
}

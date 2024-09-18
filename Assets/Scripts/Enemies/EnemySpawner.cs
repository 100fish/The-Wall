using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //private GameManager gameManager;
    public GameObject enemyPrefab;
    public Transform spawnTransform;
    public float spawnTimer = 10;
    public List<GameObject> enemyList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //if (GameManager.Instance.gameState == GameManager.GameState.Playing)
        //{
            spawnTimer -= Time.deltaTime * (Time.fixedTime / 20);
            //Debug.Log(spawnTimer);
            if (spawnTimer < 0)
            {
                spawnTimer = 5;
                enemyList.Add(Instantiate(enemyPrefab,
                spawnTransform.position,
                spawnTransform.rotation));
                if (Random.Range(1, 5) < 3)
                {
                    enemyList.Add(Instantiate(enemyPrefab,
                    spawnTransform.position,
                    spawnTransform.rotation));
                }
                //Debug.Log(enemyList[0]);
            }
        //}

    }

    //public void DestroyEnemies()
    //{
    //    foreach (GameObject enemy in enemyList)
    //    {
    //        GameObject.Destroy(enemy);
    //    }
    //}
}

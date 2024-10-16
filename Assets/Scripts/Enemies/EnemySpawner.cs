using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //private GameManager gameManager;
    public Transform goal;
    public GameObject enemyPrefab;
    public Transform spawnTransform;
    public float spawnTimer = 10;
    public List<GameObject> enemyList = new List<GameObject>();
    public int enemyID = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GameManager.Instance.gameState);
        if (GameManager.Instance.gameState == GameManager.GameState.Playing)
        {
            spawnTimer -= Time.deltaTime * (GameManager.Instance.roundTime / 10);
            //Debug.Log(spawnTimer);
            if (spawnTimer < 0)
            {
                spawnTimer = 5;
                enemyList.Add(Instantiate(enemyPrefab,
                spawnTransform.position,
                spawnTransform.rotation));
                enemyList[enemyID].name = "enemy" + enemyID;

                enemyList[enemyID].GetComponent<BasicEnemyMovement>().goal = goal;

                enemyID++;
                

                if (Random.Range(1, 5) < 3)
                {
                    enemyList.Add(Instantiate(enemyPrefab,
                    spawnTransform.position,
                    spawnTransform.rotation));
                    enemyList[enemyID].name = "enemy" + enemyID;

                    enemyList[enemyID].GetComponent<BasicEnemyMovement>().goal = goal;

                    enemyID++;
                }

            }
        }   


    }


}

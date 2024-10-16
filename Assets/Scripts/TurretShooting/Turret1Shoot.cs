using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Turret1Shoot : MonoBehaviour
{
    [SerializeField] private Transform[] points = { null, null };
    [SerializeField] public LineController line;

    public EnemySpawner enemySpawner;
    public Transform shootPos;

    private float shootTimer = 1;
    private int shootSpeed = 1;
    private float lineTimer = 0.3f;
    private bool lineComplete = false;
    private bool shooting = false;
    private GameObject target;

    void Start()
    {
        //line.SetUpLine(points);
        //points[1] = shootPos;
    }

    private Transform GetClosestEnemyPos(List<GameObject> enemies)
    {

        Transform tMin = null;
        float minDist = 15;
        Vector3 currentPOS = transform.position;
        foreach (GameObject t in enemies)
        {
            Transform tt = t.transform;
            float dist = Vector3.Distance(tt.position, currentPOS);
            if (dist < minDist)
            {
                tMin = tt;
                minDist = dist;
            }
        }
        return tMin;
    }

    private GameObject GetClosestEnemy(List<GameObject> enemies)
    {
        GameObject target = null; //instantiates target as an empty gameobject variable
        float minDist = 12; //instantiates the minimum distance to three
        Vector3 currentPOS = transform.position; //sets the currentpos to the current position of the tower (works perfectly)
        foreach (GameObject t in enemies) //for each gameobject in the enemies list from EnemySpawner (enemy list works)
        {
            if (t.gameObject.tag == "ShootIgnore")
                continue;
            Transform tt = t.transform; //transform value tt is defined as the transform of a particular enemy
            float dist = Vector3.Distance(tt.position, currentPOS); //dist = the distance between the current pos and tt
            Debug.Log(dist + "," + t.name);
            if (dist < minDist) // if distance is less than the min distance
            {
                Debug.Log(t.name);
                target = t;
                minDist = dist;
            }
        }
        return target;
    }

    void Update()
    {
        shootTimer -= Time.deltaTime * shootSpeed;
        //if (shooting)
        //{
         //   lineTimer -= Time.deltaTime;
        //    line.SetUpLine(points);
        //    if (lineTimer < 0)
        //    {
        //        lineTimer = 0.3f;
        //        GameManager.Instance.Kill(target);
        //        shooting = false;
        //        //points[0] = null;
        //    }    
        //}
        //else
        if (shootTimer < 0)
        {
            shootTimer = 0.5f;
            Debug.Log("shot");
            Shoot();

        }
    }

    private void Shoot()
    {
        target = GetClosestEnemy(enemySpawner.enemyList);
        Debug.Log(target);
        if (target != null)
        {
            //points[0] = target.transform;
            GameManager.Instance.Kill(target);
        }

    }


}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Turret1Shoot : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    //public Transform turretAimPoint;
    //public Transform turret;
    //public Transform turretPoint;
    //public Transform turretGun;
    //public float distance = 200;
    private float shootTimer = 1;
    private int shootSpeed = 1;
    private LineRenderer lr;
    private Transform[] points;

    public BaseDamage baseDamage;

    //public float hitForce = 20;

    //Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        //baseDamage.turret1Shoot = this;
    }


    //bullet.GetComponent<BulletScript>().shooter = gameObject;

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
            //Debug.Log(t.name);
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

        //Debug.Log(target.name);

        //Debug.Log(transform.position);
        return target;
    }

    private void OnEnable()
    {
        //points[0] = turretGun;
    }

    public void SetUpLine(Transform[] points)
    {
            lr.positionCount = points.Length;
            this.points = points;
    }

    // Update is called once per frame
    void Update()
    {
        //Turret.LookAt(turretAimPoint.forward * 100);
        shootTimer -= Time.deltaTime * shootSpeed;
        //Debug.Log(shootTimer);
        if (shootTimer <= 0)
        {
            shootTimer = 0.5f;
            Debug.Log("shot");
            Shoot();

        }
    }

    private void Shoot()
    {
        //Debug.Log(enemySpawner);
        GameObject target = GetClosestEnemy(enemySpawner.enemyList);
        //points[1] = target.transform;

        //for (int i = 0; i < points.Length; i++)
        //{
        //    lr.SetPosition(i, points[i].position);
        //}
        if (target != null)
        {
            GameManager.Instance.Kill(target);
        }

    }


}

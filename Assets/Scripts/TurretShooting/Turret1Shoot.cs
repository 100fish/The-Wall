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
    private GameObject empty;

    public BaseDamage baseDamage;

    //public float hitForce = 20;

    //Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        empty = new GameObject();
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
            Kill(target);
        }

    }

    public void Kill(GameObject target)
    {
            //gets the enemy id from the enemy gameobject name
            char[] idGet = { 'e','n','m','y'};
            int deathID = Int32.Parse(target.name.TrimStart(idGet));

            Destroy(target); //kills the enemy

            //replaces the enemy position in the list with an empty gameobject
            Debug.Log("DeathID is " + deathID);
            enemySpawner.enemyList[deathID] = Instantiate(empty);
            enemySpawner.enemyList[deathID].gameObject.tag = "ShootIgnore";

            Debug.Log("ID slot is " + enemySpawner.enemyList[deathID]);
            Debug.Log("DEATH for " + target.name);
    }


}

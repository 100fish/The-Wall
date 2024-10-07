using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Turret1ShootPREFAB : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public Transform turretAimPoint;
    public Transform turret;
    public Transform turretPoint;
    public Transform turretGun;
    public float distance = 200;
    private float shootTimer = 1;
    private int shootSpeed = 1;
    private LineRenderer lr;
    private Transform[] points;
    //public float hitForce = 20;

    //Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }


    void Shoot()
    {
        RaycastHit hit = new RaycastHit();


       // if (Physics.Raycast(turretGun.position, GetClosestEnemy(enemySpawner.enemyList), out hit, distance))
        {
            Debug.Log(hit.transform.name);
            Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(turret.forward, ForceMode.Impulse);

            }
        }
    }

    private Transform GetClosestEnemyPos(List<GameObject> enemies)
    {

        Transform tMin = null;
        float minDist = 3;
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

        GameObject target = null;
        float minDist = 3;
        Vector3 currentPOS = transform.position;
        foreach (GameObject t in enemies)
        {
            Transform tt = t.transform;
            float dist = Vector3.Distance(tt.position, currentPOS);
            if (dist < minDist)
            {
                target = t;
                minDist = dist;
            }
        }
        return target;
    }

    private void OnEnable()
    {
        points[0] = turretGun;
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
        if (shootTimer < 0)
        {
            GameObject target = GetClosestEnemy(enemySpawner.enemyList);
            points[1] = target.transform;

            for (int i = 0; i < points.Length; i++)
            {
                lr.SetPosition(i, points[i].position);
            }

            Destroy(target);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseDamage : MonoBehaviour
{

    public Turret1Shoot turret1Shoot;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {


            GameManager.Instance.health--;
            Debug.Log(other.gameObject);
            //Kill(other.gameObject);
        }

    }

    /*public void Kill(GameObject target)
    {
        //gets the enemy id from the enemy gameobject name
        char[] idGet = { 'e', 'n', 'm', 'y' };
        int deathID = Int32.Parse(target.name.TrimStart(idGet));

        Destroy(target); //kills the enemy

        //replaces the enemy position in the list with an empty gameobject
        Debug.Log("DeathID is " + deathID);
        enemySpawner.enemyList[deathID] = Instantiate(empty);
        enemySpawner.enemyList[deathID].gameObject.tag = "ShootIgnore";

        Debug.Log("ID slot is " + enemySpawner.enemyList[deathID]);
        Debug.Log("DEATH for " + target.name);
    }*/

}

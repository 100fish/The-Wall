using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    public GameObject blastboolet;
    public Transform spawnTransform;
    public float force = 500;

    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject newProjectile = Instantiate(blastboolet, 
                spawnTransform.position, 
                spawnTransform.rotation);
            newProjectile.GetComponent<Rigidbody>().AddForce(newProjectile.transform.forward * force);

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    
}

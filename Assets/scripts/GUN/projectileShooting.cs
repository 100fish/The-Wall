using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileShooting : MonoBehaviour
{
    public Transform gunAimPoint;
    public Transform gun;
    public Transform gunPoint;
    public float distance = 200;
    public float hitForce = 20;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInParent<Camera>();
    }


    void Shoot()
    {
        RaycastHit hit = new RaycastHit();


        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distance))
        {
            Debug.Log(hit.transform.name);
            Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(gun.forward * hitForce, ForceMode.Impulse);
                
            }
        }
    }


    
    // Update is called once per frame
    void Update()
    {
        gun.LookAt(gunAimPoint.forward * 100);
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        
    }
}

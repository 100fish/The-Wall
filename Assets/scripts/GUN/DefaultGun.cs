using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultGun : MonoBehaviour
{
    //JACK CODE



    public Transform shootPoint;
    public float distance = 10;
    LayerMask layerMask;
    

    // Start is called before the first frame update
    void Start()
    {
        layerMask = LayerMask.GetMask("Hittable");
        
    }

    // Update is called once per frame
    void Update()
    {

       // Debug.DrawLine(shootPoint.position, shootPoint.forward * 100, Color.red);

    }

    public void Fire()
    {
        RaycastHit HIT;
        if (Physics.Raycast(shootPoint.position, shootPoint.forward, out HIT, distance, layerMask))
        {
            Debug.Log("Hit object" + HIT.transform.name);
        }
    }


    
}

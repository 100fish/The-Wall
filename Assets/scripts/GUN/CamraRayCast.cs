using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CamraRayCast : MonoBehaviour
{
    //JACK CODE

    public int damageAmount = 1;
    // Start is called before the first frame update
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitResult = new RaycastHit();
            if (Physics.Raycast(ray, out hitResult))
            {
                //Debug.Log(hitResult.transform.name);

                //Have we hit target?
                //Cast Target Script
                //Call target function to destroy it.
                //
                //If so, send point to where it is being stored (Player?)

               
                    Target targetHit = hitResult.transform.GetComponent<Target>();
                    if (targetHit != null)
                    {
                     Debug.Log("Hit");
                        targetHit.Damage();
                    }

            }

        }
    }
}


using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CamraRayCast : MonoBehaviour
{
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
            RaycastHit HitResult = new RaycastHit();
            if (Physics.Raycast(ray, out HitResult))
            {
                Debug.Log(HitResult.transform.name);
            }

        }
    }
}


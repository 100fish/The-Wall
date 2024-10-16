using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    //JACK CODE


    private Camera cam;

   
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
    }


   /*Interaction interactable = other.GetComponent<Interaction>();

    if (interactable != null)
    {

        this.interactable = interactable;
    }*/
}

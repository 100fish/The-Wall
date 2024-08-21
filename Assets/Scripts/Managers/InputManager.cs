using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{

    [SerializeField]
    private Camera sceneCamera; //introduces a camera to work with

    private Vector3 lastPosition; //allows saving of the cursor's last position

    [SerializeField]
    private LayerMask placementLayermask; //Makes sure we are detecting the right later

    public event Action OnClick, OnExit;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            OnClick?.Invoke();
        if (Input.GetKeyDown(KeyCode.Escape))
            OnExit?.Invoke();
    }

    public bool isPointerOverUI()
        => EventSystem.current.IsPointerOverGameObject();

    public Vector3 GetSelectedMapPosition()
    {
        Vector3 mousePos = Input.mousePosition; //Stores the mouse's current positon as a Vector
        mousePos.z = sceneCamera.nearClipPlane; //sets the stored Z coordinate to in front of the camera so that objects not rendered arent' selected
        Ray ray = sceneCamera.ScreenPointToRay(mousePos); // Casts a ray from the camera to the mouseposition
        RaycastHit hit; //creates a variable for the Raycast function
        if (Physics.Raycast(ray, out hit, 100, placementLayermask)) //detects if the ran hit anything within 100 units
        {
            lastPosition = hit.point; //stores the mouse position as the coordinate the raycast sees
        }
        return lastPosition; //gives the position of what hovers over the mouse
    }
}

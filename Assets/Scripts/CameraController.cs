using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //SAM CODE

    public Transform cameraTransform;

    public Vector2 minXandY;
    public Vector2 maxXandY;

    

    public float normalSpeed;
    public float movementSpeed;
    public float movementTime;
    public float rotationAmount;
    public Vector3 zoomAmount;

    public Vector3 newPosition;
    

    public Vector3 dragStartPosition;
    public Vector3 dragCurrentPosition;

    public Vector3 rotateStartPosition;
    public Vector3 rotateCurrentPosition;

    public Quaternion newRotation;
    public Vector3 newZoom;

    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = cameraTransform.localPosition;

    }
    

    void LateUpdate()
    {
        
        HandleMovementInput();
    }
    void HandleMovementInput()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float sideInput = Input.GetAxis("Horizontal");



        newPosition += sideInput * Vector3.forward + -forwardInput * Vector3.right;

        /*
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            newPosition += (transform.forward * movementSpeed);
        }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            newPosition += (transform.forward * -movementSpeed);
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition += (transform.right * movementSpeed);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition += (transform.right * -movementSpeed);
        }*/



        newPosition.y = 35.4f;
        newPosition.x = Mathf.Clamp(newPosition.x, minXandY.x, maxXandY.x);
        newPosition.z = Mathf.Clamp(newPosition.z, minXandY.y, maxXandY.y);
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);

    }

}

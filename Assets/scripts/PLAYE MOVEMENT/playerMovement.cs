using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    





    public float movementSpeed = 5f;
    public float jumpHeight = 2f;

    public float fallGravityMultiplier = 2f;
    public float mouseSensitivity = 2.0f;
    public float pitchRange = 60.0f; 


    private float forwardInputValue;
    private float strafeInputValue;
    private bool jumpInput;



    private float terminalVelacity = 53f;
    private float verticalVelocity;

    private float roatateCameraPitch;

    private Camera firstPersonCam;

    private CharacterController characterController;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        firstPersonCam = GetComponentInChildren<Camera>();
    }
    void JumpAndGravity()
    {
        if (characterController.isGrounded)
        {
            if (verticalVelocity < 0.0f)
            {
                verticalVelocity = -2f;
            }
            if (jumpInput)
            {
                verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);

            }




        }
        else
        {
            if(verticalVelocity< terminalVelacity)
            {

                float gravityMultiplier = 1;
                if(characterController.velocity.y < -1)
                {
                    gravityMultiplier = fallGravityMultiplier;
                }
                verticalVelocity += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
            }
        }

          
    }




        
    
        
        
        
        void CameraMovement()
    {
        float rotateYaw = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotateYaw, 0);



        roatateCameraPitch += -Input.GetAxis("Mouse Y") * mouseSensitivity;
        roatateCameraPitch = Mathf.Clamp(roatateCameraPitch, -pitchRange, pitchRange);
        firstPersonCam.transform.localRotation = Quaternion.Euler(roatateCameraPitch, 0, 0);



    }



    // Update is called once per frame
    void Update()
    {
        forwardInputValue = Input.GetAxisRaw("Vertical");
        strafeInputValue = Input.GetAxisRaw("Horizontal");
        jumpInput = Input.GetButtonDown("Jump");
        Movement();
        JumpAndGravity();
        CameraMovement();

    }

    void Movement()
    {
        Vector3 direction = (transform.forward * forwardInputValue 
            + transform.right * strafeInputValue).normalized 
            * movementSpeed * Time.deltaTime;

        direction += Vector3.up * verticalVelocity * Time.deltaTime;

        characterController.Move(direction);
    }


























    // Start is called before the first frame update
    void Start()
    {
        
    }

}

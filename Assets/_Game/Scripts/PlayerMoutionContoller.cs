using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoutionContoller : MonoBehaviour
{
    public bool isMovingForward;
    public bool isMovingRight;
    public bool isMovingLeft;
    public bool isMovingBack;
    
    [SerializeField] private float speed;
    [SerializeField] private float mouseSensX;
    [SerializeField] private float mouseSensY;
    [SerializeField] private float mouseY;
    [SerializeField] private float joystickSensX;
    [SerializeField] private float joystickSensY;
    [SerializeField] private GameObject cam;
    [SerializeField] private Vector3 movement;
    [SerializeField] private Quaternion originrotation;
    [SerializeField] private Rigidbody myRB;
    [SerializeField] private PlayerPhysicsMovement playerPhysicsScript;
    [SerializeField] private FixedJoystick fixedJoystickScript;

    public void Start()
    {
        originrotation = transform.rotation;
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        RotateCameraByMouse();
        RotateCameraByJoystick();
        
        MakeDirrectionByBottoms();
        
        PlayerMoveByPhisics(movement);
        
    }

    public void PlayerMoveByPhisics(Vector3 dirrection)
    {
        
        playerPhysicsScript.Move(dirrection);

        
    }

    private void RotateCameraByMouse()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.rotation *= Quaternion.AngleAxis(mouseX * mouseSensX * Time.deltaTime, Vector3.up);

        mouseY += Input.GetAxis("Mouse Y") ;
        mouseY = Mathf.Clamp(mouseY, -15, 5);
        Quaternion rotationX = Quaternion.AngleAxis(-mouseY * mouseSensY, Vector3.right);
        cam.transform.rotation = originrotation * transform.rotation * rotationX;  
    }

    private void RotateCameraByJoystick()
    {
        float joystickX = fixedJoystickScript.Horizontal;
        transform.rotation *= Quaternion.AngleAxis(joystickX * joystickSensX * Time.deltaTime, Vector3.up);

        if (fixedJoystickScript.Vertical != 0)
        {
        //mouseY += fixedJoystickScript.Vertical;
        //mouseY = Mathf.Clamp(mouseY, 355, 5);
        //Quaternion rotationX = Quaternion.AngleAxis(-mouseY * joystickSensY, Vector3.right);
        //cam.transform.rotation = originrotation * transform.rotation * rotationX;
        }
    }

    private void MakeDirrectionByBottoms()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        MoutionDirrectionCheck(horizontalInput, verticalInput);

        movement = (transform.forward * verticalInput + transform.right * horizontalInput).normalized * speed;
    }

    private void MoutionDirrectionCheck(float horizontalInput, float verticalInput)
    {
        if (verticalInput > 0)
        {
            isMovingForward = true;
        }
        else
        {
            isMovingForward = false;
        }

        if (verticalInput < 0)
        {
            isMovingBack = true;
        }
        else
        {
            isMovingBack = false;
        }

        if (horizontalInput > 0)
        {
            isMovingRight = true;
        }
        else
        {
            isMovingRight = false;
        }
        
        if (horizontalInput < 0)
        {
            isMovingLeft = true;
        }
        else
        {
            isMovingLeft = false;
        }
    }
}

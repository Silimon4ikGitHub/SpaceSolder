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
    [SerializeField] private float mouseSens;
    [SerializeField] private float joystickSens;
    [SerializeField] private GameObject cam;
    [SerializeField] private Vector3 movement;
    [SerializeField] private Rigidbody myRB;
    [SerializeField] private PlayerPhysicsMovement playerPhysicsScript;
    [SerializeField] private FixedJoystick fixedJoystickScript;

    public void Start()
    {
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
        float mouseY = Input.GetAxis("Mouse Y");
        
        
        transform.rotation *= Quaternion.AngleAxis(mouseX * mouseSens * Time.deltaTime, Vector3.up);

        if(cam.transform.rotation.x > 10 && cam.transform.rotation.x < 30)
        {
            cam.transform.rotation *= Quaternion.AngleAxis(mouseY * mouseSens * Time.deltaTime, -Vector3.right);
        }
    }

    private void RotateCameraByJoystick()
    {
        float joystickX = fixedJoystickScript.Horizontal;
        transform.rotation *= Quaternion.AngleAxis(joystickX * mouseSens * Time.deltaTime, Vector3.up);
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

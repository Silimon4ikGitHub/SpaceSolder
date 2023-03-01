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
    private float mouseY;
    [SerializeField] private float joystickY;
    [SerializeField] private float joystickSensX;
    [SerializeField] private float joystickSensY;
    [SerializeField] private bool isJoystickController;
    [SerializeField] private bool isKeyBoardMouseController;
    [SerializeField]private bool isForwardButtonDown;
    [SerializeField]private bool isRightButtonDown;
    [SerializeField]private bool isLeftButtonDown;
    [SerializeField]private bool isBackwardButtonDown;
    [SerializeField] private GameObject cam;
    private Vector3 keyboardMovement;
    private Vector3 tuchScreenmovement;
    private Quaternion originrotation;
    [SerializeField] private Rigidbody myRB;
    [SerializeField] private PlayerPhysicsMovement playerPhysicsScript;
    [SerializeField] private FixedJoystick fixedJoystickScript;


    void Update()
    {
        if (isKeyBoardMouseController)
        {
            RotateCameraByMouse();
            MakeDirrectionByKeyboard();
        }
        
        else if (isJoystickController)
        {
            RotateCameraByJoystick();
            MakeDirrectionByJoysStick();
        }
        PlayerMoveByPhysics(keyboardMovement);
        PlayerMoveByPhysics(tuchScreenmovement);
    }

    public void PlayerMoveByPhysics(Vector3 dirrection)
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
        
        joystickY += fixedJoystickScript.Vertical;
        joystickY = Mathf.Clamp(joystickY, -30, 15);
        Quaternion rotationY = Quaternion.AngleAxis(-joystickY * joystickSensY, Vector3.right);
        cam.transform.rotation = originrotation * transform.rotation * rotationY;
    }

    private void MakeDirrectionByKeyboard()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        MoutionDirrectionCheck(horizontalInput, verticalInput);

        keyboardMovement = (transform.forward * verticalInput + transform.right * horizontalInput).normalized * speed;
    }

    public void MakeDirrectionByJoysStick()
    {
        float horizontalInput = 0;
        float verticalInput = 0;
        
        if (isForwardButtonDown)
        {
            verticalInput++;
        }
        else if (isRightButtonDown)
        {
            horizontalInput++;
        }
        else if (isLeftButtonDown)
        {
            horizontalInput--;
        }
        else if (isBackwardButtonDown)
        {
            verticalInput--;
        }
        else
        {
            verticalInput = 0;
            horizontalInput = 0;
        }
        
        MoutionDirrectionCheck(horizontalInput, verticalInput);
        tuchScreenmovement = (transform.forward * verticalInput + transform.right * horizontalInput).normalized * speed;
    }
    public void OnTuchScreenForwardButtonDown()
    {
        isForwardButtonDown = true;
    }
    public void OnTuchScreenForwardButtonUp()
    {
        isForwardButtonDown = false;
    }
    public void OnTuchScreenRightButtonDown()
    {
        isRightButtonDown = true;
    }
    public void OnTuchScreenRightButtonUp()
    {
        isRightButtonDown = false;
    }
    public void OnTuchScreenLeftButtonDown()
    {
        isLeftButtonDown = true;
    }
    public void OnTuchScreenLeftButtonUp()
    {
        isLeftButtonDown = false;
    }
    public void OnTuchScreenBackButtonDown()
    {
        isBackwardButtonDown = true;
    }
    public void OnTuchScreenBackButtonUp()
    {
        isBackwardButtonDown = false;
    }
    
    public void Start()
    {
        originrotation = transform.rotation;
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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

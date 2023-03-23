using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoutionContoller : MonoBehaviour
{
    [Header("Choose Controller")]
    public bool isJoystickController;
    public bool isKeyBoardMouseController;
    [Header("For Check Only")]
    [Header("Set MoveSpeed")]
    [SerializeField] private float speed;
    [Header("Set Sensitivity")]
    [SerializeField] private float mouseSensX;
    [SerializeField] private float mouseSensY;
    [SerializeField] private float joystickSensX;
    [SerializeField] private float joystickSensY;
    [SerializeField] private GameObject cam;
    [SerializeField] private Rigidbody myRB;
    [SerializeField] private PlayerPhysicsMovement playerPhysicsScript;
    [SerializeField] private FixedJoystick fixedJoystickScript;
    private float _mouseYLimitMax = 5;
    private float _mouseYLimitMin = -15;
    private float _joystickYLimitMax = 5;
    private float _joystickYLimitMin = -30;
    private float _mouseY;
    private float _joystickY;
    private bool _isForwardButtonDown;
    private bool _isRightButtonDown;
    private bool _isLeftButtonDown;
    private bool _isBackwardButtonDown;
    private Vector3 _keyboardMovement;
    private Vector3 _tuchScreenmovement;
    private Quaternion _originrotation;
    public MovingDirrectionData MovingData { get; private set; }

    public void Start()
    {
        _originrotation = transform.rotation;
    }

    void Update()
    {
        CheckInputDevice();

        if (isKeyBoardMouseController)
        {
            RotateCameraByMouse();
            MakeDirrectionByKeyboard();
            PlayerMoveByPhysics(_keyboardMovement);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
        else if (isJoystickController)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            RotateCameraByJoystick();
            MakeDirrectionByJoysStick();
            PlayerMoveByPhysics(_tuchScreenmovement);
        }
    }

    private void CheckInputDevice()
    {
        if (Input.GetAxis("Mouse Y") > 0 || Input.GetAxis("Mouse X") > 0)
        {
            isKeyBoardMouseController = true;
        }
    }

    public void PlayerMoveByPhysics(Vector3 dirrection)
    {
        playerPhysicsScript.Move(dirrection);
    }

    private void RotateCameraByMouse()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.rotation *= Quaternion.AngleAxis(mouseX * mouseSensX * Time.deltaTime, Vector3.up);

        _mouseY += Input.GetAxis("Mouse Y") ;
        _mouseY = Mathf.Clamp(_mouseY, _mouseYLimitMin, _mouseYLimitMax);
        Quaternion rotationX = Quaternion.AngleAxis(-_mouseY * mouseSensY, Vector3.right);
        cam.transform.rotation = _originrotation * transform.rotation * rotationX;  
    }

    private void MakeDirrectionByKeyboard()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        IsMoving(verticalInput, horizontalInput);

        _keyboardMovement = (transform.forward * verticalInput + transform.right * horizontalInput).normalized * speed;
    }

    private void RotateCameraByJoystick()
    {
        float joystickX = fixedJoystickScript.Horizontal;
        transform.rotation *= Quaternion.AngleAxis(joystickX * joystickSensX * Time.deltaTime, Vector3.up);
        
        _joystickY += fixedJoystickScript.Vertical;
        _joystickY = Mathf.Clamp(_joystickY, _joystickYLimitMin, _joystickYLimitMax);
        Quaternion rotationY = Quaternion.AngleAxis(-_joystickY * joystickSensY, Vector3.right);
        cam.transform.rotation = _originrotation * transform.rotation * rotationY;
    }

    public void MakeDirrectionByJoysStick()
    {
        float horizontalInput = 0;
        float verticalInput = 0;
        
        if (_isForwardButtonDown)
        {
            verticalInput++;
        }
        else if (_isRightButtonDown)
        {
            horizontalInput++;
        }
        else if (_isLeftButtonDown)
        {
            horizontalInput--;
        }
        else if (_isBackwardButtonDown)
        {
            verticalInput--;
        }
        else
        {
            verticalInput = 0;
            horizontalInput = 0;
        }

        IsMoving(verticalInput, horizontalInput);
        _tuchScreenmovement = (transform.forward * verticalInput + transform.right * horizontalInput).normalized * speed;
    }

    public void OnTuchScreenForwardButtonDown()
    {
        _isForwardButtonDown = true;
    }
    public void OnTuchScreenForwardButtonUp()
    {
        _isForwardButtonDown = false;
    }
    public void OnTuchScreenRightButtonDown()
    {
        _isRightButtonDown = true;
    }
    public void OnTuchScreenRightButtonUp()
    {
        _isRightButtonDown = false;
    }
    public void OnTuchScreenLeftButtonDown()
    {
        _isLeftButtonDown = true;
    }
    public void OnTuchScreenLeftButtonUp()
    {
        _isLeftButtonDown = false;
    }
    public void OnTuchScreenBackButtonDown()
    {
        _isBackwardButtonDown = true;
    }
    public void OnTuchScreenBackButtonUp()
    {
        _isBackwardButtonDown = false;
    }
    
    private bool MoutionDirrectionCheck(float Input)
    {
        bool dirrection = false;

        if (Input > 0)
        {
            dirrection = true;
        }

        return dirrection;
    }

    private MovingDirrectionData IsMoving(float vertical, float horizontal)
    {
        bool IsMovingForward = false;
        bool IsMovingBack = false;
        bool IsMovingRight = false;
        bool IsMovingLeft = false;

         if (vertical > 0)
            IsMovingForward = true;

        else if (vertical < 0)
            IsMovingBack = true;

         if (horizontal < 0)
            IsMovingRight = true;

        else if (horizontal > 0)
            IsMovingLeft = true;

        MovingData = new MovingDirrectionData(IsMovingForward, IsMovingRight, IsMovingLeft, IsMovingBack);
        return MovingData;
    }

    public struct MovingDirrectionData
    {
        public readonly bool IsMovingForward;
        public readonly bool IsMovingRight;
        public readonly bool IsMovingLeft;
        public readonly bool IsMovingBack;

        public MovingDirrectionData (bool isMovingForward, bool isMovingLeft, bool isMovingRight, bool isMovingBack)
        {
            IsMovingForward = isMovingForward;
            IsMovingRight = isMovingRight;
            IsMovingLeft = isMovingLeft;
            IsMovingBack = isMovingBack;
        }
    }
}

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
    [SerializeField] private float rotationSpeed = 100.0f;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private PlayerPhysicsMovement playerPhysicsMovement;
    [SerializeField] private GameObject camera;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        
        RotateCameraByMouse();
        PlayerMoveByPhisics();
        
    }

    public void PlayerMoveByPhisics()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = (transform.forward * verticalInput + transform.right * horizontalInput).normalized * speed;
        playerPhysicsMovement.Move(movement);

        MoutionDirrectionCheck(horizontalInput, verticalInput);
    }

    private void RotateCameraByMouse()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.rotation *= Quaternion.AngleAxis(mouseX * rotationSpeed * Time.deltaTime, Vector3.up);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoutionContoller : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float rotationSpeed = 100.0f;
    public bool isMovingForward;
    public bool isMovingRight;
    public bool isMovingLeft;
    public bool isMovingBack;
    

    void Update()
    {
        MovePlayerByButtoms();
        RotateCameraByMouse();


    }

    private void MovePlayerByButtoms()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position += transform.forward * vertical * speed * Time.deltaTime;
        transform.position += transform.right * horizontal * speed * Time.deltaTime;

        MoutionDirrectionCheck(horizontal, vertical);
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

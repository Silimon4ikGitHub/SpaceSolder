using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.UI;
using static PlayerMoutionContoller;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject camera;
    [SerializeField] private Transform aim;
    [SerializeField] private PlayerMoutionContoller playerMoutionScript;
    public ShootingData ShootData { get; private set; }

    void LateUpdate()
    {
        RaycastTargeting();
        ShootOnMouseDown();
    }

    private void RaycastTargeting()
    {
        Ray ray = new Ray(camera.transform.position, camera.transform.forward);
        Debug.DrawRay(camera.transform.position, camera.transform.forward * 10000, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) ;
        {
            aim.position = hit.point;

            if (hit.collider != null)
            {
                Selectable selectable = hit.collider.GetComponent<Selectable>();
                if (selectable)
                {
                    selectable.Select();
                }
            }
        }
    }

    private void ShootOnMouseDown()
    {
        if (playerMoutionScript.isKeyBoardMouseController)
        {
            bool isMouseDown;

            if (Input.GetKey(KeyCode.Mouse0))
                isMouseDown = true;
            else
                isMouseDown = false;

            IsShoot(isMouseDown);
        }
    }
    
    private ShootingData IsShoot(bool isMouseDown)
    {
        bool IsShooting;

        IsShooting = isMouseDown;

        ShootData = new ShootingData(IsShooting);
        return ShootData;
    }

    public struct ShootingData
    {
        public readonly bool IsShooting;

        public ShootingData(bool isShooting)
        {
            IsShooting = isShooting;
        }
    }
    
        
}

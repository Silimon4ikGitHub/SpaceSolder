using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject camera;
    [SerializeField] private Transform aim;
    [SerializeField] private PlayerMoutionContoller playerMoutionScript;
    public bool isShooting;

    void LateUpdate()
    {
        RaycastTargeting();
        ShootOnMouseDown();
    }

    private void RaycastTargeting()
    {
        Ray ray = new Ray(transform.position, camera.transform.forward);
        Debug.DrawRay(transform.position, camera.transform.forward * 10000, Color.red);

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
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Shoot();
            }
            else
            {
                NoShoot();
            }
        }
    }

    public void Shoot()
    {
        isShooting = true;
    }
    public void NoShoot()
    {
        isShooting = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour 
{
    
    [SerializeField] private Animator shooterAnimator;
    [SerializeField] private PlayerShooting playerShootingScript;
    private Animator playerAnimator;
    private PlayerMoutionContoller playerMoutionScript;
    void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        playerMoutionScript = GetComponent<PlayerMoutionContoller>();
    }

    void Update()
    {
        
        if (playerMoutionScript.MovingData.IsMovingForward)
        {
            playerAnimator.SetBool("isMovingForward", true);
        }
        else
        {
            playerAnimator.SetBool("isMovingForward", false);
        }

        if (playerMoutionScript.MovingData.IsMovingRight)
        {
            playerAnimator.SetBool("isMovingRight", true);   
        }
        else
        {
            playerAnimator.SetBool("isMovingRight", false);
        }

        if (playerMoutionScript.MovingData.IsMovingLeft)
        {
            playerAnimator.SetBool("isMovingLeft", true); 
        }
        else
        {
            playerAnimator.SetBool("isMovingLeft", false);
        }

        if (playerMoutionScript.MovingData.IsMovingBack)
        {
            playerAnimator.SetBool("isMovingBack", true); 
        }
        else
        {
            playerAnimator.SetBool("isMovingBack", false); 
        }

        if (playerShootingScript.ShootData.IsShooting)
        {
            shooterAnimator.SetBool("isShooting", true);
        }
        else
        {
            shooterAnimator.SetBool("isShooting", false);
        }
    }
}

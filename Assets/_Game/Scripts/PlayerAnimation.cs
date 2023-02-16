using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;
    [SerializeField] PlayerMoutionContoller playerMoutionScript;
    private bool _isMovingForward;
    private bool _isMovingRight;
    private bool _isMovingLeft;
    private bool _isMovingBack;
    void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        playerMoutionScript = GetComponent<PlayerMoutionContoller>();
    }

    void Update()
    {
        _isMovingForward = playerMoutionScript.isMovingForward;
        _isMovingRight = playerMoutionScript.isMovingRight;
        _isMovingLeft = playerMoutionScript.isMovingLeft;
        _isMovingBack = playerMoutionScript.isMovingBack;
        
        if (_isMovingForward)
        {
            playerAnimator.SetBool("isMovingForward", true);
        }
        else
        {
            playerAnimator.SetBool("isMovingForward", false);
        }

        if (_isMovingRight)
        {
            playerAnimator.SetBool("isMovingRight", true);   
        }
        else
        {
            playerAnimator.SetBool("isMovingRight", false);
        }

        if (_isMovingLeft)
        {
            playerAnimator.SetBool("isMovingLeft", true); 
        }
        else
        {
            playerAnimator.SetBool("isMovingLeft", false);
        }

        if (_isMovingBack)
        {
            playerAnimator.SetBool("isMovingBack", true); 
        }
        else
        {
            playerAnimator.SetBool("isMovingBack", false); 
        }
    }
}

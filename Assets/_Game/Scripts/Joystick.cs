using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    [SerializeField] private GameObject selectionTop;
    [SerializeField] private GameObject selectionRight;
    [SerializeField] private GameObject selectionLeft;
    [SerializeField] private GameObject selectionDown;
    [SerializeField] private PlayerMoutionContoller playerScript;

    void Update()
    {
        SideSelectorSwitch();
    }

    private void SideSelectorSwitch()
    {
        if (playerScript.isMovingForward)
        {
            selectionTop.SetActive(true);
        }
        else
        {
            selectionTop.SetActive(false);
        }

        if (playerScript.isMovingRight)
        {
            selectionRight.SetActive(true);
        }
        else
        {
            selectionRight.SetActive(false);
        }

        if (playerScript.isMovingLeft)
        {
            selectionLeft.SetActive(true);
        }
        else
        {
            selectionLeft.SetActive(false);
        }

        if (playerScript.isMovingBack)
        {
            selectionDown.SetActive(true);
        }
        else
        {
            selectionDown.SetActive(false);
        }
    }
}

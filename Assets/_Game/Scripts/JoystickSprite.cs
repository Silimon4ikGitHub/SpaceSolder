using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickSprite : MonoBehaviour
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
        if (playerScript.MovingData.IsMovingForward)
        {
            selectionTop.SetActive(true);
        }
        else
        {
            selectionTop.SetActive(false);
        }

        if (playerScript.MovingData.IsMovingRight)
        {
            selectionRight.SetActive(true);
        }
        else
        {
            selectionRight.SetActive(false);
        }

        if (playerScript.MovingData.IsMovingLeft)
        {
            selectionLeft.SetActive(true);
        }
        else
        {
            selectionLeft.SetActive(false);
        }

        if (playerScript.MovingData.IsMovingBack)
        {
            selectionDown.SetActive(true);
        }
        else
        {
            selectionDown.SetActive(false);
        }
    }
}

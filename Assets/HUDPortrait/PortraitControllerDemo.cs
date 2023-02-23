using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Simple demo script to showcase portrait changing functionality
public class PortraitControllerDemo : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PortraitController.Instance.ChangeMood(0);
        } 
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PortraitController.Instance.ChangeMood(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PortraitController.Instance.ChangeMood(2);
        }

    }
}

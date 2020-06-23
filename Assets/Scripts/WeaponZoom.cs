using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    public Camera mainCamera;
    public float zoomedOutFOV = 60f;
    public float zoomedInFOV = 20f;
    private bool zoomedInToggle;

    private void Update()
    {
        ToggleZoom();
    }

    private void ToggleZoom()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!zoomedInToggle)
            {
                zoomedInToggle = true;
                mainCamera.fieldOfView = zoomedInFOV;
            }
            else
            {
                zoomedInToggle = false;
                mainCamera.fieldOfView = zoomedOutFOV;
            }
        }
    }
}

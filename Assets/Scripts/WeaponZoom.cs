using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    public Camera mainCamera;
    public FirstPersonController fpsController;
    public float zoomedOutFOV = 60f;
    public float zoomedInFOV = 20f;
    public float zoomOutSensitivity = 2f;
    public float zoomInSensitivity = 0.5f;
    private bool zoomedInToggle;

    private void Update()
    {
        ToggleZoom();
    }

    private void OnDisable()
    {
        ZoomOut();
    }

    private void ToggleZoom()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!zoomedInToggle)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    private void ZoomIn()
    {
        zoomedInToggle = true;
        mainCamera.fieldOfView = zoomedInFOV;

        fpsController.m_MouseLook.XSensitivity = zoomInSensitivity;
        fpsController.m_MouseLook.YSensitivity = zoomInSensitivity;
    }

    private void ZoomOut()
    {
        zoomedInToggle = false;
        mainCamera.fieldOfView = zoomedOutFOV;

        fpsController.m_MouseLook.XSensitivity = zoomOutSensitivity;
        fpsController.m_MouseLook.YSensitivity = zoomOutSensitivity;
    }
}

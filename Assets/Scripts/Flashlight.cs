using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public float lightDecay = 0.1f;
    public float angleDecay = 1f;
    public float minAngle = 40f;

    Light light;

    private void Awake()
    {
        light = GetComponent<Light>();
    }

    private void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    public void RestoreLightAngle(float restoreAngle)
    {
        light.spotAngle = restoreAngle;
    }

    public void AddLightIntensity(float intensityAmount)
    {
        light.intensity += intensityAmount; 
    }

    private void DecreaseLightAngle()
    {
        if (light.spotAngle <= minAngle) { return; }

        light.spotAngle -= angleDecay * Time.deltaTime;
    }

    private void DecreaseLightIntensity()
    {
        light.intensity -= lightDecay * Time.deltaTime;
    }
}

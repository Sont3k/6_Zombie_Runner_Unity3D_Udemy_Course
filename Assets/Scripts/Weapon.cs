using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Camera FPSCamera;
    public float range = 100f;
    public float damage = 20f;
    public ParticleSystem muzzleFlash;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRaycast();
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit, range);

        if (hit.transform != null)
        {
            print(hit.transform.gameObject.name);
            //TODO add some hit effect for visual players
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            //TODO call a method on EnemyHealth that decreases the enemy's health
            target.TakeDamage(damage);
        }
    }
}

using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Camera FPSCamera;
    public float range = 100f;
    public float damage = 20f;
    public ParticleSystem muzzleFlash;
    public GameObject hitEffect;
    public float vfxDestroyDelay = 0.1f;
    public Ammo ammoSlot;
    public AmmoType ammoType;
    private bool canShoot = true;
    public float timeBetweenShots = 0.5f;

    private void OnEnable()
    {
        canShoot = true;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        canShoot = false;

        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }

        yield return new WaitForSecondsRealtime(timeBetweenShots);
        canShoot = true;
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
            CreateHitImpact(hit);
            //TODO add some hit effect for visual players
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            //TODO call a method on EnemyHealth that decreases the enemy's health
            target.TakeDamage(damage);
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        var impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, vfxDestroyDelay);
    }
}

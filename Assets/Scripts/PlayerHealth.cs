using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 10f;
    private DeathHandler deathHandler;
    private DisplayDamage displayDamageCanvas;

    private void Awake()
    {
        deathHandler = GetComponent<DeathHandler>();
        displayDamageCanvas = GetComponent<DisplayDamage>();
    }

    public void TakeDamage(float damage)
    {
        if (health > damage)
        {
            health -= damage;
            StartCoroutine(displayDamageCanvas.ToggleDamageCanvas());
        }
        else
        {
            deathHandler.HandleDeath();
        }
    }
}

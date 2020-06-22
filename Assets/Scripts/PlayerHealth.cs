using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 10f;
    private DeathHandler deathHandler;

    private void Awake()
    {
        deathHandler = GetComponent<DeathHandler>();
    }

    public void TakeDamage(float damage)
    {
        if (health > damage)
        {
            health -= damage;
        }
        else
        {
            deathHandler.HandleDeath();
        }
    }
}

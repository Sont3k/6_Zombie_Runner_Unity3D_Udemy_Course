using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 10f;

    public void TakeDamage(float damage)
    {
        if (health > damage)
        {
            health -= damage;
        }
        else
        {
            Destroy(gameObject);
            print("Player is dead");
        }
    }
}

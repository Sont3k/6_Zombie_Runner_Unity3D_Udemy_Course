using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float hitPoints = 100f;

    //TODO create a public method, which reduces hitpoins by the amount of damage
    public void TakeDamage(float damage)
    {
        if (hitPoints > damage)
        {
            hitPoints -= damage;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

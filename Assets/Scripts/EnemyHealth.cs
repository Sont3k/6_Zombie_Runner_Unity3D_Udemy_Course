using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float hitPoints = 100f;
    public float dyingDelay = 5f;
    
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");

        if (hitPoints > damage)
        {
            hitPoints -= damage;
        }
        else
        {
            animator.SetTrigger("die");
            Destroy(gameObject, dyingDelay);
        }
    }
}

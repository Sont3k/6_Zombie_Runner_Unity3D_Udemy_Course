using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private PlayerHealth target;
    public float damage = 40f;

    // Start is called before the first frame update
    void Awake()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if (target)
        {
            target.TakeDamage(damage);
        }
    }
}

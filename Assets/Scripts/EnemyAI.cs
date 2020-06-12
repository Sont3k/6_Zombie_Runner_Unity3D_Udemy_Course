using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public float chaseRange = 5f;

    private NavMeshAgent navMeshAgent;
    private float distanceToTarget = Mathf.Infinity;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        EngageTarget();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    private void EngageTarget()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (distanceToTarget >= navMeshAgent.stoppingDistance && distanceToTarget <= chaseRange)
        {
            ChaseTarget();
        }
        else if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.transform.position);
    }

    private void AttackTarget()
    {
        // Attack player
        print($"{name} has seeked and is destroying {target.name}");
    }
}

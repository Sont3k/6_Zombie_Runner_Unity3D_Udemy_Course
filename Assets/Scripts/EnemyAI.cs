using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float chaseRange = 5f;

    private NavMeshAgent navMeshAgent;
    private float distanceToTarget = Mathf.Infinity;

    private Animator animator;
    private Transform target;
    public float turnSpeed = 5f;
    private bool isProvoked;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        target = FindObjectOfType<PlayerHealth>().transform;
    }

    void Update()
    {
        EngageTarget();
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    private void EngageTarget()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        FaceTarget();

        if ((distanceToTarget >= navMeshAgent.stoppingDistance && distanceToTarget <= chaseRange) || isProvoked)
        {
            ChaseTarget();
        }
        else
        {
            Idle(); // seems ok
        }
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        animator.SetBool("attack", false);
        animator.SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        animator.SetBool("attack", true);
        // Attack player
        print($"{name} has seeked and is destroying {target.name}");
    }

    private void Idle()
    {
        animator.SetTrigger("idle");
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
}

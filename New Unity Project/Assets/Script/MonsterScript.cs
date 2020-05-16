using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterScript : MonoBehaviour
{
    int health;
    float lookRadius = 20f;

    Transform target;
    NavMeshAgent agent;
    HealthBarScript healthBar;
    Animator animator;

    private void Start()
    {
        health = 100;
        healthBar = transform.GetComponentInChildren<HealthBarScript>();
        healthBar.SetMaxHealth(health);

        target = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius || health < 100)
        {
            animator.SetTrigger("IsRunning");
            agent.SetDestination(target.position);
        }
        if (distance <= agent.stoppingDistance + agent.radius)
        {
            animator.SetTrigger("IsAttacking");
        }
        else if (agent.remainingDistance <= agent.stoppingDistance)
        {
            animator.SetTrigger("IsIdle");
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Dead"))
        {
            Die();
        }
    }

    /// <summary>
    /// Enemy takes damage
    /// </summary>
    /// <param name="damage">damage amount</param>
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
        if (health <= 0f)
        {
            animator.SetTrigger("IsDead");
        }
    }

    void Die()
    {
        target.GetComponentInChildren<PlayerGunController>().IncreaseCounter();
        Destroy(gameObject);
    }
}

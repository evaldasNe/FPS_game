﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
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

        if (distance <= lookRadius)
        {
            animator.SetBool("isWalking", true);
            agent.SetDestination(target.position);
        }

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
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
            animator.SetBool("isFallingBack", true);
        }
    }

    void Die()
    {
        target.GetComponentInChildren<PlayerGunController>().IncreaseCounter();
        Destroy(gameObject);
    }
}

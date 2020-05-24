using DarkTreeFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    public int health;
    float lookRadius = 20f;

    public Transform target;
    public EnemySpawner es;
    NavMeshAgent agent;
    HealthBarScript healthBar;
    Animator animator;
    Collider coll;

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

        var currentScene = SceneManager.GetActiveScene().name;

        if (distance <= lookRadius || health < 100 || currentScene == "Level2")
        {
            animator.SetBool("isWalking", true);
            agent.SetDestination(target.position);
        }
        if (distance <= agent.stoppingDistance + agent.radius)
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
        if (es != null)
            es.EnemyEliminated();

        Destroy(gameObject);
        GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>().IncreaseMoney(50);
    }
}

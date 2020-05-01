using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    int health;
    float lookRadius = 20f;

    Transform target;
    NavMeshAgent agent;
    HealthBarScript healthBar;

    private void Start()
    {
        health = 100;
        healthBar = transform.GetComponentInChildren<HealthBarScript>();
        healthBar.SetMaxHealth(health);

        target = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
        }
    }

    /// <summary>
    /// Take damage from shooting
    /// </summary>
    /// <param name="damage">The amount of damage</param>
    /// <returns>If object dies returns true, else false</returns>
    public bool TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
        if (health <= 0f)
        {
            Die();
            return true;
        }
        return false;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

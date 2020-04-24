using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    int health;

    HealthBarScript healthBar;

    private void Start()
    {
        health = 100;
        healthBar = transform.GetComponentInChildren<HealthBarScript>();
        healthBar.SetMaxHealth(health);
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

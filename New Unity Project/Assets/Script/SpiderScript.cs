﻿using DarkTreeFPS;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.AI;

public class SpiderScript : MonoBehaviour
{
    int health;
    float lookRadius = 20f;
    bool isDead = false;
    DateTime deathTime;
    DateTime attackTime;
    int damage = 1;

    public Transform target;
    public EnemySpawner es;
    NavMeshAgent agent;
    HealthBarScript healthBar;
    Animation anim;

    private void Start()
    {
        health = 100;
        healthBar = transform.GetComponentInChildren<HealthBarScript>();
        healthBar.SetMaxHealth(health);

        target = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animation>();
        anim.Play("idle");
    }

    private void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (isDead)
        {

            if ((DateTime.Now - deathTime).TotalSeconds >= anim["death2"].length)
            {
                Die();
            }
        }
        else
        {
            if (distance <= lookRadius || health < 100)
            {
                if (!anim.IsPlaying("attack2"))
                {
                    anim.Play("run");
                }
                agent.SetDestination(target.position);
            }
            if (distance <= agent.stoppingDistance + agent.radius)
            {
                anim.Play("attack2");
                if (attackTime == null)
                {
                    if (GameObject.Find("Player").GetComponent<PlayerStats>())
                    {
                        GameObject.Find("Player").GetComponent<PlayerStats>().ApplyDamage(damage);
                    }
                    else
                    {
                        target.GetComponentInChildren<PlayerGunController>().TakeDamage(damage);
                    }
                    attackTime = DateTime.Now;
                } 
                else if ((DateTime.Now - attackTime).TotalSeconds >= anim["attack2"].length)
                {
                    if (GameObject.Find("Player").GetComponent<PlayerStats>())
                    {
                        GameObject.Find("Player").GetComponent<PlayerStats>().ApplyDamage(damage);
                    }
                    else
                    {
                        target.GetComponentInChildren<PlayerGunController>().TakeDamage(damage);
                    }
                    attackTime = DateTime.Now;
                }
            }
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
            anim.Play("death2");
            deathTime = DateTime.Now;
            isDead = true;
            agent.SetDestination(transform.position);
        }
    }

    void Die()
    {
        Destroy(gameObject);
        if (es != null)
            es.EnemyEliminated();

        GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>().IncreaseMoney(50);
    }
}

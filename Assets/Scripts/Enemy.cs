using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    
    [HideInInspector]
    public float speed;

    public float startHealth = 100f; 

    private float health;

    public int worth = 50;

    public GameObject deathEffect;

    [Header("Unity Stuff")] 
    public Image healthBar;

    private bool isDead = false;

    private NavMeshAgent enemyNavMesh;

    private void Start()
    {
        speed = startSpeed;
        health = startHealth;

        enemyNavMesh = GetComponent<NavMeshAgent>();
        enemyNavMesh.speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow (float pct)
    {
        enemyNavMesh.speed = startSpeed * (1f - pct);
    }
    
    private void Die()
    {
        isDead = true;
        PlayerStats.Money += worth;

        var effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.enemiesAlive--;
        
        Destroy(gameObject);
    }
}

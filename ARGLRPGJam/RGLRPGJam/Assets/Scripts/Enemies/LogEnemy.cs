﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}

public class LogEnemy : MonoBehaviour
{
    [Header("State Machine")]
    public EnemyState currentState;
    
    [Header("EnemyStats")]
    public floatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    private float deathFXtime = 1.2f; 
    
    [Header("DeathFX")]
    public GameObject deathFX;

    private void Awake ()
    {
         health = maxHealth.initialValue;
    }

    private void TakeDamage(float damage)
    {
        health -=damage;
        if (health <= 0)
        {
            DeathEffect();
            this.gameObject.SetActive(false);
        }
    }

    private void DeathEffect()
    {
        if (deathFX != null)
        {
            GameObject effect = Instantiate(deathFX, transform.position, Quaternion.identity);
            Destroy (effect, deathFXtime);
        }
    }

    public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(myRigidbody, knockTime));
        TakeDamage(damage);
    }

    
    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime)
    {
        if (myRigidbody != null )
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = EnemyState.idle ;
            myRigidbody.velocity = Vector2.zero;
        }
    }
    
}
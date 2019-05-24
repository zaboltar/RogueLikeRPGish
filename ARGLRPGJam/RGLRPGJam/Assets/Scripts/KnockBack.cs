using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float thrust;
    public float KnockTime;

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
                enemy.GetComponent<LogEnemy>().currentState = EnemyState.stagger;
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * thrust;
                enemy.AddForce(difference, ForceMode2D.Impulse);

                if (enemy != null)
                {
                    StartCoroutine(KnockCo(enemy));
                }
                
            }
        }
    }

    private IEnumerator KnockCo(Rigidbody2D enemyRB)
    {
        if (enemyRB != null)
        {
            yield return new WaitForSeconds(KnockTime);
            enemyRB.velocity = Vector2.zero;
            enemyRB.GetComponent<LogEnemy>().currentState = EnemyState.idle ;
            
        }
    }
}

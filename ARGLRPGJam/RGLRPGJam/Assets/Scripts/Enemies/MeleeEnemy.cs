using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Log
{
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void CheckDistance()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
        if (Vector3.Distance(target.position, transform.position)
         <= chaseRadius && Vector3.Distance
         (target.position, transform.position) > attackRadius )
        {
            if (currentState == EnemyState.idle 
            || currentState == EnemyState.walk 
            && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards
                (transform.position, target.position,
                 moveSpeed * Time.deltaTime);
               
                ChangeAnim(temp - transform.position);
                myRigidBody.MovePosition(temp);
                
                ChangeState(EnemyState.walk);
                
            }
            
            
        } else if (Vector3.Distance(target.position, transform.position)
         <= chaseRadius && Vector3.Distance
         (target.position, transform.position) <= attackRadius )
         {
              if (currentState == EnemyState.walk 
            && currentState != EnemyState.stagger)
            {
                 StartCoroutine(AttackCo());
            }
            
         }

    }

    public IEnumerator AttackCo()
    {
        currentState = EnemyState.attack;
        anim.SetBool("Attack", true);
        yield return new WaitForSeconds(1f);
        currentState = EnemyState.walk;
        anim.SetBool("Attack", false);
       
    }

}

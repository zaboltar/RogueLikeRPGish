﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogArea : Log
{
    public Collider2D zoneBoundary;
    
    public override void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius 
            && Vector3.Distance(target.position, transform.position) > attackRadius 
            && zoneBoundary.bounds.Contains(target.transform.position))
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk 
                && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
               
                ChangeAnim(temp - transform.position);
                myRigidBody.MovePosition(temp);
                
                ChangeState(EnemyState.walk);
                anim.SetBool("WakeUp", true);
            }
            
            
        } else if (Vector3.Distance(target.position, transform.position) > chaseRadius
                    || !zoneBoundary.bounds.Contains(target.transform.position))
        {
            anim.SetBool("WakeUp", false);
        }
    }
}

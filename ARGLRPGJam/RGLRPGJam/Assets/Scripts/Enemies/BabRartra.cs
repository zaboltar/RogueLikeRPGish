using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabRartra : MonoBehaviour
{
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public Animator anim;
    private Rigidbody2D myRigidBody;
    public float moveSpeed =3f;
    public bool isOgre = false;
    public Collider2D colliderToDisableOnTransmute;

    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        colliderToDisableOnTransmute = GetComponent<Collider2D>();
    }



    void ReallyDie()
    {
		Destroy (gameObject);
    }

   public void Transmute()
    {
        
        anim.SetBool("Attack", false);
        anim.SetBool("Transmute", true);
        StartCoroutine(AnimateCo());
        anim.SetBool("IsOgre", true);
    }

    private IEnumerator AnimateCo()
    {
        isOgre = true;
        colliderToDisableOnTransmute.enabled = false;
        myRigidBody.isKinematic = true;

        yield return new WaitForSeconds(7.2f);

        myRigidBody.isKinematic = false;
        colliderToDisableOnTransmute.enabled = true;
        anim.SetBool("Transmute", false);
        anim.SetBool("OgreAttack", true);
    }

    void FixedUpdate()
    {
        CheckDistance();
    }

       void CheckDistance()

        {
            if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius )
                {   
                    Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                    myRigidBody.MovePosition(temp);
                    anim.SetFloat("Speed", moveSpeed);
                }

        }



    // if babRartra in collider range => attack him
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Attack", true);

            if (isOgre)
            {   anim.SetBool("Attack", false);
                anim.SetBool("OgreAttack", true);
            } 
            
            
        }
    }


    // if player leaves collider range; go to chase/idle
    void OnTriggerExit2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Attack", false);
        }
    }
}

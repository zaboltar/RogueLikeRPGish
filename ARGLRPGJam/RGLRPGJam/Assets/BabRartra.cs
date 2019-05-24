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



    // Start is called before the first frame update
    void Start()
    {
 

        target = GameObject.FindGameObjectWithTag("Player").transform;
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
        
        yield return new WaitForSeconds(2f);
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

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Attack", true);
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Attack", false);
        }
    }
}

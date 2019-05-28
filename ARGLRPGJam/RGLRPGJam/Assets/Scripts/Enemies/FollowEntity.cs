using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEntity : MonoBehaviour
{
    public float speed;
    public float stoppingDistance = 2f;
    private Transform target;
    private Animator anim;

    private Vector3 lastEnemyPos;
    private SpriteRenderer rend;


    // Start is called before the first frame update
    void Start()
    {
        lastEnemyPos = transform.position;
		rend = transform.GetComponent<SpriteRenderer>();
        
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            anim.SetBool("PetMoving", true);
        } else
        {
            anim.SetBool("PetMoving", false);
        }

        // pregunta por FlipX

        if ((transform.position.x - lastEnemyPos.x) > 0 && rend.flipX) {
            rend.flipX = false;
        } else if ((transform.position.x - lastEnemyPos.x) < 0 && !rend.flipX) {
            rend.flipX = true;
        }

        // guardar mov de nuevo
        lastEnemyPos = transform.position;
	}
    
}

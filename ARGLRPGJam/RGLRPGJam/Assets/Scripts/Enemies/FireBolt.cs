using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBolt : MonoBehaviour
{
   public float speed;
   public int currentDamage = 1;
   private Transform player;
   private Vector2 target;

   public GameObject damageNumber;
   
   void Start ()
   {
       player = GameObject.FindGameObjectWithTag("Player").transform;
       target = new Vector2 (player.position.x, player.position.y);
   }

   void Update ()
   {
       transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyFireBolt();
        }
   }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealthManager>().HurtPlayer(currentDamage);
            var clone = (GameObject) Instantiate(damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));
			clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
            DestroyFireBolt();
        }
    }

   void DestroyFireBolt()
   {
      Destroy(gameObject);

   }

 
}

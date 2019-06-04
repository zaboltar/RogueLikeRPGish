using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Signal context;
    public bool playerInRange;

   

 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger )
        {
            // player in range
            if (context != null)
            {
                context.Raise();
            }
            
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")  && !other.isTrigger )
        {
            // player out of range
            if (context != null)
            {
                context.Raise();
            }
            
            playerInRange = false;
            
        }
    }

}

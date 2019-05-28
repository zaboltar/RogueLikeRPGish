using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContextHintNPC : MonoBehaviour

{
    public Signal contextOn;
    public Signal contextOff;
    
  
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") )
        {
            // player in range
            contextOn.Raise();
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") )
        {
            // player out of range
            contextOff.Raise();
           
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveContainer : PowerUp
{
    public floatValue heartContainers;
    public floatValue playerHealth;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            heartContainers.RuntimeValue += 1;
            playerHealth.RuntimeValue = heartContainers.RuntimeValue * 2;
            powerUpSignal.Raise();
            
            Destroy(this.gameObject);
        }
    }
}

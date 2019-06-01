﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Log[] enemies; //log o logEnemy
    public Pot[] pots;

    public virtual void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            // activate all enemies and pots
            for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActivation(enemies[i], true);
            }

             for (int i = 0; i < pots.Length; i++)
            {
                ChangeActivation(pots[i], true);
            }
            
        }
    }

     public virtual void OnTriggerExit2D (Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            // deactivate all enemies & pots
              for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActivation(enemies[i], false);
            }

             for (int i = 0; i < pots.Length; i++)
            {
                ChangeActivation(pots[i], false);
            }
        }
    }

    void ChangeActivation(Component component, bool activation)
    {
        component.gameObject.SetActive(activation);
    }
}

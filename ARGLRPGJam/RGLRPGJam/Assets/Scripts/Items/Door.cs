using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum DoorType
{
    key,
    enemy,
    button
}

public class Door : Interactable
{
    [Header("Door Variables")]
    public DoorType thisDoorType;
    public bool open = false;
    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;

  

void Update ()
{
    if (Input.GetKeyDown(KeyCode.E))
    {
        if (playerInRange && thisDoorType == DoorType.key)
        {
            //Does player got key?
            if (playerInventory.numberOfKeys > 0)
            {
                //remove player key
                playerInventory.numberOfKeys--;
                // if so, call open method
                Open();

                
            }
            
        }
    }
}

public void Open()
{
    //turn off doors sprite rend
    doorSprite.enabled = false;
    
    //set open to true
    open = true;
    // turn of the doors collider!
    physicsCollider.enabled = false;
} 

public void Close()
{

}

}

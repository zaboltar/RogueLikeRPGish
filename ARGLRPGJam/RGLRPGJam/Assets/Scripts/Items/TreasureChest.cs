using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{
    [Header("Contents")]
    public Item contents;
    public Inventory playerInv;
    public bool isOpen;
    public boolValue storedOpen;

    [Header("Signals & Dialog")]
    public Signal raiseItem;
    public GameObject dialogBox;
    public Text dialogText;
    
    private Animator anim;

    void Start()
    {
        anim = GetComponent <Animator>();
        isOpen = storedOpen.RuntimeValue;
        if (isOpen)
        {
            anim.SetBool("Open", true);
        }
    }

    void Update()
    {
         if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            if (!isOpen)
            {
                //open the chest
                OpenChest();
            }    else
            {
                //chest is already open
                ChestAlreadyOpen();
            }
        }
    }

    public void OpenChest ()
    {
        //dialog window on
        dialogBox.SetActive(true);
        //dialog text = contents text
        dialogText.text = contents.itemDescription;
        //add contents to inventory
        playerInv.AddItem(contents);
        playerInv.currentItem = contents;
        //raise the signal to player to animate
        raiseItem.Raise();
        //set the chest to opened
            isOpen = true;
       
        // raise the context clue
        context.Raise();
        anim.SetBool("Open", true);
        StartCoroutine(CloseDBoxCo());
        storedOpen.RuntimeValue = isOpen;
    }

    IEnumerator CloseDBoxCo()
    {
        yield return new WaitForSeconds(3);
        dialogBox.SetActive(false);
    }

    public void ChestAlreadyOpen()
    {
        
            //dialog window off
            dialogBox.SetActive(false);
             // set current item to empty
           // playerInv.currentItem = null;
             // raise the signal to player to stop anim
            raiseItem.Raise();
            
        
        
    }

     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen )
        {
            // player in range
            context.Raise();
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")  && !other.isTrigger && !isOpen )
        {
            // player out of range
            context.Raise();
            playerInRange = false;
            
        }
    }
}


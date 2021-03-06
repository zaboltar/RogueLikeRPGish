﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    [Header("Inventory Information")]
    public PlayerInventory playerInventory;
    
    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject inventoryPanel; // CONTENT -.-
    [SerializeField] private Text descriptionText;
    [SerializeField] private GameObject useButton;
    public InventoryItem currentItem;

    public void SetTextAndButton(string description, bool buttonActive)
    {
        descriptionText.text = description;
        if (buttonActive)
        {
            useButton.SetActive (true);

        } else
        {
            useButton.SetActive (false);
        }
    }

    void MakeInventorySlots()
    {
        if (playerInventory)
        {
            for(int i = 0; i < playerInventory.myInventory.Count; i++)
            {
                GameObject temp = Instantiate (blankInventorySlot, inventoryPanel.transform.position, Quaternion.identity);
                temp.transform.SetParent(inventoryPanel.transform);
                InventorySlot newSlot = temp.GetComponent<InventorySlot>();
                
                if (newSlot)
                {
                    
                    newSlot.Setup(playerInventory.myInventory[i], this);
                }
            }
        }
    }

    
    void Start()
    {
        MakeInventorySlots();
        SetTextAndButton("", false);
    }

   public void SetupDescriptionAndButton(string newDescriptionString,
    bool isButtonUsable, InventoryItem newItem)
   {
       currentItem = newItem;
       descriptionText.text = newDescriptionString;
       useButton.SetActive(isButtonUsable);
   }

   public void UseButtonPressed()
   {
       if (currentItem)
       {
           currentItem.Use();
       }
   }
}

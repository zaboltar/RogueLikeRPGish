﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// esta es la 1era version del inv !

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
  public Item currentItem;
  public List <Item> items = new List <Item>();
  public int numberOfKeys;
  public int coins;
  public float maxMagic = 10f;
  public float currentMagic;

  public void AddItem(Item itemToAdd)
  {
      // is the item a key?
      if (itemToAdd.isKey)
      {
          numberOfKeys ++;
      } else
      {
          if (!items.Contains(itemToAdd))
          {
              items.Add(itemToAdd);
          }
      }
  }
}

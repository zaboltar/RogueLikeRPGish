using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public Inventory playerInventory;
    public Text coinDisplay;

    public void UpdateCoinCount()
    {
        coinDisplay.text = "" + playerInventory.coins;
    }
}

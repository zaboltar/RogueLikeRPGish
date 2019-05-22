using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickUp : MonoBehaviour
{
    public int value;
    public MoneyManager theMM;
    private SFXManager sfxMan;
    // Start is called before the first frame update
    void Start()
    {   
        theMM = FindObjectOfType<MoneyManager>();
        sfxMan = FindObjectOfType<SFXManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" )
        {
            theMM.AddMoney(value);
            sfxMan.coinPick.Play();
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    public LootTable thisLoot;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Smash()
    {
        anim.SetBool("Smashed", true);
        StartCoroutine (BreakCo());
    }

    IEnumerator BreakCo ()
    {
            MakeLoot();
           /*  if (roomSignal != null )
            {
                roomSignal.Raise();
            }*/
            
            
        yield return new WaitForSeconds(.3f);
        this.gameObject.SetActive(false);

    }

       private void MakeLoot()
    {
        if (thisLoot != null)
        {
            PowerUp current = thisLoot.LootPowerUp();
            if (current != null )
            {
                Instantiate (current.gameObject, transform.position, Quaternion.identity);
            }
        }
    }


}

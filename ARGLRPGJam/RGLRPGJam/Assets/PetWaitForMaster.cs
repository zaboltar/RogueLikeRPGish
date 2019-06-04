using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetWaitForMaster : MonoBehaviour
{

    public GameObject petFollow;

    void Start ()
    {
        petFollow.GetComponent<FollowEntity>().enabled = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            petFollow.GetComponent<FollowEntity>().enabled = true;
        }
    }


}

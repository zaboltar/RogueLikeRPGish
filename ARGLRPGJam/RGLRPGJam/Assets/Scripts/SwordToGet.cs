using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordToGet : MonoBehaviour
{

    public GameObject gratzText;
    public AudioSource gratzAudio;

void OnTriggerEnter2D(Collider2D other)
{
    

    if (other.gameObject.CompareTag("Player")) 
    {
        other.GetComponent<PlayerUnSwordController>().hasSword = true;
        other.GetComponent<PlayerUnSwordController>().Sword.gameObject.SetActive(true);
        gratzText.SetActive(true);
        gratzAudio.Play();
        gameObject.SetActive(false);

    }
}
}

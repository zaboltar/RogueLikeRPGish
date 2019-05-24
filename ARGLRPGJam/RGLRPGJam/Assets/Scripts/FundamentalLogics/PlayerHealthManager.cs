﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {

	public int playerMaxHealth;
	public int playerCurrentHealth;

	private bool flashActive;
	public float flashLength;
	private float flashCounter;
	private SpriteRenderer playerSprite;
	private SFXManager sfxMan;



	// Use this for initialization
	void Start () {
		
		playerCurrentHealth = playerMaxHealth;
		sfxMan = FindObjectOfType<SFXManager>();
		playerSprite = GetComponent<SpriteRenderer>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(playerCurrentHealth <= 0)
		{
			//death

			sfxMan.playerDead.Play();
			gameObject.SetActive(false);
			


		}

		if(flashActive)
		{

			if(flashCounter > flashLength * .66f)
			{
				playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
			} else if (flashCounter > flashLength * .33f)
			{
				playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
				} else if (flashCounter > 0f)
				{
					playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
				} else 
						{
				playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);

				flashActive = false;
			}
		
			flashCounter -= Time.deltaTime;

		}

	}	


	public void HurtPlayer(int damageToGive)
	{
		playerCurrentHealth -= damageToGive;

		flashActive = true;
		flashCounter = flashLength;

		if (sfxMan != null)
		{
			sfxMan.playerHurt.Play();
		}
		
	}


	public void SetMaxHealth()
	{
		playerCurrentHealth = playerMaxHealth;
	}

}

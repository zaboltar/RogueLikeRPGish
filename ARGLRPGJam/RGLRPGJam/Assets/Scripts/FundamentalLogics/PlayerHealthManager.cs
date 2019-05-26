using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour {

	public int playerMaxHealth;
	public int playerCurrentHealth;

	private bool flashActive;
	public float flashLength;
	private float flashCounter;
	private SpriteRenderer playerSprite;
	private SFXManager sfxMan;
	
	// to destroy on death
	//public GameObject canvasToDestroy;
	//public GameObject audioToDestroy;
	//public GameObject cameraToDestroy;
	//public GameObject playerToDestroy;


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
			
			//Destroy(canvasToDestroy);
			//Destroy(audioToDestroy);
			//Destroy(cameraToDestroy);
			//Destroy(playerToDestroy);
// me salen errores horribles por ser tan cavernícola al hard resetear todo
			sfxMan.playerDead.Play();
			//gameObject.SetActive(false);
			//SceneManager.LoadScene(0);
			
			// apply penalties &
			// show it on canvas
			// reset quest manager?
			


			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			SetMaxHealth();

			
			


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

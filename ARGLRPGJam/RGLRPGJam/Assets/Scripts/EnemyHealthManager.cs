using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

	public int maxHealth;
	public int currentHealth;

	private PlayerStats thePlayerStats;

	public int expToGive;

	// Use this for initialization
	void Start () {
	currentHealth = maxHealth;	

	thePlayerStats = FindObjectOfType<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update () {
		if(currentHealth <=0)
		{
			Destroy (gameObject);

			thePlayerStats.AddExperience(expToGive);
		}
	}

	public void HurtEnemy(int damageToGive)
	{
		currentHealth -= damageToGive;
	}


	public void SetMaxHealth ()
	{
		currentHealth = maxHealth;
	}




}


﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

	public int maxHealth;
	public int currentHealth;

	private PlayerStats thePlayerStats;

	public int expToGive;

	public string enemyQuestName;
	private gpjQuestManager theQM;

	// Use this for initialization
	void Start () {
	currentHealth = maxHealth;	

	thePlayerStats = FindObjectOfType<PlayerStats>();
	theQM = FindObjectOfType<gpjQuestManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(currentHealth <=0)
		{
			theQM.enemyKilled = enemyQuestName;
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


﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour {

	public float moveSpeed;
	
	private Vector2 minWalkPoint;
	private	Vector2 maxWalkPoint;

	private Rigidbody2D myRigidbody;

	public bool isWalking;
	private bool hasWalkZone;
	public bool canWalk;

	public float walkTime;
	public float waitTime;
	private float walkCounter;
	private float waitCounter;
	private int WalkDirection;

	public Collider2D walkZone;

	private DialogueManager theDM;



	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();
		theDM = FindObjectOfType<DialogueManager>();
	
		waitCounter = waitTime;
		walkCounter = walkTime;

		ChooseDirection();

		if(walkZone != null)
			{
				minWalkPoint = walkZone.bounds.min;
				maxWalkPoint = walkZone.bounds.max;
				hasWalkZone = true;
			}

		canWalk = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (!theDM.dialogueActive)
		{
			canWalk = true;
		}

		if (!canWalk)
		{
			myRigidbody.velocity = Vector2.zero;
			return;
		}

		if(isWalking)
		{
			walkCounter -= Time.deltaTime;
			
			switch (WalkDirection)

			{
					case 0:
				myRigidbody.velocity = new Vector2 (0, moveSpeed);
				if(hasWalkZone && transform.position.y > maxWalkPoint.y)
				{
					isWalking = false;
					waitCounter = waitTime;
				}

					break;

					case 1:
				myRigidbody.velocity = new Vector2 (moveSpeed, 0);
				if(hasWalkZone && transform.position.x > maxWalkPoint.x)
				{
					isWalking = false;
					waitCounter = waitTime;
				}
					break;

					case 2:
				myRigidbody.velocity = new Vector2 (0, -moveSpeed);
				if(hasWalkZone && transform.position.y < minWalkPoint.y)
				{
					isWalking = false;
					waitCounter = waitTime;
				}
					break;

					case 3:
				myRigidbody.velocity = new Vector2 (-moveSpeed, 0);
				if(hasWalkZone && transform.position.x < minWalkPoint.x)
				{
					isWalking = false;
					waitCounter = waitTime;
				}
					break;	
			}

			
			}
				else
			{
				
			
			if(walkCounter < 0)
				{
				isWalking = false;
				waitCounter = waitTime;
				}






				waitCounter -= Time.deltaTime;

				myRigidbody.velocity = Vector2.zero;

					if (walkCounter < 0)
					{
						ChooseDirection();
					}
			}

	}

	public void ChooseDirection()
	{
		WalkDirection = Random.Range (0, 4);
		isWalking = true;
		walkCounter = walkTime;

	}

}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private float currentMoveSpeed;
	//public float diagonalMoveModifier;

	private Animator anim;
	private Rigidbody2D myRigidbody;
	private bool playerMoving;
	public Vector2 lastMove;

	private Vector2 moveInput;

	private static bool playerExists;

	private bool attacking;
	public float attackTime;
	private float attackTimeCounter;

	public string startPoint;
	public bool canMove;

	private SFXManager sfxMan;

	public floatValue currentHealthHeart;
	public Signal playerHealthSignal;
	public vectorValue startingPosition;

	public GameObject inventoryPanel;
	public Inventory playerInventory;
	public SpriteRenderer receivedItemSprite;
	

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		myRigidbody = GetComponent<Rigidbody2D>();
		sfxMan = FindObjectOfType<SFXManager>();
		
		if(!playerExists)
		{
			playerExists = true;
			DontDestroyOnLoad(transform.gameObject);
		} else {
			Destroy (gameObject);
		}

		canMove = true;
		lastMove = new Vector2(0f, -1f);
		transform.position = startingPosition.initialValue;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		playerMoving = false;

		if (!canMove)
		{
			myRigidbody.velocity = Vector2.zero;
			return;
		}

		if(!attacking)
			{

			moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

			if (moveInput != Vector2.zero)
			{
				myRigidbody.velocity = new Vector2 (moveInput.x * moveSpeed, moveInput.y * moveSpeed);
				playerMoving = true;
				lastMove = moveInput;
			} else
			{
				myRigidbody.velocity = Vector2.zero;
			}

			if( Input.GetKeyDown(KeyCode.Space) ) //de j a space
				{
				attackTimeCounter = attackTime;
				attacking = true;
				myRigidbody.velocity = Vector2.zero;
				anim.SetBool("Attack", true);
				if (sfxMan != null)
				{
					sfxMan.playerAttack.Play();
				}
				
			}

			//inventory
			if (Input.GetKeyDown(KeyCode.I))
			{
				inventoryPanel.SetActive(true);
			} else if (Input.GetKeyUp(KeyCode.I))
			{
				inventoryPanel.SetActive(false);
			}
			// esto funciona mientras mantengas presionado
	}	

		if(attackTimeCounter > 0)
		{
			attackTimeCounter -= Time.deltaTime;
		}

		if(attackTimeCounter <=0)
		{
			attacking = false;
			anim.SetBool("Attack", false);
		}

		anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
		anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
		anim.SetBool("PlayerMoving", playerMoving);
		anim.SetFloat("LastMoveX", lastMove.x);
		anim.SetFloat("LastMoveY", lastMove.y);
	}


	public void Knock( float knockTime, float damage)
	{

		currentHealthHeart.RuntimeValue -= damage;
		playerHealthSignal.Raise();
		if (currentHealthHeart.RuntimeValue > 0)
		{
			
			StartCoroutine(KnockCo(knockTime));
		} else
		
		{
			// another death ... lol
			//this.gameObject.SetActive(false);
		}
	}

	 private IEnumerator KnockCo( float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            myRigidbody.velocity = Vector2.zero;
            
        }
    }

	public void RaiseItem()
	{
		if (playerInventory.currentItem != null)
		{
			anim.SetBool("ReceiveItem", true);
			receivedItemSprite.sprite = playerInventory.currentItem.itemSprite;
			StartCoroutine(FixThisShitItemPls());
		}
		
	}

	IEnumerator FixThisShitItemPls()
	{
		playerInventory.currentItem = null;
		yield return new WaitForSeconds(3);
		anim.SetBool("ReceiveItem", false);
		receivedItemSprite.sprite = null;
		
	}
}

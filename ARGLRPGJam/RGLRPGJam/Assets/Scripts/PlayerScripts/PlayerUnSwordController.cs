using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnSwordController : MonoBehaviour {


	public float moveSpeed;
	private float currentMoveSpeed;
	//public float diagonalMoveModifier;

	private Animator anim;
	private Rigidbody2D myRigidBody;
	private bool playerMoving;
	public Vector2 lastMove;

	private Vector2 moveInput;

	//private static bool playerExists;

	private bool attacking;
	public float attackTime;
	private float attackTimeCounter;

	public string startPoint;
	public bool canMove;

	private SFXManager sfxMan;

    public bool hasSword;
    public GameObject Sword;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		myRigidBody = GetComponent<Rigidbody2D>();
		sfxMan = FindObjectOfType<SFXManager>();
		
		/* if(!playerExists)
		{
			playerExists = true;
			DontDestroyOnLoad(transform.gameObject);
		} else {
			Destroy (gameObject);
		}*/

		canMove = true;
		lastMove = new Vector2(0f, -1f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		playerMoving = false;

		if (!canMove)
		{
			myRigidBody.velocity = Vector2.zero;
			return;
		}

		if(!attacking)
			{

			moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

			if (moveInput != Vector2.zero)
			{
				myRigidBody.velocity = new Vector2 (moveInput.x * moveSpeed, moveInput.y * moveSpeed);
				playerMoving = true;
				lastMove = moveInput;
			} else
			{
				myRigidBody.velocity = Vector2.zero;
			}

			if( Input.GetKeyDown(KeyCode.Space) && hasSword ) //de j a space
				{
				attackTimeCounter = attackTime;
				attacking = true;
				myRigidBody.velocity = Vector2.zero;
				anim.SetBool("Attack", true);
				if (sfxMan != null)
				{
					sfxMan.playerAttack.Play();
				}
				
				}

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
}
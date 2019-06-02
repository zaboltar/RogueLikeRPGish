using System.Collections;
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

	public Signal playerHit;
	public GameObject projectile;
	

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

		//attacks
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
			//RANGED ATTACK
			// no se si esto deberia ir acá, pero el codigo esta tan distinto en este script que sólo metere rage	
			} else if (Input.GetButtonDown("SecondaryWeapon"))
				{
					StartCoroutine(SecondaryAttack());
				}

	}

	public IEnumerator SecondaryAttack()
	{
		yield return null;
		MakeArrow();
		yield return new WaitForSeconds(.3f);
		
	}
	private void MakeArrow()
	{
		Vector2 temp = new Vector2(lastMove.x, lastMove.y );
		Arrow arrow = Instantiate(projectile,
		 transform.position, Quaternion.identity)
		 .GetComponent<Arrow>();

		arrow.Setup(temp,ChooseArrowDirection());
	}

	Vector3 ChooseArrowDirection()
	{
		float temp = Mathf.Atan2(lastMove.y,
		 lastMove.x) * Mathf.Rad2Deg; //tangente
		return new Vector3 (0, 0 , temp);
	}

	/*private void MakeArrow()
	{
		Vector2 temp = new Vector2(anim.GetFloat("MoveX"), anim.GetFloat("MoveY") );
		Arrow arrow = Instantiate(projectile,
		 transform.position, Quaternion.identity)
		 .GetComponent<Arrow>();

		arrow.Setup(temp,ChooseArrowDirection());
	}

	Vector3 ChooseArrowDirection()
	{
		float temp = Mathf.Atan2(anim.GetFloat("MoveY"),
		 anim.GetFloat("MoveX")) * Mathf.Rad2Deg; //tangente
		return new Vector3 (0, 0 , temp);
	}
 */

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
		playerHit.Raise();

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {


	public float moveSpeed = 5f;
	private float currentMoveSpeed;
	public float diagonalMoveModifier;
	private Animator anim;
	private bool playerMoving;

	public Rigidbody2D rb;

	private Vector2 movement;
	public Vector2 lastMove;
	private static bool playerExists;

	private bool attacking;
	public float attackTime;
	private float attackTimeCounter;

	public bool canMove;


	private SFXManager sfxMan;



	

	public string startPoint;

    // Use this for initialization
    void Start () {
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		sfxMan = FindObjectOfType<SFXManager>();
		canMove = true;
		if (!playerExists)
		{
			playerExists = true;
			DontDestroyOnLoad(transform.gameObject);
		}
		
		else {
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {

		//Input

		playerMoving = false;
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");

		if (Input.GetKeyDown(KeyCode.Escape)) 
		{
			SceneManager.LoadScene(0);
			transform.position = new Vector3(0f, 0f, 0f);
		}
		

		//Last Move
		if (movement.x != 0) {
			playerMoving = true;
			lastMove = new Vector2(movement.x, 0f);
		}

		if (movement.y != 0) {
			playerMoving = true;
			lastMove = new Vector2(0f, movement.y);
		}

		//Attacking

		if (Input.GetKeyDown(KeyCode.J) && !attacking)
		{
			attackTimeCounter = attackTime;
			attacking = true;
			rb.velocity = Vector2.zero;
			anim.SetBool("PlayerAttack", true);
			sfxMan.playerAttack.Play();
		}
		

			if (attackTimeCounter > 0)
		{
			attackTimeCounter -= Time.deltaTime;
		}

		if (attackTimeCounter <= 0)
		{
			attacking = false;
			anim.SetBool("PlayerAttack", false);
		}


	}

    private void FixedUpdate()
    {
		if (!attacking && canMove)
		{
			//Movement   
			if (movement.x != 0f )
			{
				rb.velocity = new Vector2(movement.x * currentMoveSpeed, rb.velocity.y);
			}
			if (movement.y != 0f)
			{
				rb.velocity = new Vector2(rb.velocity.x, movement.y * currentMoveSpeed);
			}
			if (movement.x == 0f)
			{
				rb.velocity = new Vector2(0f, rb.velocity.y);
			}
			if (movement.y == 0f)
			{
				rb.velocity = new Vector2(rb.velocity.x, 0f);
			}
		}
		if (movement.x != 0 && movement.y != 0)
		{
			currentMoveSpeed = moveSpeed * diagonalMoveModifier;
		}
		else
		{
			currentMoveSpeed = moveSpeed;
		}
		
		//rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

		anim.SetFloat("MoveX", movement.x);
		anim.SetFloat("MoveY", movement.y);
		anim.SetFloat("LastMoveX", lastMove.x);
		anim.SetFloat("LastMoveY", lastMove.y);
		anim.SetBool("PlayerMoving", playerMoving);
		
			
	}
}

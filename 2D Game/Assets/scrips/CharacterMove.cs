using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {

	//Player Movement Variables
	public int moveSpeed;
	public float JumpHeight;
	private bool doubleJump;

	//Player ground variables
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	//Non-Slide player
	private float moveVelocity;

	public Animator animator;

	// Use this for initialization
	void Start () {
		animator.SetBool("IsWalking",false);
		animator.SetBool("IsJumping",false);
		animator.SetBool("IsSlideing",false);
	}
	

	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}

	// Update is called once per frame
	void Update () {
		
		// This code makes the character jump
		if(Input.GetKeyDown (KeyCode.W)&& grounded){
			Jump();
		}

		//Double jump code
		if(grounded){
			doubleJump = false;
			animator.SetBool("IsJumping",false);
		}
		
		if(Input.GetKeyDown (KeyCode.W)&& !doubleJump && !grounded){
			Jump();
			doubleJump = true;
		}
		//Non-Slide player
		moveVelocity = 0f;	


		//This code makes the character move from side to side using the A&D keys
		if(Input.GetKey (KeyCode.D)){
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			moveVelocity = moveSpeed;
			animator.SetBool("IsWalking",true);
		}

		else if(Input.GetKeyUp (KeyCode.D)){
			animator.SetBool("IsWalking",false);
		}

		if(Input.GetKey (KeyCode.LeftControl)){
			animator.SetBool("IsSlideing",true);
		}

		else if(Input.GetKeyUp (KeyCode.LeftControl)){
			animator.SetBool("IsSlideing",false);
		}

		if(Input.GetKey (KeyCode.A)){
			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			moveVelocity = -moveSpeed;
			animator.SetBool("IsWalking",true);
		}	

		else if(Input.GetKeyUp (KeyCode.A)){
			animator.SetBool("IsWalking",false);
		}

		if(Input.GetKey (KeyCode.LeftControl)){
			animator.SetBool("IsSlideing",true);
		}

		else if(Input.GetKeyUp (KeyCode.LeftControl)){
			animator.SetBool("IsSlideing",false);
		}

		GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

		//Player flip
		if (GetComponent<Rigidbody2D>().velocity.x > 0)
			transform.localScale = new Vector3(0.7f,0.7f,1f);
		
		else if (GetComponent<Rigidbody2D>().velocity.x < 0)
			transform.localScale = new Vector3(-0.7f,0.7f,1f);
	}
	
	public void Jump(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
		animator.SetBool("IsJumping",true);
	}
}

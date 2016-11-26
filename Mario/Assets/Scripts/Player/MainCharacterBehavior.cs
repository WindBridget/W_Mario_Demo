using UnityEngine;
using System.Collections;

public class MainCharacterBehavior : MonoBehaviour {

	public float moveSpd, jumpHeight,groundCheckRadius, shotDelay; 
	protected Animator animator;
	//public Rigidbody2D rgb;
	public Transform groundCheck, firePoint;
	public LayerMask whatIsGround;
	private bool grounded, doubleJumped;
	public Renderer rend;
	private float moveVelocity, shotDelayCounter;
	public GameObject ninjaStar;
	private Rigidbody2D myRigidbody2D;
	public float knockback, knockbackCount, knockbackLength;
	public bool knockFromRight;
	// Use this for initialization
	void Start () {

		animator = gameObject.GetComponent<Animator>();
		//rgb = gameObject.GetComponent<Rigidbody2D>();
		rend = GetComponent<Renderer>();
		myRigidbody2D = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}
	// Update is called once per frame
	void Update () {
		if(grounded){
			doubleJumped = false;
		}

		animator.SetBool("Grounded", grounded);

		if(Input.GetButtonDown("Jump") && grounded)
		{
			jump();
			GetComponent<AudioSource>().Play ();
		}
		if(Input.GetButtonDown("Jump") && !grounded && !doubleJumped)
		{
			jump();
			GetComponent<AudioSource>().Play ();
			doubleJumped = true;
		}	

		//moveVelocity = 0f;
		moveVelocity = moveSpd * Input.GetAxisRaw ("Horizontal");

		if(Input.GetKey(KeyCode.LeftArrow))
		{
			//rgb.velocity = new Vector2(-moveSpd, rgb.velocity.y);
			moveVelocity = -moveSpd;
		}
		if(Input.GetKey(KeyCode.RightArrow))
		{
			//rgb.velocity = new Vector2(moveSpd, rgb.velocity.y);
			moveVelocity = moveSpd;
		}
		//effect knockback
		if (knockbackCount <= 0) {
			myRigidbody2D.velocity = new Vector2 (moveVelocity, myRigidbody2D.velocity.y);		
		} 
		else {
			if(knockFromRight){
				myRigidbody2D.velocity = new Vector2(-knockback, knockback);
			}
			if(!knockFromRight){
				myRigidbody2D.velocity = new Vector2(knockback, knockback);
			}
			knockbackCount -=  Time.deltaTime;
		}
		//change localScale
		animator.SetFloat ("Speed", Mathf.Abs(myRigidbody2D.velocity.x));
		if(myRigidbody2D.velocity.x < 0){
			transform.localScale = new Vector3(-1f, 1f, 1f);
		}
		else if(myRigidbody2D.velocity.x > 0){
			transform.localScale = new Vector3(1f, 1f, 1f);
		}
		//throw kunai
		if(Input.GetButtonDown("Fire1")){
			Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
			shotDelayCounter = shotDelay;
		}
		if (Input.GetButtonDown("Fire1")) {
			shotDelayCounter -= Time.deltaTime;
			if(shotDelayCounter <= 0){
				shotDelayCounter = shotDelay;
				Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
			}
		}
		//use sword
		if (animator.GetBool("Sword")) {
			animator.SetBool("Sword", false);	
		}
		if (Input.GetButtonDown("Fire2")) {
			animator.SetBool("Sword", true);		
		}
	}

	public void jump(){
		myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, jumpHeight);
	}
}
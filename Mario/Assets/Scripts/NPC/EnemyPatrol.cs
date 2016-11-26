using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

	public float moveSpd;
	public bool moveRight;
	public float wallCheckRadius;
	public Transform wallCheck, edgeCheck;
	public LayerMask whatIsWall;
	private bool hittingWall, notAtEdge;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall);
		notAtEdge = Physics2D.OverlapCircle (edgeCheck.position, wallCheckRadius, whatIsWall);
		if(hittingWall || !notAtEdge){
			moveRight = !moveRight;
		}
		if(moveRight){
			transform.localScale = new Vector3(-1f , 1f, 1f);
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpd, GetComponent<Rigidbody2D>().velocity.y );
		}
		else{
			transform.localScale = new Vector3(1f , 1f, 1f);
			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpd, GetComponent<Rigidbody2D>().velocity.y );
		}
	
	}
}

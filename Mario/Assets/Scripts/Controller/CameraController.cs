using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public MainCharacterBehavior player;
	public bool isFollowing;
	public float xOffset;
	public float yOffset;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<MainCharacterBehavior> ();
		isFollowing = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(isFollowing){
			transform.position = new Vector3(player.transform.position.x + xOffset, transform.position.y + yOffset, transform.position.z);
		}
	}
}

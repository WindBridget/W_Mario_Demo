using UnityEngine;
using System.Collections;

public class DestroyBlockOnContact : MonoBehaviour {
	public GameObject brickParticle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Brick") {		
			Destroy(other.gameObject);
			Instantiate(brickParticle,other.gameObject.transform.position, other.gameObject.transform.localRotation);
		}
		
	}
}

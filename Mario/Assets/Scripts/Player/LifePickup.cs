using UnityEngine;
using System.Collections;

public class LifePickup : MonoBehaviour {

	private LifeManager lifeSystem;
	public GameObject lifeParticle;
	// Use this for initialization
	void Start () {
		lifeSystem = FindObjectOfType<LifeManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "MainCharacter") {
			Destroy(gameObject);
			lifeSystem.GiveLife();
			Instantiate(lifeParticle, other.gameObject.transform.position, other.gameObject.transform.rotation);
		}
	}
}

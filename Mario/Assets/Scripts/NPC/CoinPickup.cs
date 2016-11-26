using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {
	public GameObject coinParticle;
	public int pointsToAdd;

	void OnTriggerEnter2D(Collider2D other){
		if(other.GetComponent<MainCharacterBehavior>() == null){
			return;
		}

		ScoreManager.AddPoints (pointsToAdd);
		Destroy (gameObject);
		Instantiate(coinParticle,other.gameObject.transform.position, other.gameObject.transform.localRotation);
		
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

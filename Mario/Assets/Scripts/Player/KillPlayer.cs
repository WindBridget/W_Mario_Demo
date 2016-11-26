using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

	public LevelManager levelManager;
	private LifeManager lifeSystem;
	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();
		lifeSystem = FindObjectOfType<LifeManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Faildown"){
			levelManager.RespawnPlayer();
			lifeSystem.TakeLife();
		}
	}
}

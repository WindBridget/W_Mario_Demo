using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckPoint, deathParticle, respawnParticle;
	private MainCharacterBehavior player;
	public int pointPenaltyOnDeath;
	public float respawnDelay;
	private float gravityStore;
	private CameraController camera;
	public HealthManager healManager;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<MainCharacterBehavior> ();
		camera = FindObjectOfType<CameraController> ();
		healManager = FindObjectOfType<HealthManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RespawnPlayer(){
		StartCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo(){
		Instantiate (deathParticle, player.transform.position, player.transform.rotation);
		player.enabled = false;
		player.rend.enabled = false;
		camera.isFollowing = false;
		//player.rgb.gravityScale  = 0f;
		//player.rgb.velocity = Vector2.zero;
		ScoreManager.AddPoints (-pointPenaltyOnDeath);
		Debug.Log ("Player Respawn");
		yield return new WaitForSeconds (respawnDelay);
		//player.rgb.gravityScale = 4f;
		player.transform.position = currentCheckPoint.transform.position;
		player.knockbackCount = 0;
		player.enabled = true;
		player.rend.enabled = true;
		camera.isFollowing = true;
		healManager.FullHealth ();
		healManager.isDead = false;
		Instantiate (respawnParticle, currentCheckPoint.transform.position, currentCheckPoint.transform.rotation);
	}
}

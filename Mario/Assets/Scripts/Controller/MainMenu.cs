using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string startLevel, levelSelect;
	public int playerLives, playHealth;

	public void NewGame(){
		PlayerPrefs.SetInt ("PlayerCurrentLives", playerLives);
		PlayerPrefs.SetInt ("PlayerCurrentScore", 0);
		PlayerPrefs.SetInt ("PlayerCurrentHealth", playHealth);
		PlayerPrefs.SetInt ("PlayerMaxHealth", playHealth);
		Application.LoadLevel (startLevel);
	}

	public void LevelSelect(){
		PlayerPrefs.SetInt ("PlayerCurrentLives", playerLives);
		PlayerPrefs.SetInt ("PlayerCurrentScore", 0);
		PlayerPrefs.SetInt ("PlayerCurrentHealth", playHealth);
		PlayerPrefs.SetInt ("PlayerMaxHealth", playHealth);
		Application.LoadLevel (levelSelect);
	}

	public void QuitGame(){
		Debug.Log ("Quit Game");
		Application.Quit ();
	}

}

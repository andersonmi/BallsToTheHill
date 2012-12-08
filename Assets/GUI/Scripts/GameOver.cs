using UnityEngine;
using System.Collections;

[ExecuteInEditMode]

public class GameOver : MonoBehaviour {
	
	public GUISkin menuSkin;
	public long finalScore;
	

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<ScoreScript>()	.enabled = false;
		this.useGUILayout = false;  
	}
	
	// Update is called once per frame
	void Update () {
		finalScore = gameObject.GetComponent<ScoreScript>().Score;
	}
	
	void OnGUI(){
		if (GUI.skin != null && GUI.skin != menuSkin)
			GUI.skin = menuSkin;
		else
			Debug.Log("GUI Skin is Null");
		
		GUI.Box(new Rect(Screen.width * 0.5f - Screen.width * 0.15f, Screen.height *0.25f, Screen.width * 0.3f, Screen.height * 0.1f), "Game Over!", "GameOver");
		GUI.Box(new Rect(Screen.width * 0.5f - Screen.width * 0.15f, Screen.height *0.35f , Screen.width * 0.3f, Screen.height * 0.1f), "Your final score: ", "highScore");
		GUI.Box(new Rect(Screen.width * 0.5f - Screen.width * 0.15f, Screen.height *0.45f, Screen.width * 0.3f, Screen.height * 0.1f), "" + finalScore , "highScore");
		if (GUI.Button(new Rect(Screen.width * 0.5f - 135,Screen.height *0.55f, 120, 120), "Main Menu", "menuButton")) {
			Application.LoadLevel("Main Menu");
			
			//You must reset the timescale to 1! The game scene is currently "paused" and application
			// loadlevel does not unpause it when it reloads the game.
			Time.timeScale = 1;
		}
		
		if (GUI.Button(new Rect(Screen.width * 0.5f + 15, Screen.height *0.55f, 120f, 120f), "Replay", "menuButton")) {
			Application.LoadLevel("MainLevel");		
			Time.timeScale = 1;
		}
			
	}
}
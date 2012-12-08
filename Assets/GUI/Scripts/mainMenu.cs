using UnityEngine;
using System.Collections;

[ExecuteInEditMode]

public class mainMenu : MonoBehaviour {
	
	public GUISkin menuSkin;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		GUI.skin = menuSkin;
		if (GUI.Button(new Rect(Screen.width/2 - 240, Screen.height * 0.45f + Screen.width / 8 , 120, 120), "Start Game", "menuButton"))
			Application.LoadLevel("MainLevel");
		
		if (GUI.Button(new Rect(Screen.width/2 - 120, Screen.height  * 0.45f + Screen.width / 8 , 120, 120), "How to Play", "menuButton"))
			Application.LoadLevel("TutorialLevel");			
		
		if (GUI.Button(new Rect(Screen.width/2 + 000, Screen.height  * 0.45f + Screen.width / 8 , 120, 120), "Credits", "menuButton"))
			Application.LoadLevel("Credits");		
		
		if (GUI.Button(new Rect(Screen.width/2 + 120, Screen.height  * 0.45f + Screen.width / 8 , 120, 120), "Exit Game", "menuButton"))
			Application.Quit();
		
			
	}
}

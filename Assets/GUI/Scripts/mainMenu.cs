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
		// Set matrix
		
		GUI.skin = menuSkin;
		if (GUI.Button(new Rect(Screen.width * 0.5f - 200, Screen.height * 0.65f , Screen.width * 0.1171f, Screen.height * 0.1562f), "Start\nGame", "menuButton"))
			Application.LoadLevel("MainLevel");
		
		if (GUI.Button(new Rect(Screen.width * 0.5f  - 80, Screen.height  * 0.65f, Screen.width * 0.1171f, Screen.height * 0.1562f), "How to\nPlay", "menuButton"))
			Application.LoadLevel("TutorialLevel");			
		
		if (GUI.Button(new Rect(Screen.width* 0.5f + 35,Screen.height  * 0.65f, Screen.width * 0.1171f, Screen.height * 0.1562f), "Credits", "menuButton"))
			Application.LoadLevel("Credits");		
		
		if (GUI.Button(new Rect(Screen.width * 0.5f + 150, Screen.height  * 0.65f, Screen.width * 0.1171f, Screen.height * 0.1562f), "Exit\nGame", "menuButton"))
			Application.Quit();
		
		
			
	}
}

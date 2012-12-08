using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class credits : MonoBehaviour {
	
	public GUISkin creditsSkin;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		GUI.skin = creditsSkin;
		GUI.Label(new Rect(Screen.width/2 -200, Screen.height/2 - 330, 400, 500), "Evan Cox -  Artist \n\nFrancesca Boville - Artist\n\nAaron Preston - Designer\n\n" +
			"Nathaniel Abernathy - Designer\n\nYue Lu - Programmer\n\nMichael Anderson - Programmer", "gameOver");
		
		if (GUI.Button(new Rect(Screen.width/2 - 60, Screen.height/2 + 250, 120, 120), "Main Menu", "menuButton"))
			Application.LoadLevel("Main Menu");
	}
}

using UnityEngine;
using System.Collections;

public class controls : MonoBehaviour {
	
	public GUISkin creditsSkin;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		GUI.skin = creditsSkin;
		GUI.Label(new Rect(Screen.width / 2 - 300, 150, 600, 500), "Use A/Left Arrow or D/Right Arrow \nto steer the ball. \n \n" 
		+ "Watch the meter! \n\nGreen you can smash. \n\nYellow can hurt you. \n\nRed can splat you.", "creditsSkin");
		
		if (GUI.Button(new Rect(75, 600, 120, 120), "Main Menu", "menuButton"))
			Application.LoadLevel("Main Menu");
	}
}

using UnityEngine;
using System.Collections;

[ExecuteInEditMode]

public class TutorialButtons : MonoBehaviour {
	
	private int currentImage = 0;
	public GUISkin mySkin;
	public Texture image1;
	public Texture image2;
	public Texture image3;
	public Texture image4;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		GUI.skin = mySkin;
		if (currentImage > 2) currentImage = 2;
		switch (currentImage) {
		case 0:
			GUI.DrawTexture(new Rect(0,0,1024,768), image1);
			GUI.Box(new Rect(Screen.width/2-250, Screen.height/2-25, 500, 50), "Use A&D or the Arrow Keys to Move!", "creditsSkin");
			break;
			
		case 1:
			GUI.DrawTexture(new Rect(0,0,1024,768), image2);
			break;
			
		case 2:
			GUI.DrawTexture(new Rect(0,0,1024,768), image3);
			break;
		}
		
		if (currentImage < 2) {
			if (GUI.Button(new Rect(Screen.width *0.875f, Screen.height * 0.85f, 120, 120), "Next", "menuButton")) {
				currentImage += 1;
			}
		}
		else {
			if (GUI.Button(new Rect(Screen.width *0.875f, Screen.height * 0.85f, 120, 120), "Play Game", "menuButton")) {
				Application.LoadLevel("MainLevel");
			}
		}
		
		if (currentImage >= 1) {
			if (GUI.Button(new Rect(Screen.width *0.0125f, Screen.height * 0.85f, 120, 120), "Back", "menuButton")) {
				currentImage -= 1;
			}
		}
		else if (currentImage == 0) {
			if (GUI.Button(new Rect(Screen.width *0.0125f, Screen.height * 0.85f, 120, 120), "Main Menu", "menuButton")) {
				Application.LoadLevel("Main Menu");
			}
		}
	}
}

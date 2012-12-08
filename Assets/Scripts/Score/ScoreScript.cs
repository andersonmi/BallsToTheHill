using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	public long Score;
	
	private string scoreString;
	private float timeChange;
	public GUISkin scoreSkin;
	
	// Use this for initialization
	void Start () {
		this.useGUILayout = false; 
	}
	
	// Update is called once per frame
	void Update () {
		scoreString = "Score: " + Score;
		//GUILayout.Label(scoreString);
	}
	
	void OnGUI() {
		if (GUI.skin != scoreSkin)
			GUI.skin = scoreSkin;
		GUI.Label(new Rect(Screen.width / 2 + 75, 10, 300, 40), scoreString, "scoreBox");
	}
}

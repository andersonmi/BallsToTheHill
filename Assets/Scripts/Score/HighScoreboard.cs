using UnityEngine;
using System.Collections;

[ExecuteInEditMode]

public class HighScoreboard : MonoBehaviour {
	// variables exposed to editor
	
	public GUISkin mySkin;
	
	// location of the PHP script that the game communicates with
	public string url = "http://gel.msu.edu/winn/courses/tc445sp11/highscore.php";
	
	// the unique name of the game, change this to create a new high score table
	public string gameName = "";
	
	// the display name of the game for the web page
	public string gameTitle = "";
	
	// the name of the player
	public string playerName = "Player Name";
	
	// the score of the player
	public string playerScore = "0";
	
	// the number of scores to return
	public string scoresToDisplay = "10";	
	
	public bool highScoreScreen;
	
	// what range to show in high scores and score position
	private enum range {all=0,today=1,week=2,month=3,year=4};
	private range whenRange;
	
	// sort order either DESC or ASC
	private enum sorder {DESC=0,ASC=1};
	private sorder sortOrder;
	
	// scoreType is either INT or FLOAT
	private enum stype {Int=0,Float=1};
	private stype scoreType;
	
	// 
	private GUIStyle myStyle;
	
	// internal variable to control the mode of the GUI display
	private string guiMode = "menu";
	
	// this holds the highscore data that is passed back from the server
	private string wwwData;
	
	public long finalScore;
	public Texture backgroundImage;
	
	public bool scoreAdded = false;
	
	void Start () {
		//gameObject.GetComponent("GUIScript").enabled = false;
		if (mySkin!=null) {
			//myStyle.fontStyle = mySkin.button.fontStyle;
//			myStyle.fontSize = 30;
		}
		if (highScoreScreen)
			getHighScores();
	}
	
	void Update() {
		if (gameObject.GetComponent("Score") != null) {
			finalScore = (long) gameObject.GetComponent<ScoreScript>().Score;
			//finalLevel = gameObject.GetComponent<Score>().currentLevel;
		}
	
	}
	// control the GUI
	void OnGUI() {
		// Assign the skin to be the one currently used.
		GUI.skin = mySkin;
		
		switch (guiMode) {
			case "menu":
				//GUI.DrawTexture(new Rect(Screen.width /2 - Screen.width*.75f*.5f, Screen.height /2 - Screen.height*.475f, Screen.width*.75f, Screen.height*.95f), backgroundImage); 
				GUI.Box(new Rect(Screen.width/2 -175, Screen.height*0.45f - 15 , 300, 30), "Your final score: " + finalScore, "highScore");
				GUI.Box(new Rect(Screen.width/2 -250, Screen.height*0.6f -15 , 300, 30), "Enter Name: ", "highScore");
	
				GUILayout.BeginArea (new Rect (Screen.width/2 + 50, Screen.height*0.6f -15 , 300, 30));
				playerName = GUILayout.TextField(playerName,25,GUILayout.Width(200));
				GUILayout.EndArea();
				
				if ((GUI.Button(new Rect(Screen.width/2-64-75*3, Screen.height*0.75f - 32, 128, 128), "Add Score", "menuButton")) && !scoreAdded) {
					playerScore = finalScore.ToString();
					uploadScore();
					scoreAdded = true;
				}
	
				if (GUI.Button(new Rect(Screen.width/2-64-75*1, Screen.height*0.75f  - 32, 128, 128), "High Scores", "menuButton")) {
					getHighScores();
					guiMode = "";
				}
				
				if (GUI.Button(new Rect(Screen.width/2, Screen.height*0.75f  - 32, 128, 128), "Main Menu", "menuButton")) {
					Application.LoadLevel("Main Menu");
					
					//You must reset the timescale to 1! The game scene is currently "paused" and application
					// loadlevel does not unpause it when it reloads the game.
					Time.timeScale = 1;
				}
				
				if (GUI.Button(new Rect(Screen.width/2 +64 + 75*1, Screen.height*0.75f  - 32, 128, 128), "Restart", "menuButton")) {
					Application.LoadLevel(Application.loadedLevelName);		
					Time.timeScale = 1;
				}
				
	
				break;
			case "showscores":	
				//GUI.DrawTexture(new Rect(Screen.width /2 - Screen.width*.75f*.5f, Screen.height /2 - Screen.height*.475f, Screen.width*.75f, Screen.height*.95f), backgroundImage); 
				GUI.Box(new Rect(Screen.width/2 - 250, Screen.height*0.2f - 30, 500, 60), "High Scores", "HighScoreFont"); 
				
				GUILayout.BeginArea (new Rect (Screen.width/2 - 175,  Screen.height *0.3f - 45, Screen.width/2, 500));
				
				//var myStyl = mySkin.label.fontStyle;
				// split the Scores by line-breaks (one line per score information)
				var x = 0;
			 	foreach (var line in wwwData.Split("\n"[0])) { 
			 		if (x < 10) {
			 		// break the line by tabs with the first field = name, second = score, third = timestamp
					var fields = line.Split("\t"[0]); 
	
					// only display if all fields are returned for each line
					if (fields.Length>=3) { 
						// use a dynamic GUI Layout within the area defined above
						GUILayout.BeginHorizontal(); 
						//GUILayout.Label("" + (x+1) + ". " + fields[0], myStyl, GUILayout.Width(450)); 
						GUILayout.Label("" + (x+1) + ". " + fields[0], GUILayout.Width(250));
						GUILayout.Label(": " + fields[1], GUILayout.Width(100));  
						GUILayout.EndHorizontal();                   
					}
					x++;
					}
				} 
				GUILayout.EndArea ();
			 	if (GUI.Button(new Rect(Screen.width/2 -64, Screen.height*.75f - 32, 128, 64), "Back", "Blank")) {
			 		if (!highScoreScreen)
						guiMode = "menu";
					else
						Application.LoadLevel("MainMenu");
				}
				
			   
				break;
		}
	}
	
	// upload the score to the server AND return the high scores
	IEnumerable getScorePosition() {
		guiMode = "upload";
	
		// create a WWWForm object that packages up the date to upload
		var form = new WWWForm();
	
		// add the fields to upload
		form.AddField("game", gameName);
		form.AddField("score", playerScore);
		form.AddField("when", ""+whenRange);
		form.AddField("order", ""+sortOrder);
		form.AddField("type", ""+scoreType);
		form.AddField("method", "position");
			
		// begin the asynchronous upload
		var w = new WWW(url,form);
	
		// wait until done
		yield return w;
	
		if (w.error != null) {
			print(w.error);
			wwwData = "Could not connect\tto\tserver";
			guiMode = "menu";
		} else {
			// save the date that comes back, which is in the format name\tscore\tdate\n
			wwwData = w.text;
			guiMode = "showposition";
		}
	}
	
	// upload the score to the server AND return the high scores
	IEnumerable uploadScore() {
		guiMode = "upload";
	
		// create a WWWForm object that packages up the date to upload
		var form = new WWWForm();
	
		// add the fields to upload
		form.AddField("game", gameName);
		form.AddField("name", playerName);
		form.AddField("score", playerScore);
		form.AddField("order", ""+sortOrder);
		form.AddField("type", ""+scoreType);
		form.AddField("method", "add");
			
		// begin the asynchronous upload
		var w = new WWW(url,form);
	
		// wait until done
		yield return w;
	
		// check for succes
		if (w.error != null) {
			print(w.error);
		}
		guiMode = "menu";
	}
	
	// get the high score table from the server
	IEnumerable getHighScores() {
		guiMode = "upload";
		
		// create a WWWForm object that packages up the date to upload
		var form = new WWWForm();
		
		// add the fields to upload
		form.AddField("game", gameName);
		form.AddField("limit", scoresToDisplay);
		form.AddField("when", ""+whenRange);
		form.AddField("order", ""+sortOrder);
		form.AddField("type", ""+scoreType);
		form.AddField("method", "retrieve");
		
		// begin the asynchronous upload
		var w = new WWW(url,form);
		
		// wait until done
		yield return w;
		
		// check for succes
		if (w.error != null) {
			print(w.error);
			wwwData = "Could not connect\tto\tserver";
			guiMode = "showscores";
		} else {
			// save the date that comes back, which is in the format name\tscore\tdate\n
			wwwData = w.text;
			guiMode = "showscores";
		}
	}
	
	// draw the high score table to the screen
	void scoreTable(string Scores) { 	
		//GUI.Box(new Rect(hmiddle,40,win,285), "High Scores"); 
		GUI.color = Color.white;
		GUILayout.BeginArea (new Rect (Screen.width/2-150, Screen.height/2-150, 300, 300));	
	
		// split the Scores by line-breaks (one line per score information)
	 	foreach (var line in Scores.Split("\n"[0])) { 
	 		// break the line by tabs with the first field = name, second = score, third = timestamp
			var fields = line.Split("\t"[0]); 
			
			// only display if all fields are returned for each line
			if (fields.Length >=3) { 
				// use a dynamic GUI Layout within the area defined above
				GUILayout.BeginHorizontal(); 
				GUILayout.Label(fields[0], "ScoreRowName",GUILayout.Width(200)); 
				GUILayout.Label(fields[1], "ScoreRowScore",GUILayout.Width(100));  
				GUILayout.EndHorizontal();                   
			}
		} 
		  
	 	if (GUILayout.Button("Return")) {
			guiMode = "menu";
		}
		
	   	GUILayout.EndArea ();
	}
	 
}

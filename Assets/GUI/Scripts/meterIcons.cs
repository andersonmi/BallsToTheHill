using UnityEngine;
using System.Collections;

[ExecuteInEditMode]

public class meterIcons : MonoBehaviour {
	
	float originalWidth = 1024;
	float originalHeight = 768;
	
	
	public Texture2D meter01;
	public Texture2D meter02;
	public Texture2D meter03;
	public Texture2D meter04;
	public Texture2D meter05;
	public Texture2D meter06;
	public Texture2D meter07;
	public Texture2D meter08;
	public Texture2D meter09;
	public Texture2D meter10;	
	
	public GetBigger mGB;
	
	private float leftX;
	private float rightX;
	private float heightIncrease;
	private float firstY;
	private float imageSize;
	
	
	// Use this for initialization
	void Start () {
	
		mGB = GameObject.Find("SnowballCollider").GetComponent<GetBigger>();
		leftX = Screen.width * 0.007f;
		rightX = Screen.width * 0.13f;
		heightIncrease = Screen.height * 0.047f;
		firstY = Screen.height * 0.46f;
		imageSize = Screen.width * 0.045f;
		
		this.useGUILayout = false; 
		

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI (){
		// Set matrix
//		Vector2 ratio = new Vector2(Screen.width/originalWidth , Screen.height/originalHeight );
//		Matrix4x4 guiMatrix = Matrix4x4.identity;
//		guiMatrix.SetTRS(new Vector3(1, 1, 1), Quaternion.identity, new Vector3(ratio.x, ratio.y, 1));
//		GUI.matrix = guiMatrix;
		
		
	GUI.contentColor = Color.yellow;	
	GUI.Label(new Rect(rightX, firstY - heightIncrease * 0, imageSize, imageSize), meter01);
	GUI.Label(new Rect(leftX, firstY - heightIncrease * 1, imageSize, imageSize), meter02);
	GUI.Label(new Rect(rightX, firstY - heightIncrease * 2, imageSize, imageSize), meter03);
	GUI.Label(new Rect(leftX, firstY - heightIncrease * 3, imageSize, imageSize), meter04);
	GUI.Label(new Rect(rightX, firstY - heightIncrease * 4, imageSize, imageSize), meter05);
	GUI.Label(new Rect(leftX, firstY - heightIncrease * 5, imageSize, imageSize), meter06);
	GUI.Label(new Rect(rightX, firstY - heightIncrease * 6, imageSize, imageSize), meter07);
	GUI.Label(new Rect(leftX, firstY - heightIncrease * 7, imageSize, imageSize), meter08);
	GUI.Label(new Rect(rightX, firstY - heightIncrease * 8, imageSize, imageSize), meter09);
	GUI.Label(new Rect(leftX + imageSize, firstY - heightIncrease * 9 - imageSize / 2, imageSize*2, imageSize), meter10);		
	
	if (mGB.getCurrentScale() >= 1){
		GUI.contentColor = Color.green;
		GUI.Label(new Rect(rightX, firstY - heightIncrease * 0, imageSize, imageSize), meter01);
		
		GUI.contentColor = Color.red;
		GUI.Label(new Rect(leftX, firstY - heightIncrease * 3, imageSize, imageSize), meter04);
	GUI.Label(new Rect(rightX, firstY - heightIncrease * 4, imageSize, imageSize), meter05);
	GUI.Label(new Rect(leftX, firstY - heightIncrease * 5, imageSize, imageSize), meter06);
	GUI.Label(new Rect(rightX, firstY - heightIncrease * 6, imageSize, imageSize), meter07);
	GUI.Label(new Rect(leftX, firstY - heightIncrease * 7, imageSize, imageSize), meter08);
	GUI.Label(new Rect(rightX, firstY - heightIncrease * 8, imageSize, imageSize), meter09);
	GUI.Label(new Rect(leftX + imageSize, firstY - heightIncrease * 9 - imageSize / 2, imageSize*2, imageSize), meter10);		
	
		}
	if (mGB.getCurrentScale() >= 1.5){
		GUI.contentColor = Color.yellow;		
		GUI.Label(new Rect(leftX, firstY - heightIncrease * 3, imageSize, imageSize), meter04);
		}
		
	if (mGB.getCurrentScale() >= 2){
		GUI.contentColor = Color.green;
		GUI.Label(new Rect(leftX, firstY - heightIncrease * 1, imageSize, imageSize), meter02);
		
		GUI.contentColor = Color.yellow;
		GUI.Label(new Rect(rightX, firstY - heightIncrease * 4, imageSize, imageSize), meter05);
		
		GUI.contentColor = Color.red;
			GUI.Label(new Rect(leftX, firstY - heightIncrease * 5, imageSize, imageSize), meter06);
		GUI.Label(new Rect(rightX, firstY - heightIncrease * 6, imageSize, imageSize), meter07);
	GUI.Label(new Rect(leftX, firstY - heightIncrease * 7, imageSize, imageSize), meter08);
	GUI.Label(new Rect(rightX, firstY - heightIncrease * 8, imageSize, imageSize), meter09);
	GUI.Label(new Rect(leftX + imageSize, firstY - heightIncrease * 9 - imageSize / 2, imageSize*2, imageSize), meter10);		
	
		}
	if (mGB.getCurrentScale() >= 2.5){
	
		GUI.contentColor = Color.yellow;		
		GUI.Label(new Rect(leftX, firstY - heightIncrease * 5, imageSize, imageSize), meter06);
		}	
		
	if (mGB.getCurrentScale() >= 3){
		GUI.contentColor = Color.green;
		GUI.Label(new Rect(rightX, firstY - heightIncrease * 2, imageSize, imageSize), meter03);
		
		GUI.contentColor = Color.yellow;		
		GUI.Label(new Rect(rightX, firstY - heightIncrease * 6, imageSize, imageSize), meter07);
		
		GUI.contentColor = Color.red;
	GUI.Label(new Rect(leftX, firstY - heightIncrease * 7, imageSize, imageSize), meter08);
	GUI.Label(new Rect(rightX, firstY - heightIncrease * 8, imageSize, imageSize), meter09);
	GUI.Label(new Rect(leftX + imageSize, firstY - heightIncrease * 9 - imageSize / 2, imageSize*2, imageSize), meter10);		
	
		}

	if (mGB.getCurrentScale() >= 3.5){
	
		GUI.contentColor = Color.yellow;		
		GUI.Label(new Rect(leftX, firstY - heightIncrease * 7, imageSize, imageSize), meter08);
		}	
		
				
	if (mGB.getCurrentScale() >= 4){
		GUI.contentColor = Color.green;
		GUI.Label(new Rect(leftX, firstY - heightIncrease * 3, imageSize, imageSize), meter04);
		
		GUI.contentColor = Color.yellow;		
		GUI.Label(new Rect(rightX, firstY - heightIncrease * 8, imageSize, imageSize), meter09);
		
		GUI.contentColor = Color.red;
		GUI.Label(new Rect(leftX + imageSize, firstY - heightIncrease * 9 - imageSize / 2, imageSize*2, imageSize), meter10);		
		}
		
	if (mGB.getCurrentScale() >= 5){
		GUI.contentColor = Color.green;
		GUI.Label(new Rect(rightX, firstY - heightIncrease * 4, imageSize, imageSize), meter05);
		
		GUI.contentColor = Color.yellow;		
		GUI.Label(new Rect(leftX + imageSize, firstY - heightIncrease * 9 - imageSize / 2, imageSize*2, imageSize), meter10);		
		}
	if (mGB.getCurrentScale() >= 6){
		GUI.contentColor = Color.green;
		GUI.Label(new Rect(leftX, firstY - heightIncrease * 5, imageSize, imageSize), meter06);
		}
	if (mGB.getCurrentScale() >= 7){
		GUI.contentColor = Color.green;
		GUI.Label(new Rect(rightX, firstY - heightIncrease * 6, imageSize, imageSize), meter07);
		}
	if (mGB.getCurrentScale() >= 8){
		GUI.contentColor = Color.green;
		GUI.Label(new Rect(leftX, firstY - heightIncrease * 7, imageSize, imageSize), meter08);
		}
	if (mGB.getCurrentScale() >= 9){
		GUI.contentColor = Color.green;
		GUI.Label(new Rect(rightX, firstY - heightIncrease * 8, imageSize, imageSize), meter09);
		}
		
		// Reset matrix
		GUI.matrix = Matrix4x4.identity;
	}
	
	
}
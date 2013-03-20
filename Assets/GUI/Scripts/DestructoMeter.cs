using UnityEngine;
using System.Collections;
	
[ExecuteInEditMode]

public class DestructoMeter : MonoBehaviour {
	
	float originalWidth = 1024;
	float originalHeight = 768;
	
	
	public float maxDestruction = 100.0f;
	public float curDestruction = 0.0f;
	
	public float meterLength;
	
	public GetBigger mGB;
	
	public GUISkin meterGUI01;
	
	// Use this for initialization
	void Start () {
		
		
	//if (!mGB) mGB = GameObject.Find("SnowballCollider").GetComponent<GetBigger>();
	mGB = GameObject.Find("SnowballCollider").GetComponent<GetBigger>();
	
	}
	
	// Update is called once per frame
	void Update () {
		adjustMeterLength(0);
		curDestruction = mGB.getCurrentScale() * 10f;
	}
	void OnGUI () {
		
		
		GUI.skin = meterGUI01;
//		GUI.Box(new Rect(Screen.width * 0.048f, (Screen.height / 2) - (Screen.height * 0.489f) , Screen.width * 0.16f, Screen.height * 0.455f ), "", "meterBG");
//		//Snowball Slider
//		//GUI.Box(new Rect(50, Screen.height / 2 - meterLength, 30, meterLength), "", "meterFG" );
//		GUI.VerticalSlider(new Rect(Screen.width * 0.16f, (Screen.height / 2) - meterLength + (meterLength * 0.12f), Screen.width * 0.029f, meterLength), curDestruction * 0.01F, 0.1F, 0.0F);
//		
		GUI.Box(new Rect(Screen.width * 0.01f, 0 , Screen.width * 0.1621f, Screen.height * 0.6133f ), "", "meterBG");
		//Snowball Slider
		GUI.VerticalSlider(new Rect(Screen.width * 0.0746f, (Screen.height * 0.537f) - meterLength, Screen.width * 0.0273f, meterLength), curDestruction * 0.01F, 0.1F, 0.0F);
	}
	public void adjustMeterLength(int adj) {
		//curDestruction += adj;
		
		meterLength = (Screen.height * 0.45f) * (curDestruction / maxDestruction);
		//meterLength = 350 * (curDestruction / maxDestruction);
		
				Debug.Log(meterLength);
	}

}


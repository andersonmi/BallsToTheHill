using UnityEngine;
using System.Collections;
	
[ExecuteInEditMode]

public class DestructoMeter : MonoBehaviour {
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
		GUI.Box(new Rect(Screen.width * 0.0f, Screen.height * 0.0f , Screen.width * 0.1f, Screen.height * 0.65f ), "", "meterBG");
		//Snowball Slider
		//GUI.Box(new Rect(50, Screen.height / 2 - meterLength, 30, meterLength), "", "meterFG" );
		GUI.VerticalSlider(new Rect(Screen.width * 0.05f + 18, Screen.height * 0.65f - meterLength, 30, meterLength), curDestruction * 0.01F, 0.1F, 0.0F);
}
	public void adjustMeterLength(int adj) {
		//curDestruction += adj;
		
		meterLength = Screen.height / 2 * (curDestruction / maxDestruction);
		
				//Debug.Log(meterLength);
	}

}


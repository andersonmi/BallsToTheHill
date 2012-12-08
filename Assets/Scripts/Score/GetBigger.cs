using UnityEngine;
using System.Collections;


public class GetBigger : MonoBehaviour {
	
	public float growTime = 1F;
	public float growAmmount = 0.25F;
	public GameObject Snowball;
	public float maxSize = 10F;
	public float minSize = 1f;
	public bool isMoving = true;
	public int scoreOnGrow = 1;
	
	private bool isMax = false;
	private bool isMin = false;
	private float nextTime = 0F;
	public float currentSize = 1F;
	
	private float nextGetHarder = 0f;
	public float getHarderRate = 5f;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		currentSize = Snowball.transform.localScale.x;
		if (Time.time > nextTime+growTime && currentSize < maxSize && isMoving) {
			Snowball.transform.localScale += new Vector3(growAmmount, growAmmount, growAmmount);
			currentSize = Snowball.transform.localScale.x + growAmmount;
			nextTime = Time.time;
			//Add size stuff to the score thing
			GameObject scoreboard = GameObject.FindWithTag("Score");
			scoreboard.GetComponent<ScoreScript>().Score += scoreOnGrow;
		}
		if (currentSize >= maxSize) {
			//
			//	 *******	*****
			//	**     **  **   **
			//	**	   **  **   **
			//	*********  *******	MPAGE MODE (I got lazy)
			//	**  **	   **   **	
			//	**   **	   **   **
			//  **    ***  **   **
			if (!isMax) {
				isMax = true;
				//THECAMERA.camera.fieldOfView = 102;
			}
			Snowball.transform.localScale = new Vector3(maxSize, maxSize, maxSize);
			currentSize = maxSize;
			if(Time.time > nextGetHarder) {
				if (GameObject.Find("TerrainManager").GetComponent<TerrainManager>().mHardPossibility <=40)
					GameObject.Find("TerrainManager").GetComponent<TerrainManager>().mHardPossibility += 2;
				nextGetHarder = Time.time + getHarderRate;
			}
				/*RAMPAGEBONUSSPEED += 5f;
				gameObject.transform.parent.GetComponent<SnowballController>().bonus += RAMPAGEBONUSSPEED;
				NEXTRAMPAGE = Time.time;
			}*/
		}
		else {
			if (isMax) {
				isMax = false;
			}
		}
		if (currentSize <= minSize) {
			isMin = true;
			Snowball.transform.localScale = new Vector3(minSize, minSize, minSize);
			currentSize = minSize;
		}
		else
			isMin = false;
		
		// CHEATING FUNCTIONALITY - NOT FOR USE DURING GAME
		/*if (Input.GetKey("=") && Snowball.transform.localScale.x <= 10) {
			Snowball.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
			currentSize = Snowball.transform.localScale.x;
		}
		else if (Input.GetKey("-") && Snowball.transform.localScale.x >= 1.1) {
		    Snowball.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
			currentSize = Snowball.transform.localScale.x;
		}*/
	}
	
	public float getCurrentScale()
	{
		return currentSize;	
	}
	
	public bool getIsMax() {
		return isMax;	
	}
	
	public bool getIsMin() {
		return isMin;	
	}
}

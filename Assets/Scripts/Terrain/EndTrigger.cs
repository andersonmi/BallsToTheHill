using UnityEngine;
using System.Collections;

public class EndTrigger : MonoBehaviour {
	
	Transform mTerrainManager;
	
	// Use this for initialization
	void Start () {
		mTerrainManager = GameObject.FindWithTag("TerrainManager").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter ( Collider col)  {
		//print("End Trigger Enter");
		if (col.tag == "Player")
		{
			mTerrainManager.SendMessage("SetNearTerrainEnd");
			gameObject.collider.enabled = false;
		}
	}
}

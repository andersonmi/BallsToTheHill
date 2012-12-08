using UnityEngine;
using System.Collections;

public class TriggerTesting : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate(Vector3.forward*200*Time.deltaTime);
	}
}

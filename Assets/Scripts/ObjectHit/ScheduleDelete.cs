using UnityEngine;
using System.Collections;

public class ScheduleDelete : MonoBehaviour {
	
	private float killTimer;
	public float killTime = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Kill timer to remove the object if player gets "stuck" on it.
		killTimer+=1f;
		if (killTimer > killTime * 33.333f) {
			Destroy(gameObject);
		}
	
	}
}

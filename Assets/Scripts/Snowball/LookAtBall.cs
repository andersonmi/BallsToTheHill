using UnityEngine;
using System.Collections;

public class LookAtBall : MonoBehaviour {
	
	public GameObject snowball;
	
	private Transform target;
	// Use this for initialization
	void Start () {
		target = snowball.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (target!=null) gameObject.transform.LookAt(target);
	}
}

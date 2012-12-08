using UnityEngine;
using System.Collections;

public class SnowballController : MonoBehaviour {
	
	public float Speed = 10f;
	public float bonus = 0f;
	public float TurnSpeed = 20f;
	
	private bool Maxed = false;
	private float currentSize;
	private GameObject snowball;
	
	private float touchTime;

	// Use this for initialization
	void Start () {
		snowball = GameObject.Find("SnowballCollider");
	
	}
	
	// Update is called once per frame
	void Update () {
		float xMov = 0;
		#if UNITY_IPHONE
		if (Input.touches.Length > 0) {
			Vector2 point = Input.touches[0].position;

			if (point.x < Screen.width / 2) {
				xMov = -Mathf.Clamp(Time.time - touchTime, 0, 1);
					//Input.touches[0].deltaPosition.x * Time.deltaTime;
			}
			else {
				xMov = Mathf.Clamp(Time.time - touchTime, 0, 1);
					//Input.touches[0].deltaPosition.x * Time.deltaTime;	
			}
		}
		#else
		xMov = Input.GetAxis("Horizontal");
		#endif
		currentSize = snowball.GetComponent<GetBigger>().getCurrentScale();
		if (currentSize == 10 && !Maxed) Maxed = true;
		//float forwardForce = constantForce.force.z;
		if (xMov!=0) {
			//constantForce.force = new Vector3(xMov * Speed, 0, forwardForce);
			if ( !Maxed) {
				rigidbody.velocity = new Vector3(xMov * (TurnSpeed-5), 0, (((currentSize * 0.75f) + 2.5f) * Speed) + bonus);
			}
			else {
				rigidbody.velocity = new Vector3(xMov * TurnSpeed, 0, (((currentSize * 0.5f) + 2.5f) * Speed) + 25); 
			}
		}
		else {
			if (!Maxed)
				rigidbody.velocity = new Vector3(0, 0, (((currentSize * 0.75f) + 2.5f) * Speed) + bonus);
			else
				rigidbody.velocity = new Vector3(0, 0, (((currentSize * 0.5f) + 2.5f) * Speed) + 25);
		}
	}
}

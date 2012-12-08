using UnityEngine;
using System.Collections;

public class ObjectHit : MonoBehaviour {
	
	public float sizeNeededToDestroy = 2f;
	public float sizeToSnowball = 0.2f;
	public int scoreGiven = 100;
	public GameObject hitParticle;
	private bool hasHit = false;
	private float killTimer = 0f;
	public GameObject snowParticle;
	public GameObject scorePopUp;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision snowball) {
			snowball.rigidbody.velocity = new Vector3(0, 0, snowball.rigidbody.velocity.z);	
	}
	
    void OnTriggerEnter(Collider snowball) {
		if (!hasHit) {
			if (snowball.tag == "Snowball") {
				AudioSource.PlayClipAtPoint(snowball.transform.audio.clip, snowball.transform.localPosition);
				float x = snowball.transform.localScale.x;
				if (x > sizeNeededToDestroy) {
					//Runs when the ball is larger then the object
					
					//Plays audio associated with objecty
					AudioSource.PlayClipAtPoint(gameObject.audio.clip, gameObject.transform.localPosition);
					
					//Adds size to the ball if it is not maxed
					if (!snowball.GetComponent<GetBigger>().getIsMax())
						snowball.transform.localScale += new Vector3(sizeToSnowball, sizeToSnowball, sizeToSnowball);
					
					//Spawns particles for the object hit
					if (gameObject.tag == "LargeY")	
						Instantiate(hitParticle, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y/2 + (snowball.transform.localScale.x / 2), gameObject.transform.position.z + 15), Quaternion.identity);
					else if (gameObject.tag == "evansrock")
						Instantiate(hitParticle, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + (snowball.transform.localScale.x / 2), gameObject.transform.position.z +5), Quaternion.identity);
					else
						Instantiate(hitParticle, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + (snowball.transform.localScale.x / 2), gameObject.transform.position.z + 15), Quaternion.identity);
					
					
					//Add size stuff to the score thing
					GameObject scoreboard = GameObject.FindWithTag("Score");
					scoreboard.GetComponent<ScoreScript>().Score += scoreGiven;
					
					//Spawn GUI Object with Score
					//
//					GameObject camera = GameObject.Find("Main Camera");
					//GameObject scorePos = GameObject.Find("ScorePopUpSpawn");
//					GameObject scoreGUI = (GameObject) Instantiate(scorePopUp, new Vector3(scorePos.transform.position.x, scorePos.transform.position.y, scorePos.transform.position.z), Quaternion.identity);
					//scoreGUI.GetComponent<TextMesh>().text = ("+" + scoreGiven + "!");
//					scoreGUI.gameObject.renderer.material.SetColor("_Color", Color.red);
					//scoreGUI.transform.parent = camera.transform;
					//scoreGUI.transform.localRotation = new Quaternion(0,0,0,1f);
					
					Destroy(gameObject);
					
				}
				else {
					if ( (x+1f) - (sizeNeededToDestroy - x) < 0) {
						GameObject scoreboard = GameObject.FindWithTag("Score");
						scoreboard.GetComponent<GameOver>().enabled = true;
						
						
						//Splats the ball (Death time!)
						snowball.transform.localRotation = new Quaternion(0,0,0,1f);
						snowball.transform.localScale = new Vector3(10, 10, 0.1f);
						
						GameObject.Find("MusicLevel").audio.enabled = false;
						
						Time.timeScale = 0;
					}
					if (!snowball.GetComponent<GetBigger>().getIsMin()) {
						snowball.transform.localScale -= new Vector3(sizeNeededToDestroy*sizeToSnowball, sizeNeededToDestroy*sizeToSnowball, sizeNeededToDestroy*sizeToSnowball);
						Instantiate(snowParticle, new Vector3(snowball.transform.position.x, snowball.transform.position.y , snowball.transform.position.z), Quaternion.identity);
						hasHit = true;
					}
				}
			}
		}
    }
	
	
	void OnTriggerStay(Collider snowball) {
		snowball.GetComponent<GetBigger>().isMoving = false;
		
		//Kill timer to remove the object if player gets "stuck" on it.
		killTimer+=1;
		if (killTimer > 100) {
			Destroy(gameObject);
			snowball.GetComponent<GetBigger>().isMoving = true;
		}
	}
	
	void OnTriggerExit(Collider snowball) {
		snowball.GetComponent<GetBigger>().isMoving = true;
	}
}
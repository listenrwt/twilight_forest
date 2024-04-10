using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour {
	private Transform player;
	public float smoothing;
	public Vector3 offset; 
	//shake screen
	public bool camerashake;
	public float shakestrength;
	public float shaketime; 
	private float bwshake;
	public GameObject boomsound;

	private gamemaster gm;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<gamemaster> ();
		bwshake = shaketime;
		camerashake = false;
		transform.position = gm.lastcheckpointpos;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = Vector3.Lerp (transform.position, player.position, smoothing) + offset;
	}
	//shake screen
	void Update() {
		if (camerashake) {
			Instantiate (boomsound, transform.position, Quaternion.identity);
			if (bwshake <= 0) {
				bwshake = shaketime;
				camerashake = false;
			} else if(Time.timeScale > 0f){
				Vector2 shake = Random.insideUnitCircle * shakestrength;
				transform.Translate (shake.x, shake.y, 0f);
				bwshake -= Time.deltaTime;
			}
		}
	}

}

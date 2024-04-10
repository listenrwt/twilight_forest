using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Naga_movement : MonoBehaviour {
	public float speed;
	public float maxspeed;
	private float currentspeed;
	public float timetospeedup;
	private float bwspeedup;
	private bool speedup;
	public Transform target;
	public float speeduptime;
	private float bwspeeduptime;
	public int damagetoplayer;
	private camera_follow camera;
	// Use this for initialization
	void Start () {
		speedup = false;
		bwspeedup = timetospeedup;
		currentspeed = speed;
		bwspeeduptime = speeduptime;
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<camera_follow> ();
	}

	// Update is called once per frame
	void Update () {
		if (barrier_trigger.Time_spowner_on == true && Vector2.Distance(transform.position,target.position) < 400) {	
			transform.position = Vector2.MoveTowards (transform.position, target.position, currentspeed * Time.deltaTime);
			if (bwspeedup <= 0) {
				speedup = true;
				bwspeedup = timetospeedup;
			} else if (speedup == false) {
				bwspeedup -= Time.deltaTime;
			}
			if (bwspeeduptime <= 0) {
				speedup = false;
				currentspeed = speed;
				bwspeeduptime = speeduptime;
			} else if (speedup == true) {
				bwspeeduptime -= Time.deltaTime;
				currentspeed = maxspeed;
			}
		}
	}
	void OnCollisionStay2D(Collision2D c) {
		if (c.gameObject.tag == "Player" && Vector2.Distance(transform.position,target.position) < 400 && Time.timeScale > 0) {
			c.gameObject.GetComponent<player_health> ().behurt (damagetoplayer);
			transform.position = Vector2.MoveTowards (transform.position, target.position, -100 * Time.deltaTime);
			camera.camerashake = true;
			camera.shakestrength = 4f;
			camera.shaketime = 0.25f;
		}
		if (c.gameObject.tag == "buildings") {  
			currentspeed = speed;
		}
	}
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour {
	private gamemaster gm;
	private bool isactive;
	private bool active;
	private Animator ani;
	private int a;
	private player_health player_health;
	public GameObject checkpoint_par;
	private camera_follow camera;


	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<gamemaster> ();
		ani = gameObject.GetComponent<Animator> ();
		isactive = false;
		a = 0;
		player_health = GameObject.FindGameObjectWithTag ("Player").GetComponent<player_health> ();
		camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<camera_follow > ();
	
	}
	
	// Update is called once per frame
	void Update () {
		ani.SetBool ("active", active);
		if (isactive) {
			active = true;
		} else {
			active = false;
		}
		if (a == 1) {
			//Player_control.CD_timer = 0;
			player_health.health = 10;
			Instantiate (checkpoint_par, transform.position, Quaternion.identity);
			camera.camerashake = true;
			camera.shakestrength = 2f;
			camera.shaketime = 0.25f;
			a += 1;
		}
	}
	void OnTriggerEnter2D(Collider2D c) {
		if (c.gameObject.tag == "Player") {
			gm.lastcheckpointpos = transform.position;
			isactive = true;
			a += 1;
		}
	}
	}

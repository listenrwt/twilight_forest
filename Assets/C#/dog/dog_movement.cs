using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dog_movement : MonoBehaviour {
	public float speed;
	private float maxspeed;
	public Transform player;
	public float detectdistance;
	public float startmove;
	private float bwmove;
	Rigidbody2D rid;
	private Vector2 moving;
	//attack
	public int damagetoplayer;
	//animation
	private Animator ani;
	private bool angry;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		bwmove = startmove;
		rid = GetComponent<Rigidbody2D> ();
		ani = gameObject.GetComponent<Animator> ();
		maxspeed = speed;
	}

	// Update is called once per frame
	void Update () {
		//animation
		ani.SetBool("angry",angry);
		if (Vector2.Distance (transform.position, player.position) <= detectdistance) {
			transform.position = Vector2.MoveTowards (transform.position, player.position, speed * Time.deltaTime);
			angry = true;

		} else {
			normalmovement ();
			angry = false;
		}
	}
	void normalmovement() {
		if (bwmove <= 0) {
			moving = new Vector2 (Random.Range (-3f, 3f), Random.Range (-3f, 3f));
			rid.velocity = moving;
			bwmove = startmove;
		} else {
			bwmove -= Time.deltaTime;
		}
	}
	void OnCollisionStay2D(Collision2D c) {
		if (c.gameObject.tag == "Player") {
			c.gameObject.GetComponent<player_health> ().behurt (damagetoplayer);
			transform.position = Vector2.MoveTowards (transform.position, player.position, -100 * Time.deltaTime);
		}
		if (c.gameObject.tag == "buildings") {
			speed = 15;
		}
	}
	void OnCollisionExit2D(Collision2D c) {
		if (c.gameObject.tag == "buildings") {
			speed = maxspeed;
		}
	}
}

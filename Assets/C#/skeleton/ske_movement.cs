using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ske_movement : MonoBehaviour {
	public float startmove;
	private float bwmove;
	private Vector2 moving;
	Rigidbody2D rb;
	private Transform player;
	public float detectdistance;
	private Vector2 direction;
	//attack var
	public float speed;
	public float stopdistance;
	public float reactdistance;
	//shooting var
	public GameObject arrow;
	public float starttoshot;
	private float bwshot;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		bwshot = starttoshot;
	}
	
	// Update is called once per frame
	void Update () {
		direction = new Vector2 (
			player.position.x - transform.position.x,
			player.position.y - transform.position.y);

		if (Vector2.Distance (transform.position, player.position) >= detectdistance) {
		    normalmovement ();
		} else {
			shooting ();
			attackmovement ();
		}

	}
	void normalmovement() {
		if (bwmove <= 0) {
			moving = new Vector2 (Random.Range (-3f, 3f), Random.Range (-3f, 3f));
			rb.velocity = moving;
			bwmove = startmove;
		} else {
			bwmove -= Time.deltaTime;
		}

}
	void attackmovement() {
		transform.up = direction;
		if (Vector2.Distance (transform.position, player.position) > stopdistance) {
			transform.position = Vector2.MoveTowards (transform.position, player.position, speed * Time.deltaTime);
		} else if (Vector2.Distance (transform.position, player.position) > reactdistance && Vector2.Distance (transform.position, player.position) < stopdistance) {
			transform.position = this.transform.position;
		} else if(Vector2.Distance (transform.position, player.position) < reactdistance){
			transform.position = Vector2.MoveTowards (transform.position, player.position, -speed * Time.deltaTime);
		}
}
	void shooting() {
		if (bwshot <= 0) {
			Instantiate (arrow, transform.position, transform.rotation);
			bwshot = starttoshot;
		} else {
			bwshot -= Time.deltaTime;
		}
}

}
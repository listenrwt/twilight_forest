using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tracting_ball : MonoBehaviour {
	private Transform player;
	public float speed;
	public float tracttime;
	private float bwtract;
	public int damagetoplayer;
	private camera_follow camera;
	public GameObject destroy_par;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		bwtract = tracttime;
		camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<camera_follow> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, player.position, speed * Time.deltaTime);
		if (bwtract <= 0) {
			Destroy (gameObject);
			Instantiate (destroy_par, transform.position, Quaternion.identity);
			bwtract = tracttime;
		} else {
			bwtract -= Time.deltaTime;
		}
	}
	void OnTriggerEnter2D(Collider2D c) {
		if (c.gameObject.tag == "Player") {
			Instantiate (destroy_par, transform.position, Quaternion.identity);
			Destroy (gameObject);
			c.gameObject.GetComponent<player_health> ().behurt (damagetoplayer);
			camera.camerashake = true;
			camera.shakestrength = 5f;
			camera.shaketime = 0.25f;
		}
	}
}

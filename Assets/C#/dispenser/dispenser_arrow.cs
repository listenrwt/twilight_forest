using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dispenser_arrow : MonoBehaviour {
	public float speed;
	public int damagetoplayer;
	private camera_follow camera;
	public GameObject destroy_par;
	// Use this for initialization
	void Start () {
		camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<camera_follow> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0, speed * Time.deltaTime, 0);

	}
	void OnTriggerEnter2D (Collider2D c) {
		if (c.gameObject.CompareTag ("Player")) {
			c.gameObject.GetComponent<player_health> ().behurt (damagetoplayer);
		}
		if (c.gameObject.CompareTag ("Player")) {
				Destroy (gameObject);
			Instantiate (destroy_par, transform.position, Quaternion.identity);
			camera.camerashake = true;
			camera.shakestrength = 5f;
			camera.shaketime = 0.25f;
			}
		if (c.gameObject.tag == "buildings") {
			Destroy (gameObject);
			Instantiate (destroy_par, transform.position, Quaternion.identity);
		}
		}
	}
	


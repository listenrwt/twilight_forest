using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ske_arrow_shoot : MonoBehaviour {
	public float arrowspeed;

	public float mixdistance;
	public int dam_to_player;
	public float arrowtime;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.Translate (0,arrowspeed * Time.deltaTime,0);
		Destroy (gameObject,arrowtime);
	}
	void OnTriggerEnter2D (Collider2D c) {
		if (c.gameObject.CompareTag ("Player") || c.gameObject.CompareTag ("buildings")) {
			Destroy (gameObject);
		}
		if (c.gameObject.tag == "Player") {
			c.gameObject.GetComponent<player_health> ().behurt (dam_to_player);
		}
	}

	}


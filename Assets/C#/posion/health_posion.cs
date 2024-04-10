using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_posion : MonoBehaviour {
	public int health_amount;
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D c) {
		if (c.gameObject.tag == "Player") {
			c.gameObject.GetComponent<player_health> ().behurt (-health_amount);
			Destroy (gameObject);
		}
	}

}

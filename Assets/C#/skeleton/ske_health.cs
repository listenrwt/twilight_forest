using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ske_health : MonoBehaviour {
	public int health;
	private bool hurtcolor;
	//particle
	public GameObject damage_par;
	public GameObject death_par;
	//audio
	public GameObject diesound;
	// Use this for initialization
	void Start () {
		hurtcolor = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			die ();
		}
		if (hurtcolor) {
			gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
			hurtcolor = false;
		} else {
			gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
		}
	}
	public void behurt(int damage) {
		health -= damage;
		hurtcolor = true;
		Instantiate (damage_par, transform.position, Quaternion.identity);

	}
	void die() {
		Destroy (gameObject);
		hurtcolor = true;
		Instantiate (death_par, transform.position, Quaternion.identity);
		Instantiate (diesound, transform.position, Quaternion.identity);
	}
}

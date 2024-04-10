using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spider_toxic : MonoBehaviour {
	public int damagetoplayer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay2D(Collider2D c) {
		if (c.gameObject.tag == "Player") {
			c.gameObject.GetComponent<player_health> ().behurt (damagetoplayer);
		}
	}
}

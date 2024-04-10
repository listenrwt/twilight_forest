using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier_trigger : MonoBehaviour {
	public static bool Time_spowner_on;
	private float a;
	// Use this for initialization
	void Start () {
		Time_spowner_on = false;
		a = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (a == 1) {
			barrier_control.isopened = false;
			Time_spowner_on = true;
			a += 1;
		}
	}
	void OnTriggerEnter2D(Collider2D c) {
		if (c.gameObject.tag == "Player") {
			a += 1;

		}
	}
}

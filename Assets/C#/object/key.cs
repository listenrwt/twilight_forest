﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D c) {
		if (c.gameObject.tag == "Player") {
			Destroy (gameObject);
		}
	}
}

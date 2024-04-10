﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particledestroysystem : MonoBehaviour {
	private ParticleSystem par;
	// Use this for initialization
	void Start () {
		par = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (par) {
			if (!par.IsAlive ()) {
				Destroy (gameObject);
			}
		}
	}
}

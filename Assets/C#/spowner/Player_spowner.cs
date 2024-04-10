using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_spowner : MonoBehaviour {
	private Transform player;
	private bool a;
	// Use this for initialization
	void Start () {
		a = true;
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (a) {
			player.position = transform.position;
			a = false;
		}
	}
}

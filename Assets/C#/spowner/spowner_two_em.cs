using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spowner_two_em : MonoBehaviour {
	public GameObject monster;
	public GameObject monster2;
	public float active_distance;
	private Transform player;
	public int spown_am;
	public int spown_am_2;
	private int a;
	private int b;
	private bool spownnow;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		spownnow = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector2.Distance (transform.position, player.position) < active_distance && spownnow == true) {
			for (a = 0; a < spown_am; a++) {
				Instantiate (monster, transform.position, Quaternion.identity);
			}
			for (b = 0; b < spown_am_2; b++) {
				Instantiate (monster2, transform.position, Quaternion.identity);
			}
			spownnow = false;
		}
	}
	}


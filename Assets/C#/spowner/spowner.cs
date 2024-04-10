using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spowner : MonoBehaviour {
	public GameObject monster;
	public float active_distance;
	private Transform player;
	public int spown_am;
	private int a;
	private bool spownnow;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		spownnow = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector2.Distance(transform.position,player.position) < active_distance &&  spownnow == true) {
			for (a = 0; a < spown_am; a++) {
				Instantiate (monster,transform.position, Quaternion.identity);
			}
			spownnow = false;
		}
	}

}

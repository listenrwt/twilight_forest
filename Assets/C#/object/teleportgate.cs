using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportgate : MonoBehaviour {
	public Vector3 tp_pos;
	public GameObject tp_par;
	public GameObject tpsound;
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D c) {
		if (c.gameObject.tag == "Player") {
			c.transform.position = tp_pos;
			Instantiate (tpsound, transform.position, Quaternion.identity);
			GameObject.FindGameObjectWithTag ("MainCamera").transform.position = tp_pos;
			Instantiate (tp_par, tp_pos, Quaternion.identity);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_enable : MonoBehaviour {
	public Canvas lich_healthbar;
	// Use this for initialization
	void Start () {
		lich_healthbar.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D c) {
		if (c.gameObject.tag == "Player") {
			lich_healthbar.enabled = true;
		}
	}
}

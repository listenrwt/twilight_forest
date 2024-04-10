using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lich_bullet : MonoBehaviour {
	public GameObject destroypar;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D c) {
		if (c.gameObject.tag == "lich") {
			if (!lich_movement.lichangry) {
				c.gameObject.GetComponent<lich_health> ().loss_shield (1);
				Destroy (gameObject);
				Instantiate (destroypar, transform.position, Quaternion.identity);
			}
		}
	}
}

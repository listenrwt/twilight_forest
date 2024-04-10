using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockgate : MonoBehaviour {
	public GameObject key;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!key) {
			Destroy (gameObject);
		}
	}
}

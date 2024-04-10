using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapcollisionpos_fix : MonoBehaviour {
	//public Vector3 maplocationfix;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position = maplocationfix;
		transform.localPosition = Vector3.zero;
	}
}

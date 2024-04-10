using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier_control : MonoBehaviour {
	public static bool isopened;
	private Vector3 ori_position;
	private Vector3 move_position;


	// Use this for initialization
	void Start () {
		ori_position = transform.position;
		move_position = new Vector3 (0, 2000, 0);
		isopened = true;
	

	}

	
	// Update is called once per frame
	void Update () {
		//gate open
		if (isopened) {
			transform.position += move_position;
		} else {
			transform.position = ori_position;

		}

	}
}

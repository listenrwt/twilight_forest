using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousefollow : MonoBehaviour {
	private Vector3 mouseposition;
	private Vector2 direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale > 0f) {
			mouseposition = Input.mousePosition;
			mouseposition = Camera.main.ScreenToWorldPoint (mouseposition);

			direction = new Vector2 (
				-transform.position.x + mouseposition.x,
				-transform.position.y + mouseposition.y);
			transform.up = direction;
		}
	}
}

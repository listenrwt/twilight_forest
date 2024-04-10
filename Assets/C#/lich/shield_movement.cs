using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield_movement : MonoBehaviour {
	public float rotateSpeed;
	public float radius;
	private Vector2 offset;

	private Vector2 centre;
	public float angle;

	void Update () {
		centre = GameObject.FindGameObjectWithTag ("lich").transform.position;
		angle += (Time.deltaTime * rotateSpeed);
		offset = new Vector2 (Mathf.Cos (angle *  Mathf.Deg2Rad) * radius, Mathf.Sin (angle *  Mathf.Deg2Rad) * radius);
		transform.position = centre + offset;
	}
}

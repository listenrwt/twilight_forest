using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazer : MonoBehaviour {
	public float rotatespeed;
	public float distance;
	public int damagetoplayer;
	public LineRenderer the_lazer;
	public bool left;
	// Use this for initialization
	void Start () {
		Physics2D.queriesStartInColliders = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (left) {
			transform.Rotate (Vector3.forward * rotatespeed * Time.deltaTime);
		} else {
			transform.Rotate (Vector3.back * rotatespeed * Time.deltaTime);
		}
		RaycastHit2D hitinfo = Physics2D.Raycast (transform.position, transform.right, distance);
			if (hitinfo != null) {
				Debug.DrawLine (transform.position, hitinfo.point, Color.red);
				the_lazer.SetPosition (1, hitinfo.point);
			}
			if (hitinfo.collider.tag == "Player") {
				GameObject.FindGameObjectWithTag ("Player").GetComponent<player_health> ().behurt (damagetoplayer);
			}
		the_lazer.SetPosition (0, transform.position);
	}
}


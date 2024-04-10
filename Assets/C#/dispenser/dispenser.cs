using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dispenser : MonoBehaviour {
	public float startshot;
	private float timebwshot;
	public GameObject arrow;

	// Use this for initialization
	void Start () {
	 
	}
	
	// Update is called once per frame
	void Update () {
		if (timebwshot <= 0) {
			Instantiate (arrow, transform.position, transform.rotation);
		
			timebwshot = startshot;
		}else {
			timebwshot -= Time.deltaTime;
		}
		}
	}
	

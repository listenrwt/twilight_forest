using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tailfade : MonoBehaviour {
	private float timebtwspawns;
	public float starttimebtwspawns;
	public float destroytime;
	public GameObject echo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timebtwspawns <= 0) {
			GameObject instance = (GameObject)Instantiate (echo, transform.position, Quaternion.identity);
			Destroy (instance, destroytime);
			timebtwspawns = starttimebtwspawns;
		} else {
			timebtwspawns -= Time.deltaTime;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delayspawner : MonoBehaviour {
	private float timebtwspawns;
	public float starttimebtwspawns;
	public float destroytime;
	public GameObject echo;
	public float secondsdelay;
	private float timer;
	// Use this for initialization
	void Start () {
		timer = secondsdelay;
	}

	// Update is called once per frame
	void Update () {
		if (timer <= 0) {
			if (timebtwspawns <= 0) {
				GameObject instance = (GameObject)Instantiate (echo, transform.position, Quaternion.identity);
				Destroy (instance, destroytime);
				timebtwspawns = starttimebtwspawns;
			} else {
				timebtwspawns -= Time.deltaTime;
			}
		} else {
			timer -= Time.deltaTime;
		}

	}
}

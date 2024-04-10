using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemaster : MonoBehaviour {
	private static gamemaster instance;
	public Vector2 lastcheckpointpos;
	public float saveCDvalue;

	// Use this for initialization
	void Start () {
		saveCDvalue = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player_control> ().CD;

	}
	
	// Update is called once per frame
	void Awake () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (instance);
		} else {
			Destroy (gameObject);
		}
	}
	void Update() {
		saveCDvalue = Player_control.CD_timer;
	}
}

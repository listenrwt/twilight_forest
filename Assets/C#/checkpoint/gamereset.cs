using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamereset : MonoBehaviour {
	private gamemaster gm;
	public Vector3 startpoint;
	private Transform cam;
	void Start() {
		gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<gamemaster>();
		cam = GameObject.FindGameObjectWithTag ("MainCamera").transform;
	}
	public void GameReset() {
		gm.lastcheckpointpos = startpoint;
		cam.position = startpoint;
		Player_control.CD_timer = 35;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CD_bar : MonoBehaviour {
	public Image circlebar;
	private float maxcd;
	private float CD;
	private float changespeed;
	// Use this for initialization
	void Start () {
		maxcd = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player_control> ().CD;
		changespeed = 0.3f;
	}
	
	// Update is called once per frame
	void Update () {
		if (CD >= maxcd) {
			if (changespeed <= 0) {
				circlebar.enabled = false;
				changespeed = 0.3f;
			} else {
				circlebar.enabled = true;
				changespeed -= Time.deltaTime;
			}
		} else {
			circlebar.enabled = true;
		}
		CD = maxcd - Player_control.CD_timer;
		circlebar.fillAmount = CD / maxcd;
	}
}

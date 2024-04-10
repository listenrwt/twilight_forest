using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lich_healthbar : MonoBehaviour {
	private float maxhealth;
	private float health;
	// Use this for initialization
	void Start () {
		maxhealth = GameObject.FindGameObjectWithTag ("lich").GetComponent<lich_health> ().maxhealth;
	}
	
	// Update is called once per frame
	void Update () {
		health = GameObject.FindGameObjectWithTag ("lich").GetComponent<lich_health> ().health;
		this.transform.localPosition = new Vector3 (-228 + 210 * (health / maxhealth), 0f, 0f);
	}
}

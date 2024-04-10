using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_spowner : MonoBehaviour {
	public GameObject a;
	public GameObject b;
	public GameObject c;
	public GameObject d;
	public float spownertimer;
	private float bwspown;
	public float a_per;
	public float b_per;
	public float c_per;
	public float d_per;
	private float per;
	private bool spown;
	// Use this for initialization
	void Start () {
		per = Random.Range (0f, 100f);
		spown = false;
	}

	// Update is called once per frame
	void Update () {
		if (barrier_trigger.Time_spowner_on) {
			timetospown ();
			if (bwspown <= 0) {
				spown = true;
				bwspown = spownertimer;
			} else if(barrier_trigger.Time_spowner_on){
				bwspown -= Time.deltaTime;
			}
		} 
	}
	void timetospown() {
		if (per <= a_per && spown == true) {
			Instantiate (a, transform.position, Quaternion.identity);
			spown = false;
			per = Random.Range (0f, 100f);
		} else if (per > a_per && per <= a_per + b_per && spown == true) {
			Instantiate (b, transform.position, Quaternion.identity);
			spown = false;	
			per = Random.Range (0f, 100f);
		}else if (per > a_per + b_per && per <= a_per + b_per + c_per && spown == true) {
			Instantiate (c, transform.position, Quaternion.identity);
			spown = false;	
			per = Random.Range (0f, 100f);
		}else if (per > a_per + b_per + c_per && spown == true) {
			Instantiate (d, transform.position, Quaternion.identity);
			spown = false;	
			per = Random.Range (0f, 100f);
}
}
}
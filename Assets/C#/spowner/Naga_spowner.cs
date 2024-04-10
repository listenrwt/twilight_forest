using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Naga_spowner : MonoBehaviour {
	private bool a;
	public float timetospown;
	private float timebwspown;
	public Transform ob;
	// Use this for initialization
	void Start () {
		a = true;
		timebwspown = timetospown;
	}
	
	// Update is called once per frame
	void Update () {
		if (barrier_trigger.Time_spowner_on == true && a == true) {
			if (timebwspown <= 0) {
				ob.position = transform.position;
				a = false;
				timebwspown = timetospown;
			} else {
				timebwspown -= Time.deltaTime;
			}
		}
	}

}

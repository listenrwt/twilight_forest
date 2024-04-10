using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Naga_health : MonoBehaviour {
	public float health;
	public float maxhealth;
	public static float Nagahealth;
	public float timetoregan;
	private float timebwregan;
	private bool startcountregan;
	public int reganamount;
	public float reganper_s;
	private float reganper_scounter;
	public Image[] ob;
	private bool hurtcolor;
	public GameObject totem;
	//particle
	public GameObject damage_par;
	public GameObject death_par;
	//audio
	public GameObject diesound;
	// Use this for initialization
	void Start () {
		timebwregan = timetoregan;
		startcountregan = false;
		reganper_scounter = reganper_s;
		ob[0].enabled = false;
		ob[1].enabled = false;
		ob[2].enabled = false;
		hurtcolor = false;
	}

	// Update is called once per frame
	void Update () {
		Nagahealth = health;
		HealthUI ();
		//start regan
		if (startcountregan == false) {
			if (timebwregan <= 0) {
				startcountregan = true;
				timebwregan = timetoregan;
			} else {
				timebwregan -= Time.deltaTime;
			}
		} else {
			timebwregan = timetoregan;
		}
		//being regan
		if (startcountregan) {
			if (reganper_scounter <= 0) {
				if (health >= maxhealth) {
					health = maxhealth;
				} else {
					health += reganamount;
				}
				reganper_scounter = reganper_s;
			} else {
				reganper_scounter -= Time.deltaTime;
			}
		} else {
			reganper_scounter = reganper_s;
		}


		if (health <= 0) {
			die ();
		}
		if (hurtcolor) {
			gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
			hurtcolor = false;
		} else {
			gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
		}
	}
	void die() {
		Destroy (gameObject);
		barrier_trigger.Time_spowner_on = false;
		startcountregan = false;
		Instantiate (death_par, transform.position, Quaternion.identity);
		Instantiate (totem, transform.position, Quaternion.identity);
		Instantiate (diesound, transform.position, Quaternion.identity);
	}
	public void behurt(float damage) {
		health -= damage;
		startcountregan = false;
		hurtcolor = true;
		Instantiate (damage_par, transform.position, Quaternion.identity);
	}
	void HealthUI() {
		if (barrier_trigger.Time_spowner_on) {
			ob[0].enabled = true;
			ob[1].enabled = true;
			ob[2].enabled = true;
		} else{
			ob[0].enabled = false;
			ob[1].enabled = false;
			ob[2].enabled = false;
		}
	}
	}
	

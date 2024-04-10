using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow_control : MonoBehaviour {
	public float arrowspeed;
	public float arrowtime;
	private float arrowbwtime;
	public int damagetomonster;
	public GameObject hitsound;
	// Use this for initialization
	void Start () {
		arrowbwtime = arrowtime;
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0,arrowspeed * Time.deltaTime,0);
		if (arrowbwtime <= 0) {
			Destroy (gameObject);
			arrowbwtime = arrowtime;
		}else {
			arrowbwtime -= Time.deltaTime;
		}
	}
	void OnTriggerEnter2D (Collider2D c) {
		
		if (c.gameObject.CompareTag ("buildings")) {
			Destroy (gameObject);

		}
		if (c.gameObject.CompareTag ("skeleton")) {
			c.gameObject.GetComponent<ske_health> ().behurt (damagetomonster);
			Destroy (gameObject);
			Instantiate (hitsound, transform.position, Quaternion.identity);
		}
		if (c.gameObject.CompareTag ("zombie")) {
			c.gameObject.GetComponent<zombie_health> ().behurt (damagetomonster);
			Destroy (gameObject);
			Instantiate (hitsound, transform.position, Quaternion.identity);
		}
		if (c.gameObject.CompareTag ("dog")) {
			c.gameObject.GetComponent<dog_health> ().behurt (damagetomonster);
			Destroy (gameObject);
			Instantiate (hitsound, transform.position, Quaternion.identity);
		}
		if (c.gameObject.CompareTag ("Naga")) {
			c.gameObject.GetComponent<Naga_health> ().behurt (damagetomonster);
			Destroy (gameObject);
			Instantiate (hitsound, transform.position, Quaternion.identity);
		}
		if (c.gameObject.CompareTag ("book")) {
			c.gameObject.GetComponent<book_health> ().behurt (damagetomonster);
			Destroy (gameObject);
			Instantiate (hitsound, transform.position, Quaternion.identity);
	}
		if (c.gameObject.CompareTag ("spider")) {
			c.gameObject.GetComponent<spider_health> ().behurt (damagetomonster);
			Destroy (gameObject);
			Instantiate (hitsound, transform.position, Quaternion.identity);
		}
		if(c.gameObject.CompareTag("lich")) {
			Destroy (gameObject);
			Instantiate (hitsound, transform.position, Quaternion.identity);
			if (lich_movement.lichangry) {
				c.gameObject.GetComponent<lich_health> ().behurt (damagetomonster);
				Instantiate (hitsound, transform.position, Quaternion.identity);
		}
		}
}
			}
	


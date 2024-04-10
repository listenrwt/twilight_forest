using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class lich_health : MonoBehaviour {
	public float health;
	public float maxhealth;
	public int shieldamount;


	private bool hurtcolor;
	public GameObject damage_par;
	public GameObject totem;
	public GameObject death_par;
	//UI
	public GameObject[] shield;
	public Image[] shieldUI;
	//audio
	public GameObject diesound;
	// Use this for initialization
	void Start () {
		hurtcolor = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (shieldamount <= 0) {
			lich_movement.lichangry = true;
		}
		if (health <= 0) {
			Destroy (gameObject);
			Instantiate (totem, transform.position, Quaternion.identity);
			Instantiate (death_par, transform.position, Quaternion.identity);
			Instantiate (diesound, transform.position, Quaternion.identity);
		}
		if (hurtcolor) {
			gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
			hurtcolor = false;
		} else {
			gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
		}
		//UI
		for (int i = 0; i < shieldUI.Length; i++) {
			if (i < shieldamount) {
				shieldUI [i].enabled = true;
			} else {
				shieldUI [i].enabled = false;
			}
		}
	}
	public void loss_shield(int loss) {
		shieldamount -= loss;
		Destroy (shield [shieldamount]);
		Instantiate (damage_par, transform.position, Quaternion.identity);
	}

	public void behurt (int damage)
	{
		health -= damage;
		hurtcolor = true;
		Instantiate (damage_par, transform.position, Quaternion.identity);
	}
}

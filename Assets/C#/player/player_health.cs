using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class player_health : MonoBehaviour {
	public int health;
	public int maxhealth;
	public float rehurttimer;
	private float bwrehurt;
	private bool startrehurt;
	public Image[] hearts;
	private gamemaster gm;
	private float respowntime;
	private Animator ani;
	private bool playerdie;
	//particle
	public GameObject damage_par;
	public GameObject death_par;

	private bool ins_once;
	//audio
	public GameObject hurtsound;
	public GameObject diesound;
	// Use this for initialization
	void Start () {
		startrehurt = false;
		gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<gamemaster> ();
		transform.position = gm.lastcheckpointpos;
		bwrehurt = rehurttimer;
		respowntime = 1f;
		ani = gameObject.GetComponent<Animator> ();
		playerdie = false;
		ins_once = true;

	}
	
	// Update is called once per frame
	void Update () {
		if (health > maxhealth) {
			health = maxhealth;
		}


		ani.SetBool ("playerdie", playerdie);
		if (health <= 0) {
			die ();
		} 
		if (startrehurt) {
			countrehurt ();	
			if (!GameObject.FindGameObjectWithTag ("Player").GetComponent<Player_control> ().slowdown) {
				gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
			} else {
				gameObject.GetComponent<SpriteRenderer> ().color = Color.blue;
			}
		} else {
			gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
		}
		
		//health_UI
		for (int i = 0; i < hearts.Length; i++) {
			if (i < health) {
				hearts [i].enabled = true;
			} else {
				hearts [i].enabled = false;
			}
		}

	}
	//collect damage
	public void behurt(int damage) {
		if (startrehurt == false) {
			health -= damage;
			startrehurt = true;
		    Instantiate (damage_par, transform.position, Quaternion.identity);
			Instantiate (hurtsound, transform.position, Quaternion.identity);
		}
	}
	void die() {
		if (ins_once) {
			Instantiate (death_par, transform.position, Quaternion.identity);
			Instantiate (diesound, transform.position, Quaternion.identity);
			ins_once = false;
		}
		//Destroy (gameObject);
		if (respowntime <= 0) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			respowntime = 1f;
		} else {
			respowntime -= Time.deltaTime;
			playerdie = true;
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Player_control> ().speed = 0f;
		}
	}
	void countrehurt() {
		if (bwrehurt <= 0) {
			startrehurt = false;
			bwrehurt = rehurttimer;

		}else {
				bwrehurt -= Time.deltaTime;
			}
		}
	}




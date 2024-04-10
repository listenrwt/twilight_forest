using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lich_movement : MonoBehaviour {
	public float speed;
	private float maxspeed;
	private Rigidbody2D rb;
	private Vector2 velo;
	public int damagetoplayer;

	public static bool lichangry;
	private Transform player;

	public float startspawn;
	private float bwspawn;
	public float timetoshot;
	private float bwshot;
	private int monsterspawn;
	public GameObject monster;
	public GameObject monster2;
	public GameObject monster3;
	public GameObject monster4;
	public GameObject angryzombie;
	public GameObject bullet;
	public GameObject lazer;
	private int i;
	private int insonce;
	//normalmovement
	private bool move;
	public float timetomove;
	private float bwmove;
	public float timetostop;
	private float bwstop;

	// Use this for initialization
	void Start () {
		maxspeed = speed;
		lichangry = false;
		bwspawn = startspawn;
		rb = GetComponent<Rigidbody2D> ();
		move = false;
		bwstop = timetostop;
		bwmove = timetomove;
		i = 1;
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		bwshot = timetoshot;
		insonce = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector2.Distance(transform.position,player.position) <= 300) {
			if (!lichangry) {
				normalmovement ();
				spawnmonster ();
			}
			if (lichangry) {
				startspawn = 5f;
				while (i <= 8) {
					Instantiate (angryzombie, transform.position, Quaternion.identity);
					i += 1;
				}

				if (insonce == 0) {
					Instantiate (lazer, transform.position, Quaternion.identity);
					insonce += 1;
				}
				spawnmonster ();
				transform.position = Vector2.MoveTowards (transform.position, player.position, speed * Time.deltaTime);
				if (bwshot <= 0) {
					Instantiate (bullet, transform.position, transform.rotation);
					bwshot = timetoshot;
				} else {
					bwshot -= Time.deltaTime;
				}
			}
		}

	}
	void normalmovement() {
		if (!move) {
			if (bwstop <= 0) {
				bwmove = timetomove;
				velo = new Vector2(Random.Range (-5f, 5f), Random.Range (-5f, 5f));
				move = true;
			} else {
				bwstop -= Time.deltaTime;
			}
		}
		if (move) {
			if (bwmove <= 0) {
				bwstop = timetostop;
				move = false;
			} else {
				rb.velocity = velo;
				bwmove -= Time.deltaTime;
			}
		}
	}
	void spawnmonster() {
		if (bwspawn <= 0) {
			monsterspawn = Random.Range (1, 5);

			switch (monsterspawn) {
			case 1:
				Instantiate (monster, transform.position, Quaternion.identity);
				break;
			case 2:
				Instantiate (monster2, transform.position, Quaternion.identity);
				break;
			case 3:
				Instantiate (monster3, transform.position, Quaternion.identity);
				break;
			case 4:
				Instantiate (monster4, transform.position, Quaternion.identity);
				break;
			}
			bwspawn = startspawn;
		} else {
			bwspawn -= Time.deltaTime;
		}
	}
	void OnCollisionStay2D(Collision2D c) {
		if (c.gameObject.tag == "Player") {
			c.gameObject.GetComponent<player_health> ().behurt (damagetoplayer);
			transform.position = Vector2.MoveTowards (transform.position, player.position, -100 * Time.deltaTime);
		}
		if (c.gameObject.tag == "buildings") {
			speed = 15;
		}

	}
	void OnCollisionExit2D(Collision2D c) {
		if (c.gameObject.tag == "buildings") {
			speed = maxspeed;
		}
}
}

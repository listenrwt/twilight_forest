using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lichfade_movement : MonoBehaviour {
	public Vector3[] tplocation = new Vector3[6];
	private int randtp;
	private int dont_repeat;

	public GameObject[] bullet;
	public GameObject tp_par;
	private int randbullet;


	private Transform player_transform;
	private Transform lich_transform;

	//timer
	private bool timetoshot;
	public float start_tp;
	private float bw_tp;
	public float start_shot;
	private float bw_shot;
	//audio
	public GameObject teleportsound;
	public GameObject shotsound;
	// Use this for initialization
	void Start () {
		player_transform = GameObject.FindGameObjectWithTag ("Player").transform;
		lich_transform = GameObject.FindGameObjectWithTag ("lich").transform;
		bw_shot = start_shot;
		bw_tp = start_tp;
		timetoshot = true;
		dont_repeat = -1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector2.Distance(transform.position,player_transform.position) <= 300) {
			//look at player
			transform.up = new Vector2 (
				player_transform.position.x - transform.position.x,
				player_transform.position.y - transform.position.y);
			if (!lich_movement.lichangry) {
				//timer
				if (timetoshot) {
					if (bw_shot <= 0) {
						shot ();
						timetoshot = false;
						bw_tp = start_tp;
					} else {
						bw_shot -= Time.deltaTime;
					}
				} 
				if (!timetoshot) {
					if (bw_tp <= 0) {
						teleport ();
						timetoshot = true;
						bw_shot = start_shot;
					} else {
						bw_tp -= Time.deltaTime;
					}
				}
			}
			if (lich_movement.lichangry) {
				transform.position = Vector2.MoveTowards (transform.position, lich_transform.position, 80 * Time.deltaTime);
				if (Vector2.Distance (transform.position, lich_transform.position) <= 0) {
					Destroy (gameObject);
				}
			}


		}
	}
	void teleport() {
		randtp = Random.Range (0, 5);
		Instantiate (teleportsound, transform.position, Quaternion.identity);
		if (dont_repeat != randtp) {
			transform.position = tplocation [randtp];
			Instantiate (tp_par, transform.position, Quaternion.identity);
			dont_repeat = randtp;
		} else {
			randtp += 1;
			transform.position = tplocation [randtp];
			Instantiate (tp_par, transform.position, Quaternion.identity);
			dont_repeat = randtp;
		}


	}
	void shot() {
		randbullet = Random.Range (0, 3);
		Instantiate (shotsound, transform.position, Quaternion.identity);
		Instantiate (bullet[randbullet], transform.position, transform.rotation);
	}
}

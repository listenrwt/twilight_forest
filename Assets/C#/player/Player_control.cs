using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_control : MonoBehaviour {
	public float speed;
	public float maxspeed;
	public GameObject arrow;
	private Rigidbody2D rb;
	private Vector3 moveInput;
	private Vector3 moveVelocity;
	private gamemaster gm;
	public float shootingspeed;
	private float shootingspeedbw;

	//CD
	public float CD;
	public static float CD_timer;
	public float CDarrow_amount;
	private bool CDshot;
	public float CDshootingspeed;
	private float CDshootingspeedbw;

	int i;
	int j;
	//slowdown
	public float slowtimer;
	private float bwslow;
	public bool slowdown;
	public GameObject slow_par;
	//spiderwrap
	public float spiderwrapslowspeed;
	private bool backnormalspeed;
	//audio		
	public GameObject shotsound;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		shootingspeedbw = shootingspeed;
		CD_timer = CD;
		i = 0;
		j = 0;
		CDshot = false;
		CDshootingspeedbw = CDshootingspeed;
		gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<gamemaster> ();
		CD_timer = gm.saveCDvalue;
		maxspeed = speed;
		slowdown = false;
		bwslow = slowtimer;
		backnormalspeed = false;
	}
	
	// Update is called once per frame
	 void Update () {
		moveInput = new Vector3 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		moveVelocity = moveInput * speed;
		//shooting part 
		if (Time.timeScale > 0f) {
			if (Input.GetMouseButton (0) && shootingspeedbw <= 0) {
				Instantiate (arrow, transform.position, transform.rotation);
				Instantiate (shotsound, transform.position, Quaternion.identity);
				shootingspeedbw = shootingspeed;
			} else {
				shootingspeedbw -= Time.deltaTime;
			}
		}
		//CD
		if (CD_timer <= 0) {
			if (Input.GetMouseButtonDown(1)) {
				CDshot = true;
			}
		} else if(CD_timer > 0){
			CD_timer -= Time.deltaTime;
		}
		if (CDshot) {
			CDshooting ();
		}
		//slow
		if (slowdown) {
			if (j == 0) {
				Instantiate (slow_par, transform.position, Quaternion.identity);
				j += 1;
			}
			if (bwslow <= 0) {
				speed = maxspeed;
				bwslow = slowtimer;
				gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
				slowdown = false;
				j = 0;
			} else {
				bwslow -= Time.deltaTime;
				gameObject.GetComponent<SpriteRenderer> ().color = Color.blue;
			}
		}
		//spiderwrap
		if (backnormalspeed) {
			speed = maxspeed;
			backnormalspeed = false;
		}
		}

	void FixedUpdate() {
		rb.velocity = moveVelocity;
	}
	void CDshooting() {
		if (CDshootingspeedbw <= 0) {
			Instantiate (arrow, transform.position, transform.rotation);
			Instantiate (shotsound, transform.position, Quaternion.identity);
			++i;
			CDshootingspeedbw = CDshootingspeed;
		} else {
			CDshootingspeedbw -= Time.deltaTime;
		}
		if (i == CDarrow_amount) {
			CDshot = false;
			i = 0;
			CD_timer = CD;
		}
	}
	public void hasbeenslowed(float slowspeed) {
		speed = slowspeed;
		slowdown = true;
}
	void OnTriggerStay2D(Collider2D c) {
		if(c.gameObject.tag == "spiderwrap")
		speed = spiderwrapslowspeed;
		backnormalspeed = true;
	}
}

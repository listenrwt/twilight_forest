using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class totem : MonoBehaviour {
	private gamemaster gm;
	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<gamemaster> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D c) {
		if (c.gameObject.tag == "Player") {
			SceneManager.LoadScene ("start_UI");
			Cursor.visible = true;
			if (levelsystem.levelrate < 2) {
				levelsystem.levelrate = 2;
			}
		}
	}
}

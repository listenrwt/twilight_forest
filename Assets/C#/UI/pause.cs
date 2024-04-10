using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pause : MonoBehaviour {
	private bool ispause = false;
	public GameObject pauseUI;
	public GameObject buttonsound;
	// Use this for initialization
	void Start () {
		pauseUI.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Instantiate (buttonsound, transform.position, Quaternion.identity);
			if (ispause) {
				notpause ();
			} else {
				Cursor.visible = true;
				pauseUI.SetActive (true);
				Time.timeScale = 0f;
				ispause = true;
			}
		}
	}
	public void notpause() {
		Cursor.visible = false;
		pauseUI.SetActive (false);
		Time.timeScale = 1f;
		ispause = false;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class splash_scene : MonoBehaviour {
	public float staytime;
	private float bwstay;
	void Start() {
		bwstay = staytime;
	}
	void Update() {
		if (bwstay <= 0) {
			SceneManager.LoadScene ("menu");
		} else {
			bwstay -= Time.deltaTime;
		}
	}
}

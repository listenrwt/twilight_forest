using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound_destroysystem : MonoBehaviour {
	public float destroytime;
	void Update () {
		Destroy (gameObject, destroytime);
	}
}

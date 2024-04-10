using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class sound_manager : MonoBehaviour {
	public GameObject clicksound;

	public void clicked() {
		Instantiate (clicksound, transform.position, Quaternion.identity);
	}
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class levelsystem : MonoBehaviour {
	public static int levelrate = 1;
	public Button level2;
	public int maxlevel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		switch (levelrate) {
		case 1:
			level2.interactable = false;
			break;
		case 2:
			level2.interactable = true;
			break;
		}
		if (levelrate >= maxlevel) {
			levelrate = maxlevel;
		}
	}
}

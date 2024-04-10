using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taretfollowtomouse : MonoBehaviour {
	public Texture2D texture;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnGUI () {
		if (Time.timeScale > 0) {
			Rect rect = new Rect (Input.mousePosition.x - (texture.width / 2),
				           Screen.height - Input.mousePosition.y - (texture.height / 2),
				           texture.width, texture.height);
			GUI.DrawTexture (rect, texture);
		}
	}
}

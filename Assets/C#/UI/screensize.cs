using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class screensize : MonoBehaviour {
	public int width;
	public int height;
	public bool fullscreen = true;
	public Button full;
	public Button notfull;
	private bool change = false;
	void Start() {
		full.interactable = true;
		notfull.interactable = false;
	}
	public void widthsize(int newwidth) {
		width = newwidth;
	}
	public void heightsize(int newheight) {
		height = newheight;
	}
	public void isfullscreen(bool isfull) {
		fullscreen = isfull;
		if (change) {
			full.interactable = true;
			notfull.interactable = false;
			change = false;
		} else {
			full.interactable = false;
			notfull.interactable = true;
			change = true;
		}
	}
	public void changesize() {
		Screen.SetResolution (width, height, fullscreen);
	}
}

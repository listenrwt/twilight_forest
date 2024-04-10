using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidemouse : MonoBehaviour {
	
	// Use this for initialization
	public void hide(bool nothide){
		Cursor.visible = nothide;
	}
}

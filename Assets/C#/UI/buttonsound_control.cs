using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class buttonsound_control : MonoBehaviour , IPointerEnterHandler {
	public GameObject buttonsound;
	public void OnPointerEnter(PointerEventData p) {
		Instantiate (buttonsound, transform.position, Quaternion.identity);
	
	}

}

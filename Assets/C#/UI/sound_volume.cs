using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class sound_volume : MonoBehaviour {
	public Slider volumecontrol;
	// Update is called once per frame
	void Start() {
		volumecontrol.value = AudioListener.volume;
	}
	public void OnValueChanged() {
		AudioListener.volume = volumecontrol.value;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Nagahealth_UI : MonoBehaviour {
	private float maxhealth;
	private float health;

	// Use this for initialization
	void Start () {
		maxhealth = 40;
	}
	
	// Update is called once per frame
	void Update () {
		health = Naga_health.Nagahealth;
		this.transform.localPosition = new Vector3 (-244 + 225 * (health / maxhealth), 0f, 0f);

	}
}

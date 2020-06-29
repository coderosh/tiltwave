using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	GameObject player;
	//float colorValue;

	// Use this for initialization
	void Start () {
		player  = GameObject.Find("Player");

	//	colorValue = Random.Range(0f, 100f) / 100f;
		// this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.HSVToRGB(colorValue, 0.7f, 0.9f);
		// this.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.HSVToRGB(colorValue, 0.7f, 0.9f);
	}
	
	// Update is called once per frame
	void Update () {
		if((player.transform.position.y - this.transform.position.y) > 20){
			Destroy(this.gameObject);
		}
	}
}

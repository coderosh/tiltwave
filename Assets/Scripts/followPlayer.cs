using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {

	public float speed;
	public GameObject target;
	public float vertical;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(target != null){
			Vector2 targetPos = target.transform.position;
			targetPos.x = 0;
			targetPos.y += vertical;
			this.transform.position = Vector2.Lerp(this.transform.position, targetPos, speed);
		}
	}
}

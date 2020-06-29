using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	float Yspeed = 5;
	public float Xspeed;
	Vector3 tempL;
	bool start = false;
	public GameObject gameOverPanel;
	float colorValue;
	public GameObject deadEffect;
	public GameObject startPanel;
	public AudioSource boomAudio;

	[HideInInspector]
	public int coin;
	[HideInInspector]
	public int score;
	int changeGap;
	public CameraShake camerashake;
	public bool showAds = false;
	int countWait;

	// Use this for initialization
	void Start () {
		coin = 0;
		score = 0;
		colorValue = Random.Range(0f, 100f) / 100f;
		ChangeBackgroundColor();
	}
	
	void Update(){
		if(start == false){
			CheckStartReady();
			return;
		}
		if(transform.position.x >= 2.9f){
			tempL = transform.position;
			tempL.x = 2.9f;
			transform.position = tempL;
		}else if(transform.position.x <= -2.9f){
			tempL = transform.position;
			tempL.x = -2.9f;
			transform.position = tempL;
		}
	}

	void FixedUpdate () {
		if(start == false){
			return;
		}
		AccelerometerInput();
		transform.Translate(Vector3.up * Yspeed * Time.deltaTime);
	}

	void AccelerometerInput(){
		float temp = Input.acceleration.x;
		//float temp = Input.GetAxis("Horizontal");
		transform.Translate(temp * Xspeed * Time.deltaTime, 0, 0);
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Obstacle"){
			countWait = PlayerPrefs.GetInt("AW", 0);
			countWait++;
			PlayerPrefs.SetInt("AW", countWait);
			gameOverPanel.SetActive(true);
			Xspeed = 0f;
			Yspeed = 0f;
			StartCoroutine(camerashake.Shake(.15f, .2f));
			gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
			Destroy(gameObject.transform.GetComponent<TrailRenderer>());
			Destroy(Instantiate(deadEffect, transform.position, Quaternion.identity), 2f);
			boomAudio.Play();
			checkAdsWait();
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name == "Coin"){
			score++;
			triggerCheck();
			if(changeGap == 3){
				ChangeBackgroundColor();
			}
			changeGap++;
		}
	}

	void CheckStartReady(){
		if(Input.GetMouseButtonDown(0)){
			start = true;
			startPanel.SetActive(false);
		}
	}

	void triggerCheck(){
		if(score > 0){
			if(Yspeed >= 7f){
				Yspeed =7f; 
			}else{
				Yspeed += (score * Time.deltaTime);
				Xspeed += (score/20 * Time.deltaTime);
			}
		}
	}

	void ChangeBackgroundColor(){
		Camera.main.backgroundColor = Color.HSVToRGB(colorValue, 0.5f, 0.7f);
		colorValue += 0.1f;
		if(colorValue >= 1f){
			colorValue = 0f;
		}
		changeGap = 0;
	}

	public void checkAdsWait(){
		if(PlayerPrefs.GetInt("AW", 0) >= 4){
			showAds = false;
			PlayerPrefs.SetInt("AW", 0);
		}else if(PlayerPrefs.GetInt("AW", 0) == 3){
			showAds = true;
			PlayerPrefs.SetInt("AW", 0);
		}else if(PlayerPrefs.GetInt("AW",0) == 0 || PlayerPrefs.GetInt("AW", 0) == 1 || PlayerPrefs.GetInt("AW", 0) == 2){
			showAds = false;
		}
	}
}

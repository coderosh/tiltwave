using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject[] Obstacles;
	public GameObject player;
	public AudioSource caveTheme;
	Vector2 lastObstacle;
	int rand;
	player playerScript;
	public Text screenScore;
	public Text panelScore;
	public Text highScore;

	// Use this for initialization
	void Start () {
		lastObstacle = Obstacles[1].transform.position;
		Instantiate(Obstacles[1]);
		playerScript = player.GetComponent<player>();
		caveTheme.Play();
		highScore.text = PlayerPrefs.GetInt("BS", 0).ToString();
	}
	
	void Update () {
		SpawnObstacle();
		SetScore();
	}

	void SpawnObstacle(){
		if((lastObstacle.y - player.transform.position.y) <= 40){
			lastObstacle.y +=5;
			rand = Random.Range(0, Obstacles.Length);
			Instantiate(Obstacles[rand], new Vector2(Obstacles[rand].transform.position.x , lastObstacle.y) , Obstacles[rand].transform.rotation);
		}
	}

	void SetScore(){
		int score = playerScript.score;
		screenScore.text = score.ToString();
		panelScore.text = score.ToString();

		if(score > PlayerPrefs.GetInt("BS", 0)){
			PlayerPrefs.SetInt("BS", score);
		}

		highScore.text = PlayerPrefs.GetInt("BS", 0).ToString();
	}

	public void Restart(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}

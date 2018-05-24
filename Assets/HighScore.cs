using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScore : MonoBehaviour {
	private Text score;

	// Use this for initialization
	void Start () {
		score = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerMovement.gameOver == true) {
			if (PlayerPrefs.HasKey ("Highscore")) {
				if (PlayerPrefs.GetFloat ("Highscore") < PlayerMovement.speed) {
					PlayerPrefs.SetFloat ("Highscore", PlayerMovement.speed);
				}	
			} else {
				PlayerPrefs.SetFloat ("Highscore", PlayerMovement.speed);
			}
			score.text = PlayerPrefs.GetFloat ("Highscore").ToString ("F1") + "";
		}
	}
}

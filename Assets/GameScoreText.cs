using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class GameScoreText : MonoBehaviour {
	private Text score;
	// Use this for initialization
	void Start () {
		score = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		Color tmp = score.color;
		if (InfoButton.infoScreen == false) {
			if (StartButton.gameOn == true && PlayerMovement.gameOver == false)
				tmp.a += 0.015f;
			if (StartButton.gameOn == true && PlayerMovement.gameOver == true && RepeatButton.replay == false) {
				score.fontSize += 2;
				score.transform.DOMove (new Vector3 (Screen.width / 2, Screen.height / 1.5f, 0), 1);
			}
			if (StartButton.gameOn == true && PlayerMovement.gameOver == true && RepeatButton.replay == true) {
				score.transform.DOMove (new Vector3 (Screen.width * 2, Screen.height / 1.5f, 0), 1);
			}
			
			if (score.fontSize >= 200)
				score.fontSize = 200;
			if (tmp.a >= 1)
				tmp.a = 1;
			if (tmp.a <= 0)
				tmp.a = 0;
		} else {
			transform.DOMove (new Vector3 (-Screen.width, this.gameObject.transform.position.y, 0), 2);
		}

		score.color = tmp;
			
	}
}

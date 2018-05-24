using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class EndScoreMove : MonoBehaviour {
	public float xOn;
	public float yOn;
	public float xOff;
	public float yOff;
	public float moveTimeOn;
	public float moveTimeOff;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (InfoButton.infoScreen == false) {
			if (PlayerMovement.gameOver == true && RepeatButton.replay == false)
				transform.DOMove (new Vector3 (Screen.width / xOn, Screen.height / yOn, 0), moveTimeOn);
		
			if (PlayerMovement.gameOver == true && RepeatButton.replay == true){
				transform.DOMove (new Vector3 (Screen.width / xOff, Screen.height / yOff, 0), moveTimeOff);
				if (transform.position.x <= Screen.width * -0.5f)
				SceneManager.LoadScene ("Game");
			}
		} else {
			transform.DOMove (new Vector3 (-Screen.width, this.gameObject.transform.position.y, 0), 2);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EndGameButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerMovement.gameOver == false && RepeatButton.replay == false && StartButton.gameOn == true && PlayerMovement.lastposY >= 5)
			transform.DOMove (new Vector3(Screen.width/1.1f, Screen.height/1.05f, 0), 1);
		if (PlayerMovement.gameOver == true)
			transform.DOMove (new Vector3(Screen.width/1.1f, Screen.height*1.2f, 0), 1);
	}
	public void OnTap(){
		PlayerMovement.gameOver = true;

	}
}

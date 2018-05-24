using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AvgSpeedText : MonoBehaviour {
	private Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		Color tmp = text.color;
		if (tmp.a >= 1)
			tmp.a = 1;
		if (tmp.a <= 0)
			tmp.a = 0;
		if (StartButton.gameOn == true && PlayerMovement.gameOver == false && PlayerMovement.lastposY <= 5)
			tmp.a += 0.015f;
		else
			tmp.a -= 0.015f;
		text.color = tmp;
		
	}
}

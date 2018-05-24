using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FinishScore : MonoBehaviour {
	private Text score;
	// Use this for initialization
	void Start () {
		score = GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {
		Color tmp = score.color;
		if (PlayerMovement.gameOver == true)
			tmp.a += 0.015f;
		else
			tmp.a -= 0.03f;

		if (tmp.a >= 1)
			tmp.a = 1;
		if (tmp.a <= 0)
			tmp.a = 0;

		score.color = tmp;

	}
}

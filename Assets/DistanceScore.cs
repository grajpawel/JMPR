using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DistanceScore : MonoBehaviour {
	private Text score;
	public float alphaFadeIn;
	public float alphaFadeOut;
	// Use this for initialization
	void Start () {
		score = GetComponent<Text> ();

	}
	
	// Update is called once per frame
	void Update () {
		Color tmp = score.color;

		if (StartButton.gameOn == true && RepeatButton.replay == false)
			tmp.a += alphaFadeIn;
		if (RepeatButton.replay == true)
			tmp.a -= alphaFadeOut;
		if (tmp.a >= 1)
			tmp.a = 1;
		if (tmp.a <= 0)
			tmp.a = 0;
		score.color = tmp;
	}
}

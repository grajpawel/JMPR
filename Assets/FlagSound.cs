using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagSound : MonoBehaviour {
	public AudioSource flag;
	// Use this for initialization
	void Start () {
		flag.volume = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (StartButton.gameOn == true)
			flag.volume -= 0.01f;
		if (StartButton.gameOn == false)
			flag.volume += 0.01f;

		if (flag.volume >= 1f)
			flag.volume = 1f;
		if (flag.volume <= 0)
			flag.volume = 0;
			
	}
}

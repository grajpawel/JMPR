using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {
	public static bool gameOn;
	private int soundId;

	// Use this for initialization
	void Start () {
		soundId = AudioCenter.loadSound ("whosh");
		gameOn = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnTap(){
		if (PlayerPrefs.GetInt ("Sound") == 1)			
		AudioCenter.playSound (soundId);
		gameOn = true;
	}
}

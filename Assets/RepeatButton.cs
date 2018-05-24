using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RepeatButton : MonoBehaviour {
	private int soundId;

	public static bool replay;
	// Use this for initialization
	void Start () {
		soundId = AudioCenter.loadSound ("whosh");

		replay = false;

	}
	
	// Update is called once per frame
	void Update () {
		
				//if (transform.position.x <= Screen.width * -0.1f)
					//SceneManager.LoadScene ("Game");
		
			
	}
	public void OnTap(){
		if (PlayerPrefs.GetInt ("Sound") == 1)
			AudioCenter.playSound (soundId);

		replay = true;
	}
}

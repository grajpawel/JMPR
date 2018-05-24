using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class InfoButton : MonoBehaviour {
	private int soundId;
	public static bool infoScreen;
	private bool hasChanged;
	private float timer;
	// Use this for initialization
	void Start () {
		soundId = AudioCenter.loadSound ("whosh");

		timer = 0;
		hasChanged = false;
		infoScreen = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (hasChanged == true) {
			timer += Time.deltaTime;
			if (timer >= 0.1f)
				hasChanged = false;
		
		}
			
		if (PlayerMovement.gameOver == true && RepeatButton.replay == false)
			transform.DOMove (new Vector3(Screen.width/1.1f, Screen.height/1.05f, 0), 1);
		if (PlayerMovement.gameOver == true && RepeatButton.replay == true)
			transform.DOMove (new Vector3(Screen.width/1.1f, Screen.height*1.2f, 0), 1);
			
	}
	public void OnTap(){
		if (PlayerMovement.gameOver == true){
		if (PlayerPrefs.GetInt ("Sound") == 1)
			AudioCenter.playSound (soundId);
		if (infoScreen == false) {
			if (hasChanged == false) {
				timer = 0;
				infoScreen = true;
				hasChanged = true;
			}
		}
		if (infoScreen == true) {
				if (hasChanged == false) {
					timer = 0;
					infoScreen = false;
					hasChanged = true;
				}
			}
		}

	}
}

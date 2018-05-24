using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class SoundButton : MonoBehaviour {
	private Button button;
	public Sprite buttonOn;
	public Sprite buttonOff;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("Sound") == 1)
			AudioListener.volume = 1f;
		if (PlayerPrefs.GetInt ("Sound") == 0)
			AudioListener.volume = 0;
		
		button = GetComponent<Button> ();
		if (PlayerPrefs.HasKey ("Sound")) {
		}
		else {
			PlayerPrefs.SetInt("Sound", 1);

		}

	}

	// Update is called once per frame
	void Update () {
		if (StartButton.gameOn == true)
			transform.DOMove(new Vector3 (Screen.width* -0.2f, Screen.height / 1.05f, 0), 1);
		else
			transform.DOMove(new Vector3 (Screen.width/ 14, Screen.height / 1.05f, 0), 2.5f);

		if (PlayerPrefs.GetInt ("Sound") == 1) {
			button.image.sprite = buttonOn;
			AudioListener.volume += 0.01f;
			if (AudioListener.volume >= 1f)
				AudioListener.volume = 1f;
		}


		if (PlayerPrefs.GetInt ("Sound") == 0) {
			button.image.sprite = buttonOff;
			AudioListener.volume -= 0.01f;
			if (AudioListener.volume <= 0)
				AudioListener.volume = 0;
		}


	} public void OnTap(){


		if (PlayerPrefs.GetInt ("Sound") == 1) {
			PlayerPrefs.SetInt ("Sound", 0);

		}else {
			PlayerPrefs.SetInt("Sound", 1);

		}
	}
}


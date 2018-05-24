using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class StartInfoButton : MonoBehaviour {
	public static bool startInfo;
	private float timer;
	private bool hasChanged;
	// Use this for initialization
	void Start () {
		transform.DOMove (new Vector2 (Screen.width * 0.92f, Screen.height / 1.05f), 2);
		timer = 0;
		hasChanged = false;
		startInfo = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (StartButton.gameOn == true)
			transform.DOMove (new Vector2 (Screen.width * 1.1f, Screen.height / 1.05f), 1);
		if (hasChanged == true) {
			timer += Time.deltaTime;
			if (timer >= 0.5f)
				hasChanged = false;

		}
	}
	public void OnTap(){
		if (startInfo == false) {
			if (hasChanged == false) {
				timer = 0;
				startInfo = true;
				hasChanged = true;
			}
		}
		if (startInfo == true) {
			if (hasChanged == false) {
				timer = 0;
				startInfo = false;
				hasChanged = true;
			}
		}
		
	}
		
}

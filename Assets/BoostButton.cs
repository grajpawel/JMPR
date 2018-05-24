using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class BoostButton : MonoBehaviour {
	public Text CoinText;
	private float timer;
	private float startY;
	private bool show;
	private Vector2 startPos;
	// Use this for initialization
	void Start () {
		startPos = transform.position;
		show = false;
		startY = CoinText.transform.position.y;
		if (PlayerPrefs.HasKey ("HasTouched")) {			
		} else {
			PlayerPrefs.SetInt ("HasTouched", 0);
		}
		if (PlayerPrefs.HasKey ("Coins")) {			
		} else {
			PlayerPrefs.SetInt ("Coins", 0);
		}
		if (PlayerPrefs.HasKey ("Boost")) {			
		} else {
			PlayerPrefs.SetInt ("Boost", 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (StartButton.gameOn == false) {
			if (PlayerPrefs.GetInt ("Boost") == 0) {
				transform.position = new Vector2 (transform.position.x - 0.6f, transform.position.y + 0.6f);
				if (transform.position.y >= Screen.height * 1.05f)
					transform.position = startPos;
			}
		} else
			transform.DOMove (new Vector2 (Screen.width / 2, Screen.height * 1.1f), 1);
				
		if (show == true) {
			timer += Time.deltaTime;
			if (timer >= 2f) {
				timer = 0;
				CoinText.transform.DOMove (new Vector2 (Screen.width/2, startY),1f);
				show = false;
			}
		}
	}
	public void OnTap(){
		PlayerPrefs.SetInt ("HasTouched", 1);

		show = true;
		CoinText.transform.DOMove(new Vector2(Screen.width/2, Screen.height * 0.85f), 1f);
		if (PlayerPrefs.GetInt ("Boost") == 0) {
			if (PlayerPrefs.GetInt ("Coins") >= 5) {
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") - 5);
				PlayerPrefs.SetInt ("Boost", 1);
				CoinText.text = "Boost activated!";
				transform.DOMove (new Vector2 (Screen.width / 2, Screen.height * 1.1f), 1);
		
			} else {
				if (5 - PlayerPrefs.GetInt ("Coins") == 1)
					CoinText.text = "You need " + (5 - PlayerPrefs.GetInt ("Coins")).ToString () + " more coin";
				else
				CoinText.text = "You need " + (5 - PlayerPrefs.GetInt ("Coins")).ToString () + " more coins";
			}
		} else {
			CoinText.text = "Boost activated!";
		}

	}
}

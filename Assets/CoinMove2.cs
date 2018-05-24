using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CoinMove2 : MonoBehaviour {
	private int soundId;

	private float speed;
	private float side;
	private float pos;
	private bool hasMoved;
	// Use this for initialization
	void Start () {
		soundId = AudioCenter.loadSound ("pickup");
		hasMoved = false;
		Teleport ();

	}

	// Update is called once per frame
	void Update () {
		if (PlayerMovement.gameOver == false) {
			if (GameObject.Find ("Player").transform.position.y >= 50) {
				pos += speed;
				if (transform.position.y >= GameObject.Find ("Player").transform.position.y + 10)
					Teleport ();

				transform.position = new Vector2 (side, GameObject.Find ("Player").transform.position.y + pos);
			}
		} else {
			if (hasMoved == false) {
				transform.DOMove (new Vector2 (-5, transform.position.y), 2);
				hasMoved = true;
			}
		}		
	}
	public void Teleport(){
		side = Random.Range (-1.30f, 1.30f);
		speed = Random.Range (0.03f, 0.07f);
		pos = Random.Range (-100, -60);
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name == "Player") {
			if (PlayerPrefs.GetInt ("Sound") == 1)				
				AudioCenter.playSound (soundId);
			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") + 1);
			Teleport ();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour {
	public float fallspeed;
	private int soundId;
	// Use this for initialization
	void Start () {
		soundId = AudioCenter.loadSound ("pickup");

		Teleport ();
	}
	
	// Update is called once per frame
	void Update () {

		fallspeed = GameObject.Find ("Player").GetComponent<Rigidbody2D> ().velocity.y / 100;
		if (GameObject.Find ("Player").GetComponent<Rigidbody2D> ().velocity.y > 0.5f) {
			transform.position = new Vector2 (transform.position.x, transform.position.y + fallspeed);
			if (transform.position.y - GameObject.Find ("Player").transform.position.y <= -8)
				Teleport ();
		}
	}
	public void Teleport(){
		transform.position = new Vector2 (Random.Range (-1.3f, 1.3f), GameObject.Find ("Player").transform.position.y + Random.Range (350, 600));
		//fallspeed = Random.Range (0.06f, 0.12f);
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

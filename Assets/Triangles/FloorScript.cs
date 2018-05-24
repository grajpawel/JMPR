using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour {
	private int soundId;
	private float timer;
	// Use this for initialization
	void Start () {
		soundId = AudioCenter.loadSound ("landing");

	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (PlayerMovement.lastposY >= 4)
			Destroy (gameObject);
	}
	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.name == "Player" && PlayerPrefs.GetInt ("Sound") == 1 && timer >= 0.2f)
			AudioCenter.playSound (soundId);
	}
			
}

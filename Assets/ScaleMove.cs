using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ScaleMove : MonoBehaviour {
	private int soundId;

	private float speed;
	private float side;
	private float pos;

	// Use this for initialization
	void Start () {
		soundId = AudioCenter.loadSound ("pickup");

		Teleport ();

	}

	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Player").transform.position.y >= 10) {
			pos += speed;
			if (transform.position.y >= GameObject.Find ("Player").transform.position.y + 10)
				Teleport ();

			transform.position = new Vector2 (side, GameObject.Find ("Player").transform.position.y + pos);


		}
		if (RepeatButton.replay == true){
			Color tmp = GetComponent<SpriteRenderer> ().color;
			tmp.a -= 0.05f;
			if (tmp.a <= 0)
				Destroy (gameObject);
			GetComponent<SpriteRenderer> ().color = tmp;
		}

	}
	public void Teleport(){
		side = Random.Range (-1.30f, 1.30f);
		speed = Random.Range (0.01f, 0.15f);
		pos = Random.Range (-60, -40);
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name == "Player") {
			if (PlayerPrefs.GetInt ("Sound") == 1)				
				AudioCenter.playSound (soundId);
			GameObject.Find ("Player").transform.DOScale (new Vector2 (0.05f, 0.05f), 1);
			Teleport ();
		}
	}
}

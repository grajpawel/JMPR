using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CloudMove : MonoBehaviour {
	public  float edge;
	private float speed;
	private float startX;
	private float startY;
	private float scale;
	public bool noScale;
	// Use this for initialization
	void Start () {
		if (noScale == false)
			scale = Random.Range (0.15f, 0.25f);
		else
			scale = 0.15f;
		transform.localScale = new Vector2 (scale, scale);
		startX = transform.position.x;
		startY = transform.position.y;
		speed = Random.Range (300, 400);
	}
	
	// Update is called once per frame
	void Update () {
		if (RepeatButton.replay == false) {
			transform.Translate (Vector2.left / speed);
			if (transform.position.x <= GameObject.Find ("Main Camera").transform.position.x - edge) {
				transform.localScale = new Vector2 (scale, scale);
				transform.position = new Vector2 (GameObject.Find ("Main Camera").transform.position.x + edge, transform.position.y);
			}
		} else
			transform.DOMove (new Vector3 (startX, GameObject.Find ("Main Camera").transform.position.y + startY - 24.59f, 0), 0.25f);
	}
}

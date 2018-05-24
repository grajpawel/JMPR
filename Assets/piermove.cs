using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 
public class piermove : MonoBehaviour {
	private Vector2 pos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		pos = transform.position;
		if (StartButton.gameOn == true && PlayerMovement.gameOver == false) {
			if (GameObject.Find ("Player").GetComponent<Rigidbody2D> ().velocity.y > 0)
				pos.y -= 0.001f;
		}
		if (RepeatButton.replay == true)
			transform.DOMove (new Vector3 (GameObject.Find ("Main Camera").transform.position.x, GameObject.Find ("Main Camera").transform.position.y - 4.47f, 0), 0.5f);
		transform.position = pos;
	}
}

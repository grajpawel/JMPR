using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EnemyMove : MonoBehaviour {
	private float speed;
	private float side;
	private float pos;
	private bool hasMoved;
	private bool up;
	// Use this for initialization
	void Start () {
		hasMoved = false;
		up = false;
		Teleport ();

	}
	
	// Update is called once per frame
	void Update () {
		Color tmp = GetComponent<SpriteRenderer> ().color;
		if (PlayerMovement.gameOver == false) {
			if (up == true)
				tmp.a += 0.01f;
			else
				tmp.a -= 0.01f;
			if (tmp.a >= 1)
				up = false;
			if (tmp.a <= 0.4f)
				up = true;
			
			if (GameObject.Find ("Player").transform.position.y >= 80) {
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
		


		if (RepeatButton.replay == true) {

			tmp.a -= 0.05f;
			if (tmp.a <= 0)
				Destroy (gameObject);
			
		}
	
		GetComponent<SpriteRenderer> ().color = tmp;
	}
	public void Teleport(){
		side = Random.Range (-1.30f, 1.30f);
		speed = Random.Range (0.03f, 0.07f);
		pos = Random.Range (-20, -10);
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name == "Player") {
			
			GameObject.Find ("Player").GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			PlayerMovement.gameOver = true;
		}
	}

}

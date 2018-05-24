using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class GameCameraMove : MonoBehaviour {
	private float moveTime;

	private bool hasMoved;
	// Use this for initialization
	void Start () {
				moveTime = 0.4f;
		//transform.position = new Vector2 (0, 27.46f);

	}
	
	// Update is called once per frame
	void Update () {
		if (moveTime >= 1)
			moveTime = 1;
		if (moveTime <= 0.01f)
			moveTime = 0.01f;
		if (StartInfoButton.startInfo == true) {
			hasMoved = false;
			transform.DOMove (new Vector3 (-6, 17.46f, -10), 2);
		}
		else {
			if (hasMoved == false) {
				transform.DOMove (new Vector3 (0, 17.46f, -10), 2);
				hasMoved = true;
			}
		}


		//Debug.Log (GameObject.Find ("Player").transform.position.y - transform.position.y);
		//Debug.Log (GameObject.Find ("Player").GetComponent<Rigidbody2D> ().velocity.y);
		//Debug.Log (GameObject.Find ("Player").GetComponent<Rigidbody2D> ().velocity.y / 18);
		if (Input.GetKey (KeyCode.Escape))
			Application.Quit ();
		if (GameObject.Find ("Player").GetComponent<Rigidbody2D> ().velocity.y <= 0 && GameObject.Find ("Player").transform.position.y < 1)
			moveTime = 1;
		else {			
			//moveTime = 0.5f;
			if (GameObject.Find ("Player").transform.position.y - transform.position.y >= 3)
				moveTime -= 0.005f;
			
			if (GameObject.Find ("Player").transform.position.y - transform.position.y <= -4)
				moveTime += 0.01f;
		}
			
		if (StartButton.gameOn == true && PlayerMovement.gameOver == false)
			transform.DOMove (new Vector3 (GameObject.Find ("Player").transform.position.x, GameObject.Find ("Player").transform.position.y + 3.5f, -10), moveTime);
		
				
		if (PlayerMovement.gameOver == true)
			transform.DOMove (new Vector3 (0, transform.position.y, -10), 1);
	}

			
}

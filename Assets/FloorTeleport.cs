using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FloorTeleport : MonoBehaviour {
	public float posX;
	public float tpposX;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerMovement.gameOver == true)
			transform.DOMove (new Vector3 (tpposX, transform.position.y, 0), 2);
		
		if (GameObject.Find ("Main Camera").transform.position.y <= 8 && PlayerMovement.gameOver == false)
			transform.position = new Vector2 (posX, transform.position.y);
			
		if (gameObject.transform.position.y - GameObject.Find ("Player").transform.position.y <= -10) {
			if (gameObject.name == "LeftFloor")
				transform.position = new Vector2 (posX, transform.position.y + 28);
			if (gameObject.name == "RightFloor")
				transform.position = new Vector2 (posX, transform.position.y + 28);
		}
	}
}

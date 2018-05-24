using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraY : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (StartButton.gameOn == true && PlayerMovement.gameOver == false)
			transform.position =  new Vector3(transform.position.x, GameObject.Find ("Player").transform.position.y + 4, -10);
	}
}

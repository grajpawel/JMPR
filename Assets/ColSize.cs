using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColSize : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector2 (transform.position.x, GameObject.Find ("Player").transform.position.y + 4);
	}
}

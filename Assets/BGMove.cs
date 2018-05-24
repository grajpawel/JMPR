using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BGMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position = new Vector2 (GameObject.Find ("Main Camera").transform.position.x, GameObject.Find ("Main Camera").transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		transform.DOMove (new Vector3 (GameObject.Find ("Main Camera").transform.position.x, GameObject.Find ("Main Camera").transform.position.y, 0), 0.05f);

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BgFollow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.DOMove (new Vector3 (GameObject.Find ("Main Camera").transform.position.x, GameObject.Find ("Main Camera").transform.position.y, 0), 0.2f);

	}
}

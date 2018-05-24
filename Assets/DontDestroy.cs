using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {
	private static DontDestroy instance = null;
	public static  DontDestroy Instance {
		get { return instance; }
	}
	// Use this for initialization
	void Awake(){
		if (instance != null && instance != this) {
			Destroy (this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad (this.gameObject);
	}
	// Use this for initialization
	void Start () {
		

	}

	// Update is called once per frame
	void Update () {

	}
}

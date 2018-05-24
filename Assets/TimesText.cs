using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TimesText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (InfoButton.infoScreen == true)
			transform.DOMove (new Vector3 (Screen.width/2, this.gameObject.transform.position.y, 0), 1f);
		if (InfoButton.infoScreen == false)
			transform.DOMove (new Vector3 (Screen.width * 2, this.gameObject.transform.position.y, 0), 1.5f);

	}
}

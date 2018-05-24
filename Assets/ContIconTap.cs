using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ContIconTap : MonoBehaviour {
	private string startMode;
	private bool visible = true;
	// Use this for initialization
	void Start () {
		startMode = "phone";
	}

	// Update is called once per frame
	void Update () {
		Color tmp = GetComponent<Image> ().color;	

		if (PlayerPrefs.GetString ("InputMode") == startMode) {
			if (visible == false) {
				tmp.a = 1;
				visible = true;
			}
			tmp.a -= 0.01f;
		} else {
			visible = false;
			tmp.a = 0;
		}

		GetComponent<Image> ().color = tmp;	
	}
}

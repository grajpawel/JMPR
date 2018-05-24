using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TapFade : MonoBehaviour {
	private bool loweralpha;
	public float alphaSpeed;
	// Use this for initialization
	void Start () {
		loweralpha = false;
		if (PlayerPrefs.GetInt ("HasTouched") == 1)
			Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		Color tmp = GetComponent<Image> ().color;
		if (PlayerPrefs.GetInt ("HasTouched") == 0) {
			if (loweralpha == true)
				tmp.a -= alphaSpeed;
			
			if (tmp.a <= 0.1f)
				loweralpha = false;
			
			if (loweralpha == false)
				tmp.a += alphaSpeed;

			if (tmp.a >= 0.6f)
				loweralpha = true;
		} else {
			tmp.a -= alphaSpeed;
		}
		GetComponent<Image> ().color = tmp;
	}
}

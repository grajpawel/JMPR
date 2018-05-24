// Written by Chris Bellini and published as public domain to http://untitledgam.es
// You may freely use, license or sell any portion of this code for any legal purpose
// All code is presented as is and without warranty or liability and is used at your own risk

using System;
using System.IO;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
	private string folder;

	[SerializeField]
	private string inputButton = "Screenshot";

	private bool inputButtonIsMapped;

	[SerializeField]
	private KeyCode key = KeyCode.F12;

	[SerializeField]
	[Range(1, 8)]
	private int superSize = 1;

	public KeyCode Key { get { return this.key; } set { this.key = value; } }

	public int SuperSize { get { return this.superSize; } set { this.superSize = Mathf.Clamp(value, 1, 4); } }

	private static string GetFilename()
	{
		return string.Format("{0}.png", DateTime.Now.ToBinary());
	}

	public void Capture()
	{
		string filepath = Path.Combine(this.folder, Screenshot.GetFilename());
		ScreenCapture.CaptureScreenshot(filepath, this.SuperSize);
		Debug.Log(string.Format("[<color=blue>Screenshot</color>] Screenshot captured.\n<color=grey>{0}</color>", filepath));
	}

	private void Awake()
	{
		this.folder = Application.dataPath;
		this.folder = this.folder.Substring(0, this.folder.Length - 7);
		this.folder = Path.Combine(this.folder, "Screenshots");
		if (!Directory.Exists(this.folder))
		{
			Directory.CreateDirectory(this.folder);
		}

		this.inputButtonIsMapped = this.IsInputButtonMapped();
	}

	private bool IsInputButtonMapped()
	{
		if (string.IsNullOrEmpty(this.inputButton))
		{
			return false;
		}

		try
		{
			Input.GetButton(this.inputButton);
			return true;
		}
		catch
		{
			return false;
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(this.Key) || (this.inputButtonIsMapped && Input.GetButton(this.inputButton)))
		{
			this.Capture();
		}
	}
}
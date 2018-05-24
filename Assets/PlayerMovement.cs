using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;

using UnityEngine.SocialPlatforms;
public class PlayerMovement : MonoBehaviour {
	private Rigidbody2D rb;
	private int soundId;
	private float moveSpeed = 15;
	private Vector2 vel;
	private float AxZ;
	private int jumpSound;
	private bool hasLanded;
	private string jumpName;
	private string colName;
	private bool hasJumped;
	public static bool gameOver;
	public  Text velText;
	public  Text speedText;
	public  Text time50Text;
	public  Text time100Text;
	public  Text time250Text;
	public  Text time500Text;
	public  Text time1000Text;
	public  Text time2500Text;
	public  Text time5000Text;
	public  Text time10000Text;
	private float velTimer;
	private bool hasBoosted;
	private float milisecs;
	private int mins;

	public static float lastposY;
	private float speedTimer;
	private bool hasSet50;
	private bool hasSet100;
	private bool hasSet250;
	private bool hasSet500;
	private bool hasSet1000;
	private bool hasSet2500;
	private bool hasSet5000;
	private bool hasSet10000;
	private bool hasSet25000;
	private bool hasSet50000;
	private bool hasSet100000;
	private bool hasPlayed;
	public static float speed;
	// Use this for initialization
	void Start () {
		PlayGamesPlatform.Activate ();
		Social.localUser.Authenticate ((bool success) => {
		});
		milisecs = 0;
		mins = 0;
		//PlayerPrefs.DeleteAll();
		moveSpeed = 15;
		hasLanded = true;
		hasJumped = false;
		hasBoosted = false;
		soundId = AudioCenter.loadSound ("whosh");
		hasPlayed = false;
		velTimer = 0;
		hasSet50 = false;
		hasSet100 = false;
		hasSet250 = false;
		hasSet500 = false;
		hasSet1000 = false;
		hasSet2500 = false;
		hasSet5000 = false;
		hasSet10000 = false;
		hasSet25000 = false;
		hasSet50000 = false;
		hasSet100000 = false;

		speedTimer = 0;
		lastposY = 0;
		gameOver = false;
		jumpSound = AudioCenter.loadSound ("mouse2");

		rb = GetComponent<Rigidbody2D> ();




		}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (speedTimer);
		if (lastposY / speedTimer >= 0)
			speed = lastposY / speedTimer;
		else
			speed = 0;
		//Debug.Log (rb.velocity.y);
		if (PlayerPrefs.GetInt ("Sound") == 1){			
		if (gameOver == true) {
				if (hasPlayed == false) {
					AudioCenter.playSound (soundId);
					hasPlayed = true;
				}
			}
		}

		speedText.text = lastposY.ToString ("F0") +" m";
		velText.text = speed.ToString ("F1") + "";
		if (transform.position.y >= 0.64f && gameOver == false) {
			speedTimer += Time.deltaTime;
			milisecs += Time.deltaTime;

		}
		if (milisecs >= 60) {
			milisecs = 0;
			mins++;
		}

		if (lastposY >= 50) {
			if (hasSet50 == false) {
				Social.ReportProgress ("CgkIq5i9j7ACEAIQAQ", 100.0f, (bool success) => {
				});
				if (speedTimer >= 60)
					time50Text.text = "50m   " + mins.ToString () + ":" + milisecs.ToString ("F2") + "s";
				
				else
					time50Text.text = "50m   " + speedTimer.ToString ("F2") + "s";
				hasSet50 = true;
			}
		} else {
			time50Text.text = "";
		}

		if (lastposY >= 100) {
			if (hasSet100 == false) {
				Social.ReportScore ((long)(speedTimer * 1000), "CgkIq5i9j7ACEAIQFQ", (bool success) => {

				});
				Social.ReportProgress ("CgkIq5i9j7ACEAIQAg", 100.0f, (bool success) => {
				});
				if (speedTimer >= 60)
					time100Text.text = "100m   " + mins.ToString () + ":" + milisecs.ToString ("F2") + "s";

				else
					time100Text.text = "100m   " + speedTimer.ToString ("F2") + "s";
				hasSet100 = true;
			}
		} else {
			time100Text.text = "";
		}

		if (lastposY >= 250) {
			if (hasSet250 == false) {
				Social.ReportScore ((long)(speedTimer * 1000), "CgkIq5i9j7ACEAIQCg", (bool success) => {

				});
				Social.ReportProgress ("CgkIq5i9j7ACEAIQAw", 100.0f, (bool success) => {
				});
				if (speedTimer >= 60)
					time250Text.text = "250m   " + mins.ToString () + ":" + milisecs.ToString ("F2") + "s";

				else
					time250Text.text = "250m   " + speedTimer.ToString ("F2") + "s";
				hasSet250 = true;
			}
		} else {
			time250Text.text = "";
		}


		if (lastposY >= 500) {
			if (hasSet500 == false) {
				Social.ReportScore ((long)(speedTimer * 1000), "CgkIq5i9j7ACEAIQCw", (bool success) => {

				});
				Social.ReportProgress ("CgkIq5i9j7ACEAIQBA", 100.0f, (bool success) => {
				});
				if (speedTimer >= 60)
					time500Text.text = "050m   " + mins.ToString () + ":" + milisecs.ToString ("F2") + "s";

				else
					time500Text.text = "500m   " + speedTimer.ToString ("F2") + "s";
				
				hasSet500 = true;
			}
		} else {
			time500Text.text = "";
		}


		if (lastposY >= 1000) {
			if (hasSet1000 == false) {
				Social.ReportScore ((long)(speedTimer * 1000), "CgkIq5i9j7ACEAIQDA", (bool success) => {

				});
				Social.ReportProgress ("CgkIq5i9j7ACEAIQBQ", 100.0f, (bool success) => {
				});
				if (speedTimer >= 60)
					time1000Text.text = "1000m   " + mins.ToString () + ":" + milisecs.ToString ("F2") + "s";

				else
					time1000Text.text = "1000m   " + speedTimer.ToString ("F2") + "s";
			
				hasSet1000 = true;
			}
		} else {
			time1000Text.text = "";
		}

		if (lastposY >= 2500) {
			if (hasSet2500 == false) {
				Social.ReportScore ((long)(speedTimer * 1000), "CgkIq5i9j7ACEAIQDQ", (bool success) => {

				});
				Social.ReportProgress ("CgkIq5i9j7ACEAIQBg", 100.0f, (bool success) => {
				});
				if (speedTimer >= 60)
					time2500Text.text = "2500m   " + mins.ToString () + ":" + milisecs.ToString ("F2") + "s";

				else
					time2500Text.text = "2500m   " + speedTimer.ToString ("F2") + "s";
				hasSet2500 = true;
			}
		} else {
			time2500Text.text = "";
		}

		if (lastposY >= 5000) {
			if (hasSet5000 == false) {
				Social.ReportScore ((long)(speedTimer * 1000), "CgkIq5i9j7ACEAIQDg", (bool success) => {

				});
				Social.ReportProgress ("CgkIq5i9j7ACEAIQBw", 100.0f, (bool success) => {
				});
				if (speedTimer >= 60)
					time5000Text.text = "5000m   " + mins.ToString () + ":" + milisecs.ToString ("F2") + "s";

				else
					time5000Text.text = "5000m   " + speedTimer.ToString ("F2") + "s";
				hasSet5000 = true;
			}
		} else {
			time5000Text.text = "";
		}

		if (lastposY >= 10000) {
			if (hasSet10000 == false) {
				Social.ReportScore ((long)(speedTimer * 1000), "CgkIq5i9j7ACEAIQDw", (bool success) => {

				});
				Social.ReportProgress ("CgkIq5i9j7ACEAIQCA", 100.0f, (bool success) => {
				});
				if (speedTimer >= 60)
					time10000Text.text = "10000m   " + mins.ToString () + ":" + milisecs.ToString ("F2") + "s";

				else
					time10000Text.text = "10000m   " + speedTimer.ToString ("F2") + "s";
				
				hasSet10000 = true;
			}
		} else {
			time10000Text.text = "";
		}

		if (lastposY >= 25000) {
			if (hasSet25000 == false) {
				Social.ReportScore ((long)(speedTimer * 1000), "CgkIq5i9j7ACEAIQEA", (bool success) => {

				});
				Social.ReportProgress ("CgkIq5i9j7ACEAIQCQ", 100.0f, (bool success) => {
				});


				hasSet25000 = true;
			}
		}

		if (lastposY >= 50000) {
			if (hasSet50000 == false) {
				Social.ReportScore ((long)(speedTimer * 1000), "CgkIq5i9j7ACEAIQEQ", (bool success) => {

				});
				Social.ReportProgress ("CgkIq5i9j7ACEAIQEw", 100.0f, (bool success) => {
				});


				hasSet50000 = true;
			}
		}

		if (lastposY >= 100000) {
			if (hasSet100000 == false) {
				Social.ReportScore ((long)(speedTimer * 1000), "CgkIq5i9j7ACEAIQEg", (bool success) => {

				});
				Social.ReportProgress ("CgkIq5i9j7ACEAIQFA", 100.0f, (bool success) => {
				});


				hasSet100000 = true;
			}
		}


	
			

			

		if (transform.position.y >= 3 && rb.velocity.y < -0.1f) {
			velTimer += Time.deltaTime;
			if (velTimer >= 0.5f)
				gameOver = true;
		} else
			velTimer = 0;
		if (transform.position.y - 1 > lastposY)
			lastposY = transform.position.y - 1;
		if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
			PlayerPrefs.SetString ("InputMode", "controller");
		if (Input.touchCount > 0)
			PlayerPrefs.SetString ("InputMode", "phone");
		if (StartButton.gameOn == true && gameOver == false){
			if (PlayerPrefs.GetInt ("Boost") == 1) {
				if (hasBoosted == false) {
					if (speedTimer >= 0.5f) {
						rb.AddForce (Vector2.up * 2000);
						hasBoosted = true;
						PlayerPrefs.SetInt ("Boost", 0);
					}
				}
			}
				
		
		if (PlayerPrefs.GetString ("InputMode") == "phone") {

			AxZ = Input.acceleration.x;
			
			
			if (AxZ >= 0.5f)
				AxZ = 0.5f;
			if (AxZ <= -0.5f)
				AxZ = -0.5f;
			rb.AddForce (Vector2.right * 60 * AxZ);

		}
		vel = rb.velocity;
		if (vel.x >= 5)
			vel.x = 5;

		if (vel.x <= -5)
			vel.x = -5;
		rb.velocity = vel;
		if (PlayerPrefs.GetString ("InputMode") == "controller") {
			if (Input.GetAxis("Horizontal") > 0){
				
			rb.AddForce (Vector2.right * moveSpeed);
		}
			if (Input.GetAxis("Horizontal") < 0){
				rb.AddForce (Vector2.right * -moveSpeed);
			}
		}
		if (rb.velocity.y < 0)
			hasLanded = false;
		if (rb.velocity.y == 0) {
			if (hasLanded == false) {

				hasLanded = true;

			}
		}
	
		//transform.Translate (Input.GetAxis ("Horizontal") / 10, 0, 0, Space.World);
		//transform.Translate (new Vector3 (AxZ, 0, 0), Space.World)
			if (rb.velocity.y == float.Epsilon || colName != jumpName || transform.position.y <= 0.7f) {
			if (PlayerPrefs.GetString ("InputMode") == "controller") {
				if (Input.GetButtonDown("Jump"))
					Jump ();
			}
			if (PlayerPrefs.GetString ("InputMode") == "phone") {
					for (int i = 0; i < Input.touchCount; ++i) {
						if (Input.GetTouch (i).phase == TouchPhase.Began)
							Jump ();
					}
					
				}
			}
		}
	}	

	void Jump() {
		if (PlayerPrefs.GetInt ("Sound") == 1)
		AudioCenter.playSound (jumpSound);
		hasLanded = false;
		rb.AddForce (Vector2.up * 430);

		hasJumped = true;

	}
	void OnCollisionEnter2D(Collision2D col){


		if (col.gameObject.name != "Floor")
			
				colName = col.gameObject.name;
			

		}

		

	void OnCollisionExit2D(Collision2D col){
		hasJumped = false;
		if (col.gameObject.name != "Floor")
			
			jumpName = col.gameObject.name;


	}
			
	void OnCollisionStay2D(Collision2D col){
		if (hasJumped == true) {	
			if (col.gameObject.name != "Floor")
				
			jumpName = col.gameObject.name;


		}
	}
}
	

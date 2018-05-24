using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using UnityEngine.UI;
public class VideoAd : MonoBehaviour {
	private Text adText;
	private RewardBasedVideoAd rewardBasedVideo;
	private bool hasAdded;
	private Color tmp;
	private Color buttontmp;
	// Use this for initialization
	void Start () {
		adText = GameObject.Find ("AdText").GetComponent<Text> ();
	
		tmp = GetComponent<Image> ().color;
		if (PlayerPrefs.GetInt ("HasTouched") == 0)
			tmp.a = 0;
		else
			tmp.a = 1;
		GetComponent<Image> ().color = tmp;

			
		RequestRewardBasedVideo ();
		this.rewardBasedVideo = RewardBasedVideoAd.Instance;

		// RewardBasedVideoAd is a singleton, so handlers should only be registered once.

		this.rewardBasedVideo.OnAdRewarded += this.HandleRewardBasedVideoRewarded;
		this.rewardBasedVideo.OnAdClosed += this.HandleRewardBasedVideoClosed;


	}
	
	// Update is called once per frame
	void Update () {
		tmp = GetComponent<Button> ().image.color;
		buttontmp = adText.color;
		buttontmp.a = tmp.a;
		if (PlayerPrefs.GetInt ("HasTouched") == 1)
			tmp.a += 0.01f;
		GetComponent<Button> ().image.color = tmp;
		adText.color = buttontmp;
		//rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
	}
	public void HandleRewardBasedVideoClosed(object sender, EventArgs args){
		RequestRewardBasedVideo ();
	}
	private void RequestRewardBasedVideo()
	{
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-2165871186692773/2591720043";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-2165871186692773/2591720043";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		rewardBasedVideo = RewardBasedVideoAd.Instance;

		AdRequest request = new AdRequest.Builder().Build();
		rewardBasedVideo.LoadAd(request, adUnitId);
		}

		public void OnTap(){
		hasAdded = false;
		if (rewardBasedVideo.IsLoaded ()) {
			rewardBasedVideo.Show ();
		}
	}
		public void HandleRewardBasedVideoRewarded(object sender, Reward args)
		{
		RequestRewardBasedVideo ();
		if (hasAdded == false) {
			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") + 2);
			hasAdded = true;
		}
		string type = "Coin";
		double amount = 2;
		print("User rewarded with: " + amount.ToString() + " " + type);
		}
}

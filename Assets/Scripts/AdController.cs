using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class AdController : MonoBehaviour {

	public player playerScript;

	private string store_id = "3105139";
	private string video_ad = "video";
	private string banner_ad = "BannerAd";

	// Use this for initialization
	void Start () {
		Monetization.Initialize(store_id, false);
	}
	
	// Update is called once per frame
	void Update () {
		if(playerScript.showAds == true){
			VideoAd();
			playerScript.showAds = false;
		}
	}

	public void VideoAd(){
		if(Monetization.IsReady(video_ad)){
				ShowAdPlacementContent ad = null;
				ad = Monetization.GetPlacementContent(video_ad) as ShowAdPlacementContent;

				if(ad != null){
					ad.Show();
				}
			}
	}

	public void BannerAd(){
		if(Monetization.IsReady(banner_ad)){
				ShowAdPlacementContent ad = null;
				ad = Monetization.GetPlacementContent(banner_ad) as ShowAdPlacementContent;

				if(ad != null){
					ad.Show();
				}
			}
	}
}

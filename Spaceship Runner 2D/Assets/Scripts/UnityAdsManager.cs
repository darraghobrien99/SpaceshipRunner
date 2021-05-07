using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class UnityAdsManager : MonoBehaviour, IUnityAdsListener
{

    string GooglePlay_ID = "4103763";
    bool TestMode = true;
    string rewarded_Ad_ID = "rewardedVideo";
    private string Banner_Ad_ID = "bannerAd";
    private string Interstitial_Ad_ID = "interstitialAd";
    public static UnityAdsManager Instance;
  


    // Start is called before the first frame update
    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(GooglePlay_ID, TestMode);

        Instance = this;
    }


    public void DisplayInterstitialAd()
    {
        if (Advertisement.IsReady(Interstitial_Ad_ID))
        {
            Advertisement.Show(Interstitial_Ad_ID);
        }
        
        GoogleAdMobManager.Instance.RequestInterstitial();
    }

    public void DisplayVideoAd()
    {

    }

    public void ShowRewardedVideo()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady(rewarded_Ad_ID))
        {
            
            Advertisement.Show(rewarded_Ad_ID);
        }
        GoogleAdMobManager.Instance.RequestRewardBasedVideo();

    }

    public void PlayBannerAd()
    {
        StartCoroutine(ShowBannerWhenInitialized());
    }

    IEnumerator ShowBannerWhenInitialized()
    {
        if (!Advertisement.isInitialized)
        {

            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(Banner_Ad_ID);
    }

    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string myPlacementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            Debug.LogWarning("You get a reward");
            DistanceManager.Instance.AddToScore();
            
        }
        else if (showResult == ShowResult.Skipped)
        {
            Debug.LogWarning("You DO NOT get a reward");
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady(string PlacementId)
    {
        // If the ready Ad Unit or legacy Placement is rewarded, show the ad:
        if (PlacementId == rewarded_Ad_ID)
        {
            // Optional actions to take when theAd Unit or legacy Placement becomes ready (for example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string PlacementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }

  
}

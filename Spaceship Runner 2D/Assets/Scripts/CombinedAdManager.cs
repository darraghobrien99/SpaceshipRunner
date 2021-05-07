using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CombinedAdManager : MonoBehaviour
{

    public static CombinedAdManager Instance;
    private UnityAdsManager unityAdManager;
    private GoogleAdMobManager adMobManager;
    private CombinedAdManager combinedAdManager;
    private GameObject adManager;
    // Start is called before the first frame update
    void Start()
    {
        //int randomNumber = Random.Range(1, 3);
        Instance = this;
        adManager = GameObject.FindGameObjectWithTag("Ad_Manager");
        unityAdManager = adManager.GetComponent<UnityAdsManager>();
        adMobManager = adManager.GetComponent<GoogleAdMobManager>();
        combinedAdManager = adManager.GetComponent<CombinedAdManager>();

        Debug.Log("HEYY");
        int randomNumber = Random.Range(1, 3);
        Debug.Log("Random " + randomNumber);
        if (randomNumber == 1)
        {
            adMobManager.RequestBanner();
            Debug.Log("showing ad mob");
        }
        if (randomNumber == 2)
        {
            unityAdManager.PlayBannerAd();
            Debug.Log("showing unity");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void showRandomInterstitial()
    {
        int randomNumber = Random.Range(1, 3);
        if (randomNumber == 1)
        {
            GoogleAdMobManager.Instance.RequestInterstitial();
        }

        else if (randomNumber == 2)
        {
            UnityAdsManager.Instance.DisplayInterstitialAd();
        }
    }

    public void showRandomReward()
    {
        int randomNumber = Random.Range(1, 3);
        if (randomNumber == 1)
        {
            UnityAdsManager.Instance.ShowRewardedVideo();
        }

        else if (randomNumber == 2)
        {
            GoogleAdMobManager.Instance.RequestRewardBasedVideo();
        }
    }

    public void showRandomBanner()
    {
        int random = Random.Range(1, 3);
        Debug.Log(random + " Banner");
        if (random == 1)
        {
            unityAdManager.PlayBannerAd();
            Debug.Log("showing unity reward");
        }

        else if (random == 2)
        {
            adMobManager.RequestBanner();
            Debug.Log("showing google reward");
        }
    }
}

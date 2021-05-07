using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isGamePaused;
    public int random;
    private CombinedAdManager combinedAdManager;
    private GameObject adManager;
    private UnityAdsManager unityAdManager;

    // Start is called before the first frame update
    void Start()
    {
        adManager = GameObject.FindGameObjectWithTag("Ad_Manager");
        combinedAdManager = adManager.GetComponent<CombinedAdManager>();
        unityAdManager = unityAdManager.GetComponent<UnityAdsManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TogglePause()
    {
        isGamePaused = !isGamePaused;

        if (isGamePaused)
        {
            random = Random.Range(1, 3);
            Time.timeScale = 0;
            UnityAdsManager.Instance.DisplayInterstitialAd();
        }

        else
        {
            Time.timeScale = 1;
        }
    }
}

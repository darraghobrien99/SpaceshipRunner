using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartGameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tapToPlayText;
    [SerializeField] private TextMeshProUGUI rewardedText;
    public GameObject pauseButton;
    public GameObject leaderboardButton;
    public GameObject achievementsButton;
    private UnityAdsManager unityAdManager;
    private GoogleAdMobManager adMobManager;
    private CombinedAdManager combinedAdManager;
    private GameObject adManager;
    int random;
    // Start is called before the first frame update
    void Start()
    {
        adManager = GameObject.FindGameObjectWithTag("Ad_Manager");
        unityAdManager = adManager.GetComponent<UnityAdsManager>();
        adMobManager = adManager.GetComponent<GoogleAdMobManager>();
        combinedAdManager = adManager.GetComponent<CombinedAdManager>();

        //combinedAdManager.showRandomBanner();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 1)
        {
            StartGame();
            tapToPlayText.enabled = false;
            pauseButton.SetActive(true);
            leaderboardButton.SetActive(false);
            achievementsButton.SetActive(false);
            //UnityAdsManager.Instance.HideBannerAd();
            //rewardedText.enabled = false;
            Time.timeScale = 1;

        }

        else
        {

            tapToPlayText.enabled = true;
            pauseButton.SetActive(false);
            leaderboardButton.SetActive(true);

            //CombinedAdManager.Instance.showRandomBanner(random);
            achievementsButton.SetActive(true);
            Time.timeScale = 0;

        }
    }

    private void StartGame()
    {
        SpawnManager.Instance.StartScript();
        DistanceManager.Instance.StartScript();
        SpaceshipMovement.Instance.StartScript();
        enabled = false;
    }
}

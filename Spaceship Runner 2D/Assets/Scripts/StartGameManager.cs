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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 1)
        {
            StartGame();
            tapToPlayText.enabled = false;
            pauseButton.SetActive(true);
            leaderboardButton.SetActive(false);
            achievementsButton.SetActive(false);
            UnityAdsManager.Instance.HideBannerAd();
            //rewardedText.enabled = false;
            Time.timeScale = 1;

        }

        else
        {
            tapToPlayText.enabled = true;
            pauseButton.SetActive(false);
            UnityAdsManager.Instance.PlayBannerAd();
            leaderboardButton.SetActive(true);
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

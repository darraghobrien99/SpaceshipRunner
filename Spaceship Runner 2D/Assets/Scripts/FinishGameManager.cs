using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinishGameManager : MonoBehaviour
{
    public static FinishGameManager Instance;
    [SerializeField] private TextMeshProUGUI youLostText;
    public GameObject pauseButton;
    private CombinedAdManager combinedAdManager;
    private GameObject adManager;
    private UnityAdsManager unityAdManager;


    [SerializeField] private GameObject gameOverPanel;
    void Start()
    {
        Instance = this;
        adManager = GameObject.FindGameObjectWithTag("Ad_Manager");
        combinedAdManager = adManager.GetComponent<CombinedAdManager>();
        unityAdManager = unityAdManager.GetComponent<UnityAdsManager>();
    }

    public void FinishGame()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        bool isNewHighScore = DistanceManager.Instance.CheckNewHighScore();
        pauseButton.SetActive(false);
        PlayServicesManager.Instance.updateLeaderboard();
        UnityAdsManager.Instance.ShowRewardedVideo();
        //  MoneyManager.Instance.saveCurrency();

        if (isNewHighScore)
        {
            youLostText.text = "New Highscore!";
        }

    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

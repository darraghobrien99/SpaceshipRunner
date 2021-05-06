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


    [SerializeField] private GameObject gameOverPanel;
    void Start()
    {
        Instance = this;
    }

    public void FinishGame()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        UnityAdsManager.Instance.ShowRewardedVideo();
        bool isNewHighScore = DistanceManager.Instance.CheckNewHighScore();
        pauseButton.SetActive(false);
        PlayServicesManager.Instance.updateLeaderboard();
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

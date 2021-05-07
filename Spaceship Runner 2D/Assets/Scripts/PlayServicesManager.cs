using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;

public class PlayServicesManager : MonoBehaviour
{
    public static PlayServicesManager Instance;
    private void Start()
    {
        Instance = this;
    }
    public void showLeaderboard()
    {
        Social.ShowLeaderboardUI();
    }

    public void showAchievements()
    {
        Social.ShowAchievementsUI();
    }

    public void updateLeaderboard()
    {
        if (PlayerPrefs.GetInt("prefKM") > 0)
        {
            Social.ReportScore(PlayerPrefs.GetInt("prefKM"), GPGSIds.leaderboard_high_score, null);
        }
    }

    public void reachedOneHundred()
    {
        Social.ReportProgress(GPGSIds.achievement_reached_100, 100f, null);
    }

    public void reachedTwoHundred()
    {
        Social.ReportProgress(GPGSIds.achievement_reached_200, 100f, null);
    }

    public void reachedFiveHundred()
    {
        Social.ReportProgress(GPGSIds.achievement_reached_500, 100f, null);
    }
}

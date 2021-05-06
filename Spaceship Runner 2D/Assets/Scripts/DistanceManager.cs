using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceManager : MonoBehaviour
{
    public static DistanceManager Instance;
    [SerializeField] private TextMeshProUGUI kmText;
    private float kmTravelled;
    private bool isMoving;
    public const string prefKM = "prefKM";
    [SerializeField] private TextMeshProUGUI youLostText;
    [SerializeField] private TextMeshProUGUI rewardedText;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
            return;
        kmTravelled += Time.deltaTime * 5;
        kmText.text = (int)kmTravelled + "KM";

        if (kmTravelled > 100)
        {
            PlayServicesManager.Instance.reachedOneHundred();
        }
    }

    public void StartScript()
    {
        isMoving = true;
    }

    public bool CheckNewHighScore()
    {
        if((int)kmTravelled > PlayerPrefs.GetInt("prefKM"))
        {
            //new high score
            PlayerPrefs.SetInt(prefKM, (int)kmTravelled);
            Debug.Log("New Highscore: " + (int)kmTravelled);
            return true;
        }

        else
        {
            Debug.Log("No new highscore");
            return false;
        }
    }

    public void AddToScore()
    {
        kmTravelled = (int)kmTravelled + 5;
        Debug.Log("Added to score");
        bool isNewHighScore = CheckNewHighScore();

    
    }
}

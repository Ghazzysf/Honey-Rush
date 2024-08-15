using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerAndScore : MonoBehaviour
{
    [SerializeField] TMP_Text timerText, timesUpText;
    public float timeAmount;

    private int score, highestScore;
    private bool timesUp;
    private string highestScoreKey;
    void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
        timesUp = false;
        timesUpText.gameObject.SetActive(false);
    }

    void Update()
    {   
         if (timesUp == false)
         {
            RunTimer();
         }
    }

    public void RunTimer()
    {
        if (timeAmount > 0)
        {
            timeAmount -= Time.deltaTime;
            DisplayTime(timeAmount);
        }
        else
        {
            timesUp = true;
            timeAmount = 0;
            timesUpText.gameObject.SetActive(true);
            Invoke("LoseSequence", 0.5f);
        }  
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void LoseSequence()
    {
        score = PlayerPrefs.GetInt("Score");
        int currentCoins = PlayerPrefs.GetInt("TotalCoins");
        int totalCoins = currentCoins + score * 10;
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
        if(PlayerPrefs.GetInt("SelectedLevel") == 3)
        {
            highestScore = PlayerPrefs.GetInt("HighestScoreEasy");
            highestScoreKey = "HighestScoreEasy";
        }
        else
        {
            highestScore = PlayerPrefs.GetInt("HighestScoreHard");
            highestScoreKey = "HighestScoreHard";
        }
        
        if(score > highestScore)
        {
            PlayerPrefs.SetInt(highestScoreKey, score);
        }

        Cursor.visible = true;
        SceneManager.LoadScene(5);
    }
}
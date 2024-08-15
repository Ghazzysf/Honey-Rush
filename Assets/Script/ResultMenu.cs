using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultMenu : MonoBehaviour
{
    [SerializeField] TMP_Text score, highestScore, coin;
    private int currentlvl;
    
    void Start()
    {
        currentlvl = PlayerPrefs.GetInt("SelectedLevel");
        score.SetText("You've Collected " + PlayerPrefs.GetInt("Score") + " Honey!");
        coin.SetText("+ " + PlayerPrefs.GetInt("Score")*10 + " Coins");
        if(currentlvl == 3)
        {
            highestScore.SetText("Highest Score : " + PlayerPrefs.GetInt("HighestScoreEasy"));
        }

        if(currentlvl == 4)
        {
            highestScore.SetText("Highest Score : " + PlayerPrefs.GetInt("HighestScoreHard"));
        }        
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(currentlvl);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

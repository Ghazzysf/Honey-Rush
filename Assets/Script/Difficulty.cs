using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty : MonoBehaviour
{
    [SerializeField] TMP_Text HighestScoreEasy, HighestScoreHard;
    
    void Start()
    {
        HighestScoreEasy.SetText(PlayerPrefs.GetInt("HighestScoreEasy").ToString());
        HighestScoreHard.SetText(PlayerPrefs.GetInt("HighestScoreHard").ToString());
    }

    public void EasyLevel()
    {
        PlayerPrefs.SetInt("SelectedLevel", 3);
        SceneManager.LoadScene(3);
    }

    public void HardLevel()
    {
        PlayerPrefs.SetInt("SelectedLevel", 4);
        SceneManager.LoadScene(4);
    }
}

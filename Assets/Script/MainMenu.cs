using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(2);
    }

    public void SelectCharacter()
    {
        SceneManager.LoadScene(1);
    }

    public void Instruction()
    {
        SceneManager.LoadScene(6);
    }

    public void BeliMadu()
    {
        Application.OpenURL("https://www.tokopedia.com/mutiaraibu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}

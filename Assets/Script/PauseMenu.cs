using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Pause();
        }
    }
    public void Pause()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        pauseMenu.gameObject.SetActive(true);
    }

    public void Resume()
    {
        Cursor.visible = false;
        Time.timeScale = 1;

        pauseMenu.gameObject.SetActive(false);
        print("Resume");
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class BgMusic : MonoBehaviour
{
    public static BgMusic instance;
 
    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 4)
        {
            instance.GetComponent<AudioSource>().Stop();
        }
        else
        {
            if (!instance.GetComponent<AudioSource>().isPlaying)
            {
                instance.GetComponent<AudioSource>().PlayDelayed(1.5f);
            }
        }
    }
}

using UnityEngine;

public class BgMusicGame : MonoBehaviour
{
    AudioSource bgMusic;
    void Start()
    {
        bgMusic = gameObject.GetComponent<AudioSource>();
        bgMusic.PlayDelayed(1.5f);
    }
}

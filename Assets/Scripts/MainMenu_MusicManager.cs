using UnityEngine;

public class MenuMusicManager : MonoBehaviour
{
    public static MenuMusicManager instance;

    public AudioSource audioSource;
    public AudioClip menuMusicClip;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource.clip = menuMusicClip;
            audioSource.loop = true;
            audioSource.Play();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMenuMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
            audioSource.Play();
        }
    }

    public void StopMenuMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void Mute()
    {
        if (audioSource != null)
        {
            audioSource.mute = !audioSource.mute;
        }
    }
}

using UnityEngine;

public class GameOverMusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip gameOverClip;

    public void PlayGameOverSound()
    {
        if (audioSource != null && gameOverClip != null)
        {
            audioSource.PlayOneShot(gameOverClip);
        }
    }
}

using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioClip hitEnemySound;
    public AudioClip enemyDeathSound;
    public AudioClip pickupXpSound;
    public AudioClip levelUpSound;
    public AudioClip upgradeSelectSound;
    public AudioClip takeDamageSound;
    public AudioClip playerAttackSound;

    private AudioSource audioSource;

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip != null)
            audioSource.PlayOneShot(clip);
    }
}

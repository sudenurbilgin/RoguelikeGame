using UnityEngine;
using System.Collections;

public class Enemy_Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public GameObject expPrefab;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public Color flashColor = new Color(1f, 0f, 0f, 0.6f);
    public float flashDuration = 0.1f;

    public AudioClip hitSound;
    public AudioClip deathSound;
    private AudioSource audioSource;
    public GameObject audioPlayerPrefab; 

    private void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        StartCoroutine(FlashOnHit());

        if (amount < 0 && hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        else if (currentHealth <= 0)
        {
            if (expPrefab != null)
            {
                Instantiate(expPrefab, transform.position, Quaternion.identity);
            }

            // Ölme sesi çalsýn ama düþmaný bekletmeden yok et
            if (deathSound != null && audioPlayerPrefab != null)
            {
                GameObject audioPlayer = Instantiate(audioPlayerPrefab, transform.position, Quaternion.identity);
                AudioSource source = audioPlayer.GetComponent<AudioSource>();
                source.clip = deathSound;
                source.Play();
                Destroy(audioPlayer, deathSound.length); // ses bitince sesi taþýyan obje silinir
            }

            Destroy(gameObject); // DÜÞMAN hemen sahneden silinir
        }
    }

    private IEnumerator FlashOnHit()
    {
        spriteRenderer.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }
}

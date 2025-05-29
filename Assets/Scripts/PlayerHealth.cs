using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public TMP_Text healthText;
    public Animator healthTextAnim;
    public GameOverManager gameOverManager;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public Color flashColor = new Color(1f, 0f, 0f, 0.6f);
    public float flashDuration = 0.1f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;

        currentHealth = maxHealth;
        UpdateHealthText();
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthText();

        if (amount < 0)
        {
            StartCoroutine(FlashOnHit());
        }

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            gameOverManager.ShowGameOver();
        }
    }

    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = currentHealth.ToString();
        }
    }

    private IEnumerator FlashOnHit()
    {
        spriteRenderer.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }
}

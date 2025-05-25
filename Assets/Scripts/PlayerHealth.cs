using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public TMP_Text healthText;
    public Animator healthTextAnim;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public Color flashColor = new Color(1f, 0f, 0f, 0.6f); // Light red
    public float flashDuration = 0.1f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Make sure this matches your setup
        originalColor = spriteRenderer.color;

        healthText.text = currentHealth.ToString();
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        healthTextAnim.Play("TextUpdate");
        healthText.text = currentHealth.ToString();

        if(amount < 0)
        {
            StartCoroutine(FlashOnHit());
        }

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);

        }
    }

    private IEnumerator FlashOnHit()
    {
        spriteRenderer.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }

}

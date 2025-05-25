using UnityEngine;
using System.Collections;


public class Enemy_Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public Color flashColor = new Color(1f, 0f, 0f, 0.6f);
    public float flashDuration = 0.1f;

    private void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        StartCoroutine(FlashOnHit());
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator FlashOnHit()
    {
        spriteRenderer.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }
}

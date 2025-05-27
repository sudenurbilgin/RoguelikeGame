using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public Image healthBarImage;
    public Sprite changingHealthbarFullHeartSet_0;
    public Sprite changingHealthbarFullHeartSet_1;
    public Sprite changingHealthbarFullHeartSet_2;
    public Sprite changingHealthbarFullHeartSet_3;

    private PlayerHealth playerHealth;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
        }
        else
        {
            Debug.LogError("Player with tag 'Player' not found!");
        }
    }

    void Update()
    {
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (playerHealth == null) return;

        int health = playerHealth.currentHealth;

        if (health > 60)
            healthBarImage.sprite = changingHealthbarFullHeartSet_0;
        else if (health > 30)
            healthBarImage.sprite = changingHealthbarFullHeartSet_1;
        else if (health > 0)
            healthBarImage.sprite = changingHealthbarFullHeartSet_2;
        else
            healthBarImage.sprite = changingHealthbarFullHeartSet_3;
    }
}

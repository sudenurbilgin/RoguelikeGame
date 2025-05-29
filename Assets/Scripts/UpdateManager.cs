using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    public GameObject upgradePanel;
    public List<Button> upgradeButtons;
    public List<Image> icons;
    public List<TMP_Text> descriptions;
    public List<UpgradeData> allUpgrades = new List<UpgradeData>();

    public AudioClip upgradeSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        upgradePanel.SetActive(false);
    }

    public void ShowUpgradeOptions()
    {
        upgradePanel.SetActive(true);
        Time.timeScale = 0f; // OYUNU DURDUR  

        List<UpgradeData> randomUpgrades = new List<UpgradeData>();
        while (randomUpgrades.Count < 3)
        {
            UpgradeData candidate = allUpgrades[Random.Range(0, allUpgrades.Count)];
            if (!randomUpgrades.Contains(candidate))
                randomUpgrades.Add(candidate);
        }

        for (int i = 0; i < upgradeButtons.Count; i++)
        {
            int index = i;
            icons[i].sprite = randomUpgrades[i].icon;
            descriptions[i].text = randomUpgrades[i].description;
            upgradeButtons[i].onClick.RemoveAllListeners();
            upgradeButtons[i].onClick.AddListener(() => ApplyUpgrade(randomUpgrades[index]));
        }
    }

    public void ApplyUpgrade(UpgradeData upgrade)
    {
        if (upgradeSound != null)
            audioSource.PlayOneShot(upgradeSound);

        switch (upgrade.type)
        {
            case UpgradeType.IncreaseMaxHealth:
                FindObjectOfType<PlayerHealth>().maxHealth += 10;
                break;
            case UpgradeType.HealOverTime:
                FindObjectOfType<PlayerHealth>().currentHealth += 5;
                break;
            case UpgradeType.ExpandPickupRange:
                FindObjectOfType<PlayerExp>().pickupRadius += 0.5f;
                break;
            case UpgradeType.GainMoreExp:
                FindObjectOfType<PlayerExp>().expMultiplier += 0.25f;
                break;
            case UpgradeType.SwordDamageUp:
                FindObjectOfType<Player_combat>().damage += 10;
                break;
            case UpgradeType.MoveSpeedUp:
                FindObjectOfType<PlayerMovement>().speed += 1f;
                break;
            case UpgradeType.CritChanceUp:
                FindObjectOfType<Player_combat>().critChance += 0.15f;
                break;

        }

        upgradePanel.SetActive(false);
        Time.timeScale = 1f; // OYUNU DEVAM ETTÝR  
    }
}
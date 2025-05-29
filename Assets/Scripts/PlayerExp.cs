using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;


public class PlayerExp : MonoBehaviour
{
    public TextMeshProUGUI xpScoreText; // Ekrandaki toplam XP yazısı

    public TextMeshProUGUI xpText; // UI'daki XP yazısı
    public int totalExp = 0; // Toplam XP skoru
    public float pickupRadius = 0.5f;
    public float expMultiplier = 1f;
    public int currentExp = 0;
    public int level = 1;
    public int expToNextLevel = 10;

    public AudioClip levelUpSound;
    private AudioSource audioSource;

    public Slider expBar; // EXP bar� atanmal�

    public UpgradeManager upgradeManager; // Upgrade ekran�n� �a��rmak i�in

    public void GainExp(int amount)
{
    int finalExp = Mathf.RoundToInt(amount * expMultiplier);

    // Level için XP
    currentExp += finalExp;

    // Skor için XP
    totalExp += finalExp;

    UpdateExpBar();
    UpdateExpScore(); // Yeni fonksiyon

    if (currentExp >= expToNextLevel)
    {
        LevelUp();
    }
}
    void UpdateExpScore()
    {
        if (xpScoreText != null)
        xpScoreText.text = "Score: " + totalExp;
    }

    void UpdateExpBar()
    {
    if (expBar != null)
        expBar.value = (float)currentExp / expToNextLevel;

    if (xpText != null)
        xpText.text = "Score: " + currentExp;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void LevelUp()
    {
        if (levelUpSound != null)
            audioSource.PlayOneShot(levelUpSound);

        currentExp -= expToNextLevel; // sadece bar sıfırlanır
        level++;
        expToNextLevel += 5;

        upgradeManager.ShowUpgradeOptions();
        UpdateExpBar(); // sadece slider güncellenir
        UpdateExpScore(); // LevelUp sonrası skor metnini güncelle

    }

}

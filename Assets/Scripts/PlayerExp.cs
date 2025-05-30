using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;


public class PlayerExp : MonoBehaviour
{
    public TextMeshProUGUI xpScoreText; 

    public TextMeshProUGUI xpText; 
    public int totalExp = 0; 
    public float pickupRadius = 0.5f;
    public float expMultiplier = 1f;
    public int currentExp = 0;
    public int level = 1;
    public int expToNextLevel = 10;

    public AudioClip levelUpSound;
    private AudioSource audioSource;

    public Slider expBar; 

    public UpgradeManager upgradeManager; 

    public void GainExp(int amount)
{
    int finalExp = Mathf.RoundToInt(amount * expMultiplier);

    // XP for level
    currentExp += finalExp;

    // XP for total score
    totalExp += finalExp;

    UpdateExpBar();
    UpdateExpScore(); 

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

        currentExp -= expToNextLevel; 
        level++;
        expToNextLevel += 5;

        upgradeManager.ShowUpgradeOptions();
        UpdateExpBar(); 
        UpdateExpScore(); 

    }

}

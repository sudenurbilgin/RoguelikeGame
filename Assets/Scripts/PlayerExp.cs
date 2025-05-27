using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerExp : MonoBehaviour
{
    public float pickupRadius = 0.5f;
    public float expMultiplier = 1f;
    public int currentExp = 0;
    public int level = 1;
    public int expToNextLevel = 10;

    public Slider expBar; // EXP barý atanmalý

    public UpgradeManager upgradeManager; // Upgrade ekranýný çaðýrmak için

    public void GainExp(int amount)
    {
        int finalExp = Mathf.RoundToInt(amount * expMultiplier); // buff varsa çarpan uygula
        currentExp += finalExp;
        UpdateExpBar();

        if (currentExp >= expToNextLevel)
        {
            LevelUp();
        }
    }


    void UpdateExpBar()
    {
        if (expBar != null)
        {
            expBar.value = (float)currentExp / expToNextLevel;
        }
    }

    void LevelUp()
    {
        currentExp -= expToNextLevel;
        level++;
        expToNextLevel += 5; // Her seviye daha fazla gerektirir

        upgradeManager.ShowUpgradeOptions(); // 3 seçenek sunar
        UpdateExpBar();
    }
}

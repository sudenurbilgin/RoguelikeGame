using UnityEngine;

[CreateAssetMenu(fileName = "NewUpgradeData", menuName = "Upgrade/UpgradeData")]
public class UpgradeData : ScriptableObject
{
    public string upgradeName;
    public string description;
    public Sprite icon;
    public UpgradeType type;
}

public enum UpgradeType
{
    IncreaseMaxHealth,
    HealOverTime,
    ExpandPickupRange,
    GainMoreExp,
    SwordDamageUp,
    MoveSpeedUp,
    CritChanceUp
}

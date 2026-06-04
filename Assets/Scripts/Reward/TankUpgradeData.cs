using UnityEngine;

[CreateAssetMenu(menuName = "Reward/Tank Upgrade")]
public class TankUpgradeData : ScriptableObject
{
    public string upgradeName;

    public int hpBonus;

    public float reloadMultiplier = 1f;
}

using UnityEngine;
using System;

public class RewardSystem : MonoBehaviour
{
    public static RewardSystem Instance;

    public event EventHandler OnRewardClaim;

    [SerializeField] private DeckManager deckSystem;

    [SerializeField] private Tank playerTank;

    void Awake()
    {
        Instance = this;
    }

    public void ClaimReward(RewardData reward)
    {
        switch (reward.rewardType)
        {
            case RewardType.Card:
            case RewardType.CrewCard:
                deckSystem.AddCardToDeck(
                    reward.cardReward);
                break;

            case RewardType.TankUpgrade:
                ApplyTankUpgrade(
                    reward.tankUpgradeReward);
                break;
        }

        OnRewardClaim?.Invoke(this, EventArgs.Empty);
    }

    void ApplyTankUpgrade(TankUpgradeData upgrade)
    {
        playerTank.AddMaxHP(upgrade.hpBonus);

        playerTank.stats.reloadSpeed *=
            upgrade.reloadMultiplier;
    }
}

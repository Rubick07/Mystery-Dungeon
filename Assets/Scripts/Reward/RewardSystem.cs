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
                RunManager.Instance.CurrentRun.deck.Add(reward.cardReward);
                break;

            case RewardType.CrewCard:
                CrewCardData crewCard = reward.cardReward as CrewCardData;

                if (crewCard == null)
                    return;

                RunManager.Instance.CurrentRun.crews.Add(crewCard.crewData);

                break;

            case RewardType.TankUpgrade:
                RunManager.Instance.CurrentRun.MaxHP += reward.tankUpgradeReward.hpBonus;
                RunManager.Instance.CurrentRun.ReloadMultiplier *= reward.tankUpgradeReward.reloadMultiplier;
                break;
        }

        RunManager.Instance.GoToNextBattle();

        OnRewardClaim?.Invoke(this, EventArgs.Empty);
    }

    void ApplyTankUpgrade(TankUpgradeData upgrade)
    {
        playerTank.AddMaxHP(upgrade.hpBonus);

        playerTank.stats.reloadSpeed *=
            upgrade.reloadMultiplier;
    }
}

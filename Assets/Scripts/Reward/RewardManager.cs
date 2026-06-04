using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    [SerializeField] private List<CardData> cardPool;

    [SerializeField] private List<CrewCardData> crewPool;

    [SerializeField] private List<TankUpgradeData> upgradePool;

    public List<RewardData> GenerateRewards()
    {
        List<RewardData> rewards = new();

        rewards.Add(CreateRandomCardReward());

        rewards.Add(CreateRandomCrewReward());

        rewards.Add(CreateRandomUpgradeReward());

        return rewards;
    }

    RewardData CreateRandomCardReward()
    {
        return new RewardData
        {
            rewardType = RewardType.Card,
            cardReward = cardPool[
                Random.Range(0, cardPool.Count)]
        };
    }

    RewardData CreateRandomCrewReward()
    {
        return new RewardData
        {
            rewardType = RewardType.CrewCard,
            cardReward = crewPool[
                Random.Range(0, crewPool.Count)]
        };
    }

    RewardData CreateRandomUpgradeReward()
    {
        return new RewardData
        {
            rewardType = RewardType.TankUpgrade,
            tankUpgradeReward = upgradePool[
                Random.Range(0, upgradePool.Count)]
        };
    }
}

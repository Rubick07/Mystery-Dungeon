using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    [SerializeField] private List<RelicData> relicPool;

    [SerializeField] private List<CrewCardData> crewPool;

    [SerializeField] private List<TankUpgradeData> upgradePool;

    public List<RewardData> GenerateRewards()
    {
        List<RewardData> rewards = new();

        rewards.Add(CreateRandomRelicReward());

        rewards.Add(CreateRandomCrewReward());

        rewards.Add(CreateRandomUpgradeReward());

        return rewards;
    }

    RewardData CreateRandomRelicReward()
    {
        return new RewardData
        {
            rewardType = RewardType.Relic,
            relicReward = relicPool[Random.Range(0, relicPool.Count)]
        };
    }

    RewardData CreateRandomCrewReward()
    {
        return new RewardData
        {
            rewardType = RewardType.CrewCard,
            cardReward = crewPool[Random.Range(0, crewPool.Count)]
        };
    }

    RewardData CreateRandomUpgradeReward()
    {
        return new RewardData
        {
            rewardType = RewardType.TankUpgrade,
            tankUpgradeReward = upgradePool[Random.Range(0, upgradePool.Count)]
        };
    }
}

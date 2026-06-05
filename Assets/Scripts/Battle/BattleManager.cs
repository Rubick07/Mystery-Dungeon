using UnityEngine;
using System.Collections.Generic;
using System;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    public event EventHandler<List<RewardData>> OnBattleWin;
    public event EventHandler OnBattleLose;

    public event EventHandler OnBattleEnd;

    [SerializeField] private RewardManager rewardManager;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Tank.OnAnyTankDied += Tank_OnAnyTankDied;
    }

    private void Tank_OnAnyTankDied(object sender, bool e)
    {
        if (e)
        {
            OnBattleWon();
        }
        else
        {
            OnBattleLose?.Invoke(this, EventArgs.Empty);
        }

        OnBattleEnd?.Invoke(this, EventArgs.Empty);
    }

    public void OnBattleWon()
    {
        List<RewardData> rewards = rewardManager.GenerateRewards();

        OnBattleWin?.Invoke(this, rewards);
    }

    private void OnDestroy()
    {
        Tank.OnAnyTankDied -= Tank_OnAnyTankDied;
    }

}

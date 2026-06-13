using UnityEngine;
using System.Collections.Generic;
using System;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    public event EventHandler OnRunClear;

    public event EventHandler<List<RewardData>> OnBattleWin;
    public event EventHandler OnBattleLose;

    public event EventHandler OnBattleStart;
    public event EventHandler OnBattleEnd;

    [SerializeField] private RewardManager rewardManager;
    [SerializeField] private BattleInitializer battleInitializer;

    [SerializeField] private DeckManager deckManager;
    [SerializeField] private HandSystem handSystem;
    [SerializeField] private CrewManager crewManager;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Tank.OnAnyTankDied += Tank_OnAnyTankDied;
    }

    public void StartBattle()
    {
        CleanupBattle();

        BattleData battle = RunManager.Instance.GetCurrentBattle();
        battleInitializer.Initialize(RunManager.Instance.CurrentRun,battle);

        OnBattleStart?.Invoke(this, EventArgs.Empty);
    }
    void CleanupBattle()
    {
        //enemySpawner.ClearEnemy();
        //projectileManager.ClearAllProjectiles();

        deckManager.Clear();
        handSystem.Clear();
        //crewManager.Clear();

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
        if (RunManager.Instance.IsCurrentBattleLast())
        {
            OnRunClear?.Invoke(this, EventArgs.Empty);
            return;
        }


        List<RewardData> rewards = rewardManager.GenerateRewards();

        OnBattleWin?.Invoke(this, rewards);
    }

    private void OnDestroy()
    {
        Tank.OnAnyTankDied -= Tank_OnAnyTankDied;
    }

}

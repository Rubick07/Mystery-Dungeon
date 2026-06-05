using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinBattleUI : MonoBehaviour
{
    [SerializeField] private RewardButton[] rewardButtons;
    private void Start()
    {
        BattleManager.instance.OnBattleWin += BattleManager_OnBattleWin;
        RewardSystem.Instance.OnRewardClaim += BattleManager_OnRewardClaim;

        Hide();
    }

    private void BattleManager_OnRewardClaim(object sender, EventArgs e)
    {
        Hide();
    }

    private void BattleManager_OnBattleWin(object sender, List<RewardData> e)
    {
        Show();

        ShowRewards(e);
    }

    public void ShowRewards(List<RewardData> rewards)
    {
        gameObject.SetActive(true);

        for (int i = 0; i < rewards.Count; i++)
        {
            rewardButtons[i].Setup(rewards[i]);
        }
    }


    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);

    private void OnDestroy()
    {
        BattleManager.instance.OnBattleWin -= BattleManager_OnBattleWin;
        RewardSystem.Instance.OnRewardClaim -= BattleManager_OnRewardClaim;
    }


}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RewardButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TMP_Text titleText;

    private RewardData reward;

    private void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    public void Setup(RewardData data)
    {
        reward = data;

        switch (data.rewardType)
        {
            case RewardType.Relic:
                titleText.text = data.relicReward.relicName;
                break;

            case RewardType.CrewCard:
                titleText.text = data.cardReward.cardName;
                break;

            case RewardType.TankUpgrade:
                titleText.text = data.tankUpgradeReward.upgradeName;
                break;
        }
    }

    public void OnClick()
    {
        Debug.Log("CLAIM REWARD " + reward.rewardType);
        RewardSystem.Instance.ClaimReward(reward);
    }
}

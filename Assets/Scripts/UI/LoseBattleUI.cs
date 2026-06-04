using UnityEngine;

public class LoseBattleUI : MonoBehaviour
{
    private void Start()
    {
        BattleManager.instance.OnBattleLose += BattleManager_OnBattleLose;

        Hide();
    }

    private void BattleManager_OnBattleLose(object sender, System.EventArgs e)
    {
        Show();
    }

    public void Show() => gameObject.SetActive(true);

    public void Hide() => gameObject.SetActive(false);
}
